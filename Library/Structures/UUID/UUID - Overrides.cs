using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID : IEquatable<UUID> {
    /// <inheritdoc/>
    public override Boolean Equals(Object? obj) {
        return obj is UUID uUID && this.Equals(uUID);
    }

    /// <inheritdoc/>
    public Boolean Equals(UUID other) {
        return this._Data.AsUInt64().Equals(other._Data.AsUInt64());
    }

    /// <inheritdoc/>
    public override Int32 GetHashCode() {
        return this._Data.GetHashCode();
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