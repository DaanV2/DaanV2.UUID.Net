using System.Runtime.CompilerServices;
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
        return Create(version, variant, temp);
    }

    /// <summary>Creates a new vector of the given data, with the version & variant inserted</summary>
    /// <param name="version">The version to insert</param>
    /// <param name="variant">The variant to insert</param>
    /// <param name="data">The contents of the <see cref="UUID"/></param>
    /// <returns>Returns a <see cref="Vector128{T}"/></returns>
    public static Vector128<Byte> Create(Version version, Variant variant, Vector128<Byte> data) {
        Vector128<Byte> mask = VersionVariantMaskNot(version, variant);
        Vector128<Byte> overlay = VersionVariantOverlayer(version, variant);

        return StampVersion(mask, overlay, data);
    }

    /// <summary>Uses the given mask and overlay to insert the version and variant onto the data</summary>
    /// <param name="versionMask">The mask of the versions & variants</param>
    /// <param name="versionOverlay">The overlay of the versions & variants</param>
    /// <param name="data">The data to stamp the version & variant onto</param>
    /// <returns>Returns a <see cref="Vector128{T}"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector128<Byte> StampVersion(Vector128<Byte> versionMask, Vector128<Byte> versionOverlay, Vector128<Byte> data) {
        var result = Vector128.BitwiseAnd(data, versionMask);
        result = Vector128.BitwiseOr(result, versionOverlay);
        return result;
    }
}