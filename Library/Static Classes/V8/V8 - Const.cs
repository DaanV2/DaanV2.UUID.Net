using System.Runtime.Intrinsics;
using System.Security.Cryptography;

namespace DaanV2.UUID;
public static partial class V8 {
    /// <inheritdoc cref="V1.Version"/>
    public const Version Version = DaanV2.UUID.Version.V8;
    /// <inheritdoc cref="V1.Variant"/>
    public const Variant Variant = DaanV2.UUID.Variant.V1;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V8.Version, V8.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V8.Version, V8.Variant);
}
