using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <summary>The mask to cut out the version & variant</summary>
    /// <returns>Returns a <see cref="Vector128{T}"/></returns>
    public static Vector128<Byte> VersionVariantMask(Version version, Variant variant) {
        Vector128<Byte> mask = Vector128<Byte>.Zero;

        //Set version & variants bits
        mask = Vector128.WithElement(mask, VERSION_BYTE_INDEX, (Byte)version.GetMask());
        mask = Vector128.WithElement(mask, VARIANT_BYTE_INDEX, (Byte)variant.GetMask());

        return mask;
    }

    /// <summary>The mask to cut out everything but the version or variant</summary>
    /// <returns>Returns a <see cref="Vector128{T}"/></returns>
    public static Vector128<Byte> VersionVariantMaskNot(Version version, Variant variant) {
        return ~VersionVariantMask(version, variant);
    }

    /// <summary>Creates a layer that can be overlayed onto another <see cref="Vector128{T}"/> that will now included the set version and variant</summary>
    /// <param name="version">The version to set</param>
    /// <param name="variant">The variant to set</param>
    /// <returns>Returns a <see cref="Vector128{T}"/></returns>
    public static Vector128<Byte> VersionVariantOverlayer(Version version, Variant variant) {
        Vector128<Byte> mask = Vector128<Byte>.Zero;

        //Set version bits
        mask = Vector128.WithElement(mask, VERSION_BYTE_INDEX, (Byte)version);
        mask = Vector128.WithElement(mask, VARIANT_BYTE_INDEX, (Byte)variant);

        return mask;
    }
}