using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V4 {
    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount) {
        return Batch(amount, Random.Shared);
    }

    /// <summary>Generates a batch of <see cref="UUID"/> using randomized data</summary>
    /// <param name="amount">The amount of <see cref="UUID"/>s to generate</param>
    /// <param name="rnd">The randomizor to use</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, Random rnd) {
        var uuids = new UUID[amount];

        //Cant allocate more than 1024 bytes on the stack
        const Int32 MaxStackAlloc = 1024;
        Int32 toAllocate = Format.UUID_BYTE_LENGTH * amount;

        Span<Byte> bytes = toAllocate <= MaxStackAlloc ?
            stackalloc Byte[Format.UUID_BYTE_LENGTH * amount] :
            new Byte[Format.UUID_BYTE_LENGTH * amount];

        rnd.NextBytes(bytes);

        return Batch(bytes);
    }

    /// <summary>Turns the entire bytes collection into UUIDs</summary>
    /// <param name="bytes">The byte to chunk into <see cref="UUID"/></param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(ReadOnlySpan<Byte> bytes) {
        return Convert.Slice(bytes, _VersionMask, _VersionOverlay);
    }

    /// <summary>Uses a user specified function to generate more <see cref="UUID"/></summary>
    /// <param name="amount">The amount of <see cref="UUID"/>s to generate</param>
    /// <param name="generateContents">The function to provide content</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, Func<Int32, Memory<Byte>> generateContents) {
        var uuids = new UUID[amount];

        for (Int32 I = 0; I < uuids.Length; I++) {
            Memory<Byte> bytes = generateContents(I);
            var data = Vector128.Create<Byte>(bytes.Span);
            Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
            uuids[I] = new UUID(uuid);
        }

        return uuids;
    }
}
