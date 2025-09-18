using System.Runtime.CompilerServices;

namespace DaanV2.UUID;

public static partial class V2 {
    /// <inheritdoc cref="Batch(Int32, DateTime, ReadOnlySpan{Byte}, Byte)"/>

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, Byte domain = 0) {
        return Batch(amount, DateTime.UtcNow, V1.GetMacAddressBytes(), domain);
    }

    /// <inheritdoc cref="Batch(Int32, DateTime, ReadOnlySpan{Byte}, Byte)"/>

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, DateTime startTimestamp, Byte domain = 0) {
        return Batch(amount, startTimestamp, V1.GetMacAddressBytes(), domain);
    }

    /// <inheritdoc cref="Batch(Int32, DateTime, ReadOnlySpan{Byte}, Byte)"/>

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, ReadOnlySpan<Byte> macAddress, Byte domain = 0) {
        return Batch(amount, DateTime.UtcNow, macAddress, domain);
    }

    /// <summary>Creates a batch of <see cref="UUID"/>, Note: This function use <see cref="DateTime.Now"/> To grab a starting point, 
    /// but will increment the timestamp to create a new <see cref="UUID"/></summary>
    /// <param name="amount">The amount of <see cref="UUID"/> to create</param>
    /// <param name="startTimestamp">The time to start at, will increment for each following <see cref="UUID"/></param>
    /// <param name="macAddress">The macAddress to use, excepts to be 6 bytes</param>
    /// <param name="domain">An byte to indicate the domain</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, DateTime startTimestamp, ReadOnlySpan<Byte> macAddress, Byte domain = 0) {
        var uuids = new UUID[amount];
        DateTime timestamp = startTimestamp;
        for (Int32 i = 0; i < amount; i++) {
            // Use i as the local identifier (UID/GID) for demonstration; domain is passed in
            uuids[i] = Generate(timestamp, (UInt32)(i << 8), macAddress, domain);
            // Optionally increment timestamp if you want unique timestamps per UUID
            if (i % UInt16.MaxValue == 0) {
                timestamp = timestamp.AddTicks(1);
            }
        }
        return uuids;
    }
}
