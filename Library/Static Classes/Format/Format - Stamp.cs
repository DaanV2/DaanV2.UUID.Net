using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <summary>Uses the given mask and overlay to insert the version and variant onto the data</summary>
    /// <param name="versionMask">The mask of the versions and variants</param>
    /// <param name="versionOverlay">The overlay of the versions and variants</param>
    /// <param name="data">The data to stamp the version and variant onto</param>
    /// <returns>Returns a <see cref="Vector128{T}"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<Byte> StampVersion(Vector128<Byte> versionMask, Vector128<Byte> versionOverlay, ReadOnlySpan<Byte> data) {
        var temp = Vector128.Create(data);
        return StampVersion(versionMask, versionOverlay, temp);
    }

    /// <inheritdoc cref="StampVersion(Vector128{Byte},Vector128{Byte},ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<Byte> StampVersion(Vector128<Byte> versionMask, Vector128<Byte> versionOverlay, Vector128<Byte> data) {
        var result = Vector128.BitwiseAnd(data, versionMask);
        result = Vector128.BitwiseOr(result, versionOverlay);
        return result;
    }
}