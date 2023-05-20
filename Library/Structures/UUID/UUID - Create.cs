using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>Creates a new instance of <see cref="UUID"/> and applies version and variant information. Assumes the given data is RFC compliant</summary>
    /// <param name="version">The version to set</param>
    /// <param name="variant">The variant to set</param>
    /// <param name="data">The data to set for the UUID</param>
    /// <returns>A <see cref="UUID"/></returns>
    public static UUID Create(Version version, Variant variant, Vector128<Byte> data) {
        Vector128<Byte> formatted = Format.Create(version, variant, data);
        return new UUID(formatted);
    }

    /// <summary>Creates a new instance of <see cref="UUID"/> and applies version and variant information. Assumes the given data is RFC compliant</summary>
    /// <param name="version">The version to set</param>
    /// <param name="variant">The variant to set</param>
    /// <param name="data">The data to set for the UUID</param>
    /// <returns>A <see cref="UUID"/></returns>
    public static UUID Create(Version version, Variant variant, ReadOnlySpan<Byte> data) {
        return Create(version, variant, Vector128.Create(data));
    }

    /// <summary>Creates a new instance of <see cref="UUID"/> and applies version and variant information. Assumes the given data is RFC compliant</summary>
    /// <param name="version">The version to set</param>
    /// <param name="variant">The variant to set</param>
    /// <param name="e0">The first part of the <see cref="UUID"/></param>
    /// <param name="e1">The second part of the <see cref="UUID"/></param>
    /// <returns>A <see cref="UUID"/></returns>
    public static UUID Create(Version version, Variant variant, UInt64 e0, UInt64 e1) {
        return Create(version, variant, Vector128.Create(e0, e1).AsByte());
    }
}