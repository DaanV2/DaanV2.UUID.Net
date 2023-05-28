using System.Runtime.Intrinsics;

namespace DaanV2.UUID;
public static partial class V1 {
    /// <summary>this is 
    /// represented by Coordinated Universal Time(UTC) as a count of 100-
    /// nanosecond intervals since 00:00:00.00, 15 October 1582 (the date of
    /// Gregorian reform to the Christian calendar).
    /// </summary>
    public const UInt64 Epoch = 0x01B21DD213814000;

    public const Version Version = DaanV2.UUID.Version.V1;
    public const Variant Variant = DaanV2.UUID.Variant.V1;

    private static readonly Vector128<Byte> _VersionMask = Format.VersionVariantMaskNot(V1.Version, V1.Variant);
    private static readonly Vector128<Byte> _VersionOverlay = Format.VersionVariantOverlayer(V1.Version, V1.Variant);
}
