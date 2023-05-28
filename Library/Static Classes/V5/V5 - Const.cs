using System.Runtime.Intrinsics;
using System.Security.Cryptography;

namespace DaanV2.UUID;
public static partial class V5 {
    public const Version Version = DaanV2.UUID.Version.V5;
    public const Variant Variant = DaanV2.UUID.Variant.V1;
    public const Int32 MinimumDataLength = SHA1.HashSizeInBytes;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V5.Version, V5.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V5.Version, V5.Variant);
}
