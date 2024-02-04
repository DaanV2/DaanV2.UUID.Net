using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V6 {
    /// <summary>Converts the given datetime to a <see cref="UUID"/> time, which has a different <see cref="V6.Epoch"/></summary>
    /// <param name="datetime">The date time to convert</param>
    /// <returns>A <see cref="UInt64"/> carrying the <see cref="UUID"/> timestamp</returns>
    public static UInt64 TimeStamp(DateTime datetime) {
        UInt64 time = (UInt64)datetime.ToFileTimeUtc();
        time += V6.Epoch;
        return time;
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate() {
        return Generate(V6.GetMacAddressBytes());
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, UInt16 nanoSeconds) {
        return Generate(timestamp, nanoSeconds, V6.GetMacAddressBytes());
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp) {
        return Generate(timestamp, V6.GetMacAddressBytes());
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(ReadOnlySpan<Byte> macAddress) {
        return Generate(DateTime.UtcNow, macAddress);
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, ReadOnlySpan<Byte> macAddress) {
        UInt16 nanoSeconds = (UInt16)(timestamp.Ticks % 10000000);
        return Generate(timestamp, nanoSeconds, macAddress);
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, UInt16 nanoSeconds, ReadOnlySpan<Byte> macAddress) {
        return Generate(TimeStamp(timestamp), nanoSeconds, macAddress);
    }

    /// <summary>Generates a new <see cref="UUID"/> from a timestamp and macAddress</summary>
    /// <param name="timestamp">The timestamp to use</param>
    /// <param name="nanoSeconds">The nanoSeconds to use</param>
    /// <param name="macAddress">The mac address to use</param>
    /// <returns>A new <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static UUID Generate(UInt64 timestamp, UInt16 nanoSeconds, ReadOnlySpan<Byte> macAddress) {
        //First 32 bites = time_high
        //Next 16 bites = time_mid
        //Next 16 bites = time_low_version = time_high | version
        //next 8 bites = clock_seq_hi_variant 
        //next 8 bites = clock_seq_low | node
        //last 48 bites mac address

        Span<Byte> data = stackalloc Byte[Format.UUID_BYTE_LENGTH];

        //mac is 6 bytes, transfer to 8 bytes and use BinaryPrimitives to convert to UInt64
        macAddress.CopyTo(data[10..]);
        var read = Vector64.Create<UInt64>(timestamp);

        //Setting timelow to be the 32 most significant bits of the timestamp
        UInt32 timeLow = read.AsUInt32().GetElement(1);
        BinaryPrimitives.WriteUInt32BigEndian(data, timeLow);
        //Next 16 bites = time_mid
        UInt16 timeMid = read.AsUInt16().GetElement(1);
        BinaryPrimitives.WriteUInt16BigEndian(data[4..], timeMid);
        //Next 16 bites = time_hi_version = time_low | version
        UInt16 timeHiVersion = read.AsUInt16().GetElement(0);
        BinaryPrimitives.WriteUInt16BigEndian(data[6..], timeHiVersion);
        BinaryPrimitives.WriteUInt16BigEndian(data[8..], nanoSeconds);

        var uuid = Vector128.Create<Byte>(data);
        uuid = Format.StampVersion(V6._VersionMask, V6._VersionOverlay, uuid);
        return new UUID(uuid);
    }
}
