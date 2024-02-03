using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Convert {
    /// <summary>Slices the given bytes into UUIDs</summary>
    /// <param name="bytes">The bytes to slice</param>
    /// <param name="version">The version to stamp in the UUID</param>
    /// <param name="variant">The variant to stamp in the UUID</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Slice(ReadOnlySpan<Byte> bytes, Version version, Variant variant) {
        Vector128<Byte> mask = Format.VersionVariantMaskNot(version, variant);
        Vector128<Byte> overlay = Format.VersionVariantOverlayer(version, variant);

        return Slice(bytes, mask, overlay);
    }

    /// <summary>Slices the given bytes into UUIDs</summary>
    /// <param name="bytes">The bytes to slice</param>
    /// <param name="mask">The mask to apply</param>
    /// <param name="overlay">The overlay to add to the <see cref="UUID"/> usually version and variant</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Slice(ReadOnlySpan<Byte> bytes, Vector128<Byte> mask, Vector128<Byte> overlay) {
        Int32 count = bytes.Length;
        Int32 amount = count / Format.UUID_BYTE_LENGTH;
        Int32 max = count - Format.UUID_BYTE_LENGTH;
        var uuids = new UUID[amount];

        Int32 J = 0;
        for (Int32 I = 0; I <= max; I += Format.UUID_BYTE_LENGTH) {
            var data = Vector128.Create(bytes.Slice(I, Format.UUID_BYTE_LENGTH));
            Vector128<Byte> uuid = Format.StampVersion(mask, overlay, data);
            uuids[J++] = new UUID(uuid);
        }

        return uuids;
    }
}
