using System.Runtime.Intrinsics;

namespace DaanV2.UUID;
internal static partial class VectorExtension {
    /// <summary>The reverse indexes</summary>
    private static readonly Vector128<Byte> _ReverseIndexes = Vector128.Create((Byte)15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0);

    /// <summary>Reverses the order of the bytes</summary>
    /// <param name="value">The value to reverse</param>
    /// <returns>A <see cref="Vector128{T}"/></returns>
    public static Vector128<Byte> Reverse(this Vector128<Byte> value) {
        return Vector128.Shuffle(value, _ReverseIndexes);
    }
}
