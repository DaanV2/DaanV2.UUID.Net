namespace DaanV2.UUID.Structures.Validator;
///DOLATER <summary>add description for class: Validator</summary>
public static partial class Validator
{
    public static bool IsValid(string value)
    {
        if (value.Length != Format.UUID_STRING_LENGTH)
        {
            return false;
        }

        for (int I = 0; I < value.Length; I++)
        {
            if (!IsValidChar(value[I]))
            {
                return false;
            }
        }

        var uuid = UUID.Parse(value);
        return IsValid(uuid);
    }

    /// <summary>Checks whenever or not the given char is a valid UUID char</summary>
    /// <param name="value">The character to check</param>
    /// <returns>True or false depending on whenever or not its valid</returns>
    public static bool IsValidChar(char value)
    {
        if (value is >= '0' and <= '9')
        {
            return true;
        }
        if (value is >= 'a' and <= 'f')
        {
            return true;
        }
        if (value == '-')
        {
            return true;
        }
        return false;
    }

    public static bool IsValid(UUID uuid)
    {
        return IsValidVersionVariant(uuid.Version, uuid.Variant);
    }

    public static bool IsValidVersionVariant(int version, int variant)
    {
        var vers = Format.ToVersion(version);
        var vars = Format.ToVariant(variant);

        return IsValidVersionVariant(vers, vars);
    }

    public static bool IsValidVersionVariant(Version version, Variant variant)
    {
        Version[] Values = Enum.GetValues<Version>();
        if (!Values.Contains(version))
        {
            return false;
        }

        Variant[] Variants = Enum.GetValues<Variant>();
        if (!Variants.Contains(variant))
        {
            return false;
        }

        return true;
    }
}
