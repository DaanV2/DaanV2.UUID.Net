using System.Runtime.Intrinsics;
using System.Security.Cryptography;

namespace DaanV2.UUID;
public static partial class V5 {
    /// <inheritdoc cref="V1.Version"/>
    public const Version Version = DaanV2.UUID.Version.V5;
    /// <inheritdoc cref="V1.Variant"/>
    public const Variant Variant = DaanV2.UUID.Variant.V1;
    /// <summary>The minimum length that is preferred for the data</summary>
    public const Int32 MinimumDataLength = SHA1.HashSizeInBytes;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V5.Version, V5.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V5.Version, V5.Variant);
}
