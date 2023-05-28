using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID : IEquatable<UUID> {
    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override Boolean Equals(Object? obj) {
        return obj is UUID uUID && this.Equals(uUID);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public Boolean Equals(UUID other) {
        return this._Data == other._Data;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveOptimization)]
    public override Int32 GetHashCode() {
        Vector128<Int32> d = this._Data.AsInt32();
        return d[0] ^ d[1] ^ d[2] ^ d[3];
    }
}