using System.Runtime.Intrinsics;
using System.Security.Cryptography;

namespace DaanV2.UUID;
public static partial class V3 {
    public const Version Version = DaanV2.UUID.Version.V3;
    public const Variant Variant = DaanV2.UUID.Variant.V1;
    public const Int32 MinimumDataLength = MD5.HashSizeInBytes;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V3.Version, V3.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V3.Version, V3.Variant);
}
