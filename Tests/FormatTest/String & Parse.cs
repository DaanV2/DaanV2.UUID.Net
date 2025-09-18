using DaanV2.UUID;

namespace Tests;

public sealed partial class FormatTest {

    [Fact(DisplayName = "ToString works")]
    public void TestToString() {
        UUID uuid = Utility.PinnedUUIDData();
        Utility.ValidateUUID(uuid);

        // Value has been determined after testing and now here pinned.
        Assert.Equal(Utility.PinnedUUID, uuid.ToString());
    }

    [Fact(DisplayName = "UUID toString and parsing back to UUID should result in the same UUID")]
    public void TestParse() {
        UUID uuid = Utility.PinnedUUIDData();

        Utility.ValidateUUID(uuid);
        String Temp = uuid.ToString();
        var Temp2 = UUID.Parse(Temp);
        Assert.Equal(uuid, Temp2);

        Utility.ValidateUUID(uuid);
        Utility.ValidateUUID(Temp2);

        //Should have the same hashcode
        Assert.Equal(uuid.GetHashCode(), Temp2.GetHashCode());
    }

    [Theory()]
    [InlineData("c232ab00-9414-11ec-b3c8-9F6BDECED846")]
    [InlineData("c232ab00-9414-11ec-b3c8-9f6bdeced846")]
    [InlineData("C232AB00-9414-11EC-B3C8-9F6BDECED846")]
    public void TestSpecific(String data) {
        var tmp = UUID.Parse(data);
        String back = tmp.ToString();
        Assert.Equal(back, data.ToLower());

        Utility.ValidateUUID(tmp);
    }

    [Theory()]
    [MemberData(nameof(Characters))]
    public void TestSpecificCharacters(Char value) {
        String data = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".Replace('x', value);
        var tmp = UUID.Parse(data);
        String back = tmp.ToString();
        Assert.Equal(back, data.ToLower());

        Utility.ValidateUUID(tmp);
    }

    public static IEnumerable<Object[]> Characters {
        get {
            String chars = "abcdefABCDEF0123456789";
            var result = new List<Object[]>();

            foreach (Char c in chars) {
                result.Add(new Object[] { c });
            }

            return result;
        }

    }

}