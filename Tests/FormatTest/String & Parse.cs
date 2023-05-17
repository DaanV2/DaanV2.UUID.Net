using DaanV2.UUID;

namespace Tests;

public sealed partial class FormatTest {

    [Fact(DisplayName = "ToString works")]
    public void TestToString() {
        UUID uuid = Utillity.PinnedUUIDData();
        Utillity.ValidateUUID(uuid);

        // Value has been determined after testing and now here pinned.
        Assert.Equal(Utillity.PinnedUUID, uuid.ToString());
    }

    [Fact(DisplayName = "UUID toString and parsing back to UUID should result in the same UUID")]
    public void TestParse() {
        UUID uuid = Utillity.PinnedUUIDData();

        Utillity.ValidateUUID(uuid);
        String Temp = uuid.ToString();
        var Temp2 = UUID.Parse(Temp);
        Assert.Equal(uuid, Temp2);

        Utillity.ValidateUUID(uuid);
        Utillity.ValidateUUID(Temp2);

        //Should have the same hashcode
        Assert.Equal(uuid.GetHashCode(), Temp2.GetHashCode());
    }

}