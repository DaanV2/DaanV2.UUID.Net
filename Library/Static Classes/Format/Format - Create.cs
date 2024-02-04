using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <inheritdoc cref="Create(Version,Variant,Vector128{Byte})"/>
    public static Vector128<Byte> Create(Version version, Variant variant, ReadOnlySpan<Byte> data) {
        var temp = Vector128.Create(data);
        return Create(version, variant, temp);
    }

    /// <inheritdoc cref="Create(Version,Variant,Vector128{Byte})"/>
    public static Vector128<Byte> Create(Version version, Variant variant, UInt64 e0, UInt64 e1) {
        Vector128<Byte> temp = Vector128.Create(e0, e1).AsByte();
        // Reverse the order of the bytes with a shuffle, sinces strings are little endian
        temp = temp.Reverse();

        return Create(version, variant, temp);
    }

    /// <summary>Creates a new vector of the given data, with the version and variant inserted</summary>
    /// <param name="version">The version to insert</param>
    /// <param name="variant">The variant to insert</param>
    /// <param name="data">The contents of the <see cref="UUID"/></param>
    /// <param name="e0">The lower 64 bits of the <see cref="UUID"/></param>
    /// <param name="e1">The upper 64 bits of the <see cref="UUID"/></param>
    /// <returns>Returns a <see cref="Vector128{T}"/></returns>
    public static Vector128<Byte> Create(Version version, Variant variant, Vector128<Byte> data) {
        Vector128<Byte> mask = VersionVariantMaskNot(version, variant);
        Vector128<Byte> overlay = VersionVariantOverlayer(version, variant);

        return StampVersion(mask, overlay, data);
    }

    /// <summary>Creates a layout of the data along with version and variant, the provided data will be placed around the version and variant</summary>
    /// <param name="version">The version to set</param>
    /// <param name="variant">The variant to set</param>
    /// <param name="dataA">48 bits of data, top 16 will be removed</param>
    /// <param name="dataB">12 bits of data, top 4 will be removed</param>
    /// <param name="dataC">62 bits of data, top 2 will be removed</param>
    /// <returns></returns>
    public static Vector128<Byte> Create(Version version, Variant variant, UInt64 dataA, UInt16 dataB, UInt64 dataC) {
        // 48 bits of data in the top, 16 bits will be removed
        UInt64 upper = dataA << 16;
        // 12 bits in the lower, 4 bits in the middle for the version.
        upper |= dataB;

        // 62 bits of data in the lower, 2 bits in the top for the variant.
        return Create(version, variant, dataC, upper);
    }
}