namespace DaanV2.UUID;

/// <summary>
/// A class that converts given data into UUID with the specific version format stamped.
/// Note, Using this class doesn't make the UUID compliant with the RFC 4122 standard.
/// That all depends on the data that is given in combination with the version/variant that this class is set to.
/// </summary>
public partial class Generator {
    /// <summary>Creates a new instance of <see cref="Generator"/></summary>
    /// <param name="version">The version to stamp</param>
    /// <param name="variant">The variant to stamp</param>
    public Generator(Version version, Variant variant) {
        this._Mask = Format.VersionVariantMaskNot(version, variant);
        this._Overlay = Format.VersionVariantOverlayer(version, variant);
    }
}
