using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V1 {
    public static UInt64 TimeStamp(DateTime datetime) {
        UInt64 time = (UInt64)datetime.ToFileTimeUtc();
        time += V1.Epoch;
        return time;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static UUID Generate() {
        return Generate(V1.GetMacAddressBytes());
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, Byte Nanoseconds) {
        return Generate(timestamp, Nanoseconds, V1.GetMacAddressBytes());
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp) {
        return Generate(timestamp, V1.GetMacAddressBytes());
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(ReadOnlySpan<Byte> MacAddress) {
        return Generate(DateTime.UtcNow, MacAddress);
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, ReadOnlySpan<Byte> MacAddress) {
        UInt16 nanoseconds = (UInt16)(timestamp.Ticks % 10000000);
        return Generate(timestamp, nanoseconds, MacAddress);
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, UInt16 Nanoseconds, ReadOnlySpan<Byte> MacAddress) {
        return Generate(TimeStamp(timestamp), Nanoseconds, MacAddress);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static UUID Generate(UInt64 timestamp, UInt16 nanoseconds, ReadOnlySpan<Byte> MacAddress) {
        //First 32 bites = time_low
        //Next 16 bites = time_mid
        //Next 16 bites = time_hi_version = time_high | version
        //next 8 bites = clock_seq_hi_variant 
        //next 8 bites = clock_seq_low | node
        //last 48 bites mac address

        Span<Byte> data = stackalloc Byte[Format.UUID_BYTE_LENGTH];

        //mac is 6 bytes, transfer to 8 bytes and use BinaryPrimitives to convert to UInt64
        MacAddress.CopyTo(data[10..]);
        var read = Vector64.Create<UInt64>(timestamp);

        //Setting timelow to be the 32 least significant bits of the timestamp
        UInt32 timeLow = read.AsUInt32().GetElement(0);
        BinaryPrimitives.WriteUInt32BigEndian(data, timeLow);
        //Next 16 bites = time_mid
        UInt16 timeMid = read.AsUInt16().GetElement(2);
        BinaryPrimitives.WriteUInt16BigEndian(data[4..], timeMid);
        //Next 16 bites = time_hi_version = time_high | version
        UInt16 timeHiVersion = read.AsUInt16().GetElement(3);
        BinaryPrimitives.WriteUInt16BigEndian(data[6..], timeHiVersion);
        BinaryPrimitives.WriteUInt16BigEndian(data[8..], nanoseconds);

        var uuid = Vector128.Create<Byte>(data);
        uuid = Format.StampVersion(V1._VersionMask, V1._VersionOverlay, uuid);
        return new UUID(uuid);
    }
}
