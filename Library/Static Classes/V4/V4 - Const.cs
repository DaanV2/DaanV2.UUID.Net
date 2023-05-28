using System.Runtime.Intrinsics;

namespace DaanV2.UUID;
public static partial class V4 {
    public const Version Version = DaanV2.UUID.Version.V4;
    public const Variant Variant = DaanV2.UUID.Variant.V1;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V4.Version, V4.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V4.Version, V4.Variant);
}
