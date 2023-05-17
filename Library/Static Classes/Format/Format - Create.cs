using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <param name="variant"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Vector128<Byte> Create(Version version, Variant variant, ReadOnlySpan<Byte> data) {
        var temp = Vector128.Create(data);
        return Create(version, variant, temp);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <param name="variant"></param>
    /// <param name="e0"></param>
    /// <param name="e1"></param>
    /// <returns></returns>
    public static Vector128<Byte> Create(Version version, Variant variant, UInt64 e0, UInt64 e1) {
        var temp = Vector128.Create(e0, e1).AsByte();
        return Create(version, variant, temp);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <param name="variant"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Vector128<Byte> Create(Version version, Variant variant, Vector128<Byte> data) {
        Vector128<Byte> mask = VersionVariantMaskNot(version, variant);
        Vector128<Byte> overlay = CreateVersionVariantOverlayer(version, variant);

        return StampVersion(mask, overlay, data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector128<Byte> StampVersion(Vector128<Byte> versionMask, Vector128<Byte> versionOverlay, Vector128<Byte> data) {
        var result = Vector128.BitwiseAnd(data, versionMask);
        result = Vector128.BitwiseOr(result, versionOverlay);
        return result;
    }
}