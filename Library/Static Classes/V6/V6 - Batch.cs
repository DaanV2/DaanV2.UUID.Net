using System.Runtime.CompilerServices;

namespace DaanV2.UUID;

public static partial class V6 {
    /// <inheritdoc cref="Batch(Int32, DateTime, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount) {
        return Batch(amount, V6.GetMacAddressBytes());
    }

    /// <inheritdoc cref="Batch(Int32, DateTime, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, DateTime startTimestamp) {
        return Batch(amount, startTimestamp, V1.GetMacAddressBytes());
    }

    /// <inheritdoc cref="Batch(Int32, DateTime, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, ReadOnlySpan<Byte> macAddress) {
        return Batch(amount, DateTime.UtcNow, macAddress);
    }

    /// <summary>Creates a batch of <see cref="UUID"/>, Note: This function use <see cref="DateTime.Now"/> To grab a starting point, 
    /// but will increment the timestamp to create a new <see cref="UUID"/></summary>
    /// <param name="amount">The amount of <see cref="UUID"/> to create</param>
    /// <param name="startTimestamp">The time to start at, will increment for each following <see cref="UUID"/></param>
    /// <param name="macAddress">The macAddress to use, excepts to be 6 bytes</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, DateTime startTimestamp, ReadOnlySpan<Byte> macAddress) {
        var uuids = new UUID[amount];
        UInt64 timestamp = TimeStamp(startTimestamp);

        for (Int32 i = 0; i < amount; i++) {
            uuids[i] = Generate(timestamp, (UInt16)i, macAddress);

            //Increment the timestamp if the nanoseconds are 
            if (i % UInt16.MaxValue == 0) {
                timestamp++;
            }
        }

        return uuids;
    }
}
