using System.Runtime.Intrinsics;
using System.Security.Cryptography;

namespace DaanV2.UUID;

public static partial class V2 {
    /// <inheritdoc cref="V2.Version"/>
    public const Version Version = DaanV2.UUID.Version.V2;
    /// <inheritdoc cref="V2.Variant"/>
    public const Variant Variant = DaanV2.UUID.Variant.V1;
    /// <summary>The prefered minimum data length for chunking bytes array</summary>
    public const Int32 MinimumDataLength = MD5.HashSizeInBytes;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V2.Version, V2.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V2.Version, V2.Variant);
}
