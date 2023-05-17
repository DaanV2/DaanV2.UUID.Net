using DaanV2.UUID;

namespace Tests;

public partial class ZeroTest {
    [Fact(DisplayName ="UUID.Zero is really zero")]
    public void ZeroIsReallyZero() {
        UUID nil = UUID.Zero;
        String str = nil.ToString();

        Assert.True(str == "00000000-0000-0000-0000-000000000000", "Nill UUID is not an proper nill uuid");
    }
}
