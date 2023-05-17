using DaanV2.UUID;

namespace Tests;
public sealed partial class UUIDtests {
    [Theory(DisplayName = "Equals between UUID work as intented, also for hashcodes")]
    [InlineData("a6e9b95d-21db-41c3-9c86-19d919788776", "a6e9b95d-21db-41c3-9c86-19d919788776")]
    [InlineData("b4404ed5-ec02-4027-a8e1-6fcb16044fc4", "a6e9b95d-21db-41c3-9c86-19d919788776")]
    [InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001")]
    public void TestEquals(String uuidA, String uuidB) {
        var a = UUID.Parse(uuidA);
        var b = UUID.Parse(uuidB);

        if (uuidA == uuidB) {
            Assert.True(a == b);
            Assert.True(a.Equals(b));
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }
        else {
            Assert.True(a != b);
            Assert.False(a.Equals(b));
            Assert.NotEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}