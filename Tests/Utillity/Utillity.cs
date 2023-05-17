using System.Text.RegularExpressions;
using DaanV2.UUID;

namespace Tests;


public partial class Utillity {
    public static void ValidateUUID(UUID data) {
        //Does not validate version and variant
        String Temp = data.ToString();
        Assert.True(
            Regex.IsMatch(Temp, @"\b[0-9a-f]{8}\b-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-\b[0-9a-f]{12}\b"),
            $"uuid doesn't match pattern: '{Temp}'");
    }

    public static void ValidateUUID(IEnumerable<UUID> data) {
        foreach (UUID Item in data) {
            ValidateUUID(Item);
        }
    }
}
