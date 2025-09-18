using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V1 {
    /// <summary>Converts the given datetime to a <see cref="UUID"/> time, which has a different <see cref="V1.Epoch"/></summary>
    /// <param name="datetime">The date time to convert</param>
    /// <returns>A <see cref="UInt64"/> carrying the <see cref="UUID"/> timestamp</returns>
    public static UInt64 TimeStamp(DateTime datetime) {
        UInt64 time = (UInt64)datetime.ToFileTimeUtc();
        time += V1.Epoch;
        return time;
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate() {
        return Generate(V1.GetMacAddressBytes());
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, UInt16 nanoSeconds) {
        return Generate(timestamp, nanoSeconds, V1.GetMacAddressBytes());
    }

    /// <inheritdoc cref="Generate(UInt64, UInt16, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp) {
        return Generate(timestamp, V1.GetMacAddressBytes());
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
        // RFC 4122 layout:
        // 0-3: time_low
        // 4-5: time_mid
        // 6-7: time_hi_and_version
        // 8:   clock_seq_hi_and_reserved (variant in high bits)
        // 9:   clock_seq_low
        // 10-15: node (MAC address)

        Span<Byte> data = stackalloc Byte[Format.UUID_BYTE_LENGTH];

        // Write node (MAC address)
        macAddress.CopyTo(data[10..]);

        // Split timestamp
        UInt32 timeLow = (UInt32)(timestamp & 0xFFFFFFFF);
        UInt16 timeMid = (UInt16)((timestamp >> 32) & 0xFFFF);
        UInt16 timeHi = (UInt16)((timestamp >> 48) & 0x0FFF); // 12 bits for time_hi
        UInt16 timeHiAndVersion = (UInt16)(timeHi | ((byte)V1.Version << 12)); // Set version 1 using constant

        BinaryPrimitives.WriteUInt32BigEndian(data, timeLow);
        BinaryPrimitives.WriteUInt16BigEndian(data[4..], timeMid);
        BinaryPrimitives.WriteUInt16BigEndian(data[6..], timeHiAndVersion);

        // Split nanoSeconds (clock sequence) into 14 bits
        UInt16 clockSeq = (UInt16)(nanoSeconds & 0x3FFF);
        data[8] = (byte)(((clockSeq >> 8) & 0x3F) | (byte)V1.Variant); // Set variant using constant
        data[9] = (byte)(clockSeq & 0xFF);

        var uuid = Vector128.Create<Byte>(data);
        return new UUID(uuid);
    }
}
