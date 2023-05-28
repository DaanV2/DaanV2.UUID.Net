namespace DaanV2.UUID.Structures.Validator;
/// <summary>The class that helps with validating <see cref="UUID"/> in either data format or string format</summary>
public static partial class Validator {
    /// <summary>Checks whenever or not the given UUID is valid</summary>
    /// <param name="value">The uuid to check</param>
    /// <returns>True or false depending or not if the UUID is valid</returns>
    public static Boolean IsValid(String value) {
        if (value.Length != Format.UUID_STRING_LENGTH) {
            return false;
        }

        for (Int32 I = 0; I < value.Length; I++) {
            if (!IsValidChar(value[I])) {
                return false;
            }
        }

        if (UUID.TryParse(value, out UUID uuid)) {
            return IsValid(uuid);
        }

        return false;
    }

    /// <summary>Checks whenever or not the given char is a valid UUID char</summary>
    /// <param name="value">The character to check</param>
    /// <returns>True or false depending on whenever or not its valid</returns>
    public static Boolean IsValidChar(Char value) {
        if (value is >= '0' and <= '9') {
            return true;
        }
        if (value is >= 'a' and <= 'f') {
            return true;
        }
        if (value == '-') {
            return true;
        }
        return false;
    }

    /// <summary>Checks if the given <see cref="UUID"/> is valid or not</summary>
    /// <param name="uuid">The <see cref="UUID"/> to check</param>
    /// <returns>True or false depending on whenever or not its valid</returns>
    public static Boolean IsValid(UUID uuid) {
        return IsValidVersionVariant(uuid.Version, uuid.Variant);
    }

    /// <summary>Checks if the given version and variant integer values are compatible with <see cref="UUID"/></summary>
    /// <param name="version">The <see cref="UUID"/> version value</param>
    /// <param name="variant">The <see cref="UUID"/> variant value</param>
    /// <returns>True or false depending on whenever or not its valid</returns>
    public static Boolean IsValidVersionVariant(Int32 version, Int32 variant) {
        Version vers;
        Variant vars;
        try {
            vers = Format.ToVersion(version);
            vars = Format.ToVariant(variant);
        }
        catch (Exception) {
            return false;
        }

        return IsValidVersionVariant(vers, vars);
    }

    /// <summary>Checks if the given version and variant values are compatible with <see cref="UUID"/></summary>
    /// <param name="version">The <see cref="UUID"/> version value</param>
    /// <param name="variant">The <see cref="UUID"/> variant value</param>
    /// <returns>True or false depending on whenever or not its valid</returns>
    public static Boolean IsValidVersionVariant(Version version, Variant variant) {
        Version[] Values = Enum.GetValues<Version>();
        if (!Values.Contains(version)) {
            return false;
        }

        Variant[] Variants = Enum.GetValues<Variant>();
        if (!Variants.Contains(variant)) {
            return false;
        }

        return true;
    }
}
