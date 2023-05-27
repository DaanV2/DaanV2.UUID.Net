using System.Runtime.CompilerServices;

namespace DaanV2.UUID;

public static partial class V1 {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static UUID[] GenerateBatch(Int32 Amount) {
        return GenerateBatch(Amount, V1.GetMacAddressBytes());
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] GenerateBatch(Int32 Amount, DateTime startTimestamp) {
        return GenerateBatch(Amount, startTimestamp, V1.GetMacAddressBytes());
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] GenerateBatch(Int32 Amount, ReadOnlySpan<Byte> MacAddress) {
        return GenerateBatch(Amount, DateTime.UtcNow, MacAddress);
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] GenerateBatch(Int32 Amount, DateTime startTimestamp, ReadOnlySpan<Byte> MacAddress) {
        var uuids = new UUID[Amount];
        UInt64 timestamp = TimeStamp(startTimestamp);

        for (Int32 i = 0; i < Amount; i++) {
            uuids[i] = Generate(timestamp, (UInt16)i, MacAddress);

            //Increment the timestamp if the nanoseconds are 
            if (i % UInt16.MaxValue == 0) {
                timestamp++;
            }
        }

        return uuids;
    }
}
