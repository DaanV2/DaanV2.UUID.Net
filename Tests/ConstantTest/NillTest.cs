using DaanV2.UUID;

namespace Tests;

public partial class ConstantTest {
    [Fact(DisplayName = "UUID.Zero is really zero")]
    public void ZeroIsReallyZero() {
        UUID nil = UUID.Zero;
        String str = nil.ToString();

        Assert.True(str == "00000000-0000-0000-0000-000000000000", "Nill UUID is not an proper nill uuid");
    }

    [Fact(DisplayName = "UUID.Max is really max")]
    public void MaxIsReallyMax() {
        UUID max = UUID.Max;
        String str = max.ToString();

        Assert.True(str == "ffffffff-ffff-ffff-ffff-ffffffffffff", "Max UUID is not an proper max uuid");
    }
}
