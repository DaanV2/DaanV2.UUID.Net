using DaanV2.UUID;

namespace Tests;
public sealed partial class ConvertTest {
    [Theory(DisplayName = "Converting to and from GUID")]
    [InlineData("637f06a1-325b-4a81-81bf-f3e0bcabc884")]
    [InlineData("eab23486-1f3a-44c3-a927-193c9e49ace2")]
    [InlineData("2a7e85ce-e301-4cef-9c47-8b1a6e2805bf")]
    [InlineData("54d0c77e-9073-4f6e-b622-28a8a76ccdb0")]
    public void Guid(String uuid) {
        var g = new Guid(uuid);
        var u = new UUID(uuid);

        Assert.Equal(g.ToString(), uuid);
        Assert.Equal(u.ToString(), uuid);

        var c = UUID.From(g);

        Assert.Equal(u, c);

        var d = u.ToGuid();

        Assert.Equal(d, g);
        Assert.Equal<UUID>(u, g);
        Assert.True(u == g);

        var imp = (UUID)g;
        Assert.Equal(imp, u);
    }
}
