using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {

    /// <summary>The mask to cut out the version & variant</summary>
    /// <returns></returns>
    internal static Vector128<Byte> VersionVariantMask(Version version, Variant variant) {
        Vector128<Byte> mask = Vector128<Byte>.Zero;

        //Set version bits
        mask = Vector128.WithElement(mask, VERSION_BYTE_INDEX, (Byte)version.GetMask());
        mask = Vector128.WithElement(mask, VARIANT_BYTE_INDEX, (Byte)variant.GetMask());

        return mask;
    }

    /// <summary>The mask to cut out everything but the version or variant</summary>
    /// <returns></returns>
    internal static Vector128<Byte> VersionVariantMaskNot(Version version, Variant variant) {
        return ~VersionVariantMask(version, variant);
    }

    internal static Vector128<Byte> CreateVersionVariantOverlayer(Version version, Variant variant) {
        Vector128<Byte> mask = Vector128<Byte>.Zero;

        //Set version bits
        mask = Vector128.WithElement(mask, VERSION_BYTE_INDEX, (Byte)version);
        mask = Vector128.WithElement(mask, VARIANT_BYTE_INDEX, (Byte)variant);

        return mask;
    }
}