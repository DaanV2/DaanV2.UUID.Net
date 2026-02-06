using System.Runtime.Intrinsics;
using System.Security.Cryptography;

namespace DaanV2.UUID;
public static partial class V7 {
    /// <inheritdoc cref="V1.Version"/>
    public const Version Version = DaanV2.UUID.Version.V7;
    /// <inheritdoc cref="V1.Variant"/>
    public const Variant Variant = DaanV2.UUID.Variant.V1;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V7.Version, V7.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V7.Version, V7.Variant);
    
    /// <summary>Unix epoch: January 1, 1970 00:00:00 UTC</summary>
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    
    /// <summary>Maximum value that can fit in 48 bits (for RFC9562 V7 timestamp)</summary>
    private const UInt64 Max48BitValue = 0xFFFFFFFFFFFF;
}
