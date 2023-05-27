using System.Text.RegularExpressions;
using DaanV2.UUID;

namespace Tests;

public partial class Utillity {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="version"></param>
    /// <param name="variant"></param>
    public static void ValidateUUID(UUID data, DaanV2.UUID.Version version, Variant variant) {
        //Does not validate version and variant
        ValidateUUID(data);

        Assert.Equal(version, data.Version);
        Assert.Equal(variant, data.Variant);
    }

    public static void ValidateUUID(UUID data) {
        //Does not validate version and variant
        String Temp = data.ToString();
        Assert.True(
            MyRegex().IsMatch(Temp),
            $"uuid doesn't match pattern: '{Temp}'");
    }

    public static void ValidateUUID(IEnumerable<UUID> data, DaanV2.UUID.Version version, Variant variant) {
        foreach (UUID Item in data) {
            ValidateUUID(Item, version, variant);
        }
    }

    public static void ValidateUUID(IEnumerable<UUID> data) {
        foreach (UUID Item in data) {
            ValidateUUID(Item);
        }
    }

    [GeneratedRegex("\\b[0-9a-f]{8}\\b-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-\\b[0-9a-f]{12}\\b")]
    private static partial Regex MyRegex();
}
