using System.Runtime.CompilerServices;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>Compares the given two <see cref="UUID"/> to see if they are equal</summary>
    /// <param name="left">The first UUID to compare</param>
    /// <param name="right">The second UUID to compare</param>
    /// <returns>True or false depending whenever or not </returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static Boolean operator ==(UUID left, UUID right) {
        return left.Equals(right);
    }

    /// <summary>Compares the given two <see cref="UUID"/> to see if they are not equal</summary>
    /// <param name="left">The first UUID to compare</param>
    /// <param name="right">The second UUID to compare</param>
    /// <returns>True or false depending whenever or not </returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static Boolean operator !=(UUID left, UUID right) {
        return !(left == right);
    }
}