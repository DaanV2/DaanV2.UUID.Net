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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Boolean Equals(UUID other) {
        return this._Data.AsUInt64() == other._Data.AsUInt64();
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveOptimization)]
    public override Int32 GetHashCode() {
        Vector128<Int32> d = this._Data.AsInt32();
        return d[0] ^ d[1] ^ d[2] ^ d[3];
    }

    /// <inheritdoc/>
    public override String ToString() {
        return Format.ToString(this._Data);
    }

    /// <summary>Parses the given string into a <see cref="UUID"/></summary>
    /// <param name="uuid">The string uuid representation to parse</param>
    /// <returns>A <see cref="UUID"/></returns>
    public static UUID Parse(String uuid) {
        return Parse(uuid.AsSpan());
    }

    /// <summary>Parses the given characters into a <see cref="UUID"/></summary>
    /// <param name="uuid">The characters uuid representation to parse</param>
    /// <returns>A <see cref="UUID"/></returns>
    public static UUID Parse(ReadOnlySpan<Char> uuid) {
        Vector128<Byte> data = Format.Parse(uuid);
        return new UUID(data);
    }
}