using DaanV2.UUID;

namespace Tests;
public sealed partial class UUIDtests {
    [Theory(DisplayName = "Hashcode should be consistent for every request")]
    [InlineData("a6e9b95d-21db-41c3-9c86-19d919788776")]
    [InlineData("b4404ed5-ec02-4027-a8e1-6fcb16044fc4")]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void TestHashcode(String uuid) {
        var u = UUID.Parse(uuid);

        Int32 hashcode = u.GetHashCode();

        //Consistenty check
        for (Int32 I = 0; I < 20; I++) {
            Int32 h = u.GetHashCode();
            Assert.Equal(hashcode, h);
        }
    }
}