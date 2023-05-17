using System.Runtime.Intrinsics;
using DaanV2.UUID;

namespace Tests;
public sealed partial class UUIDtests {
    [Theory(DisplayName = "Version/Variant should be able to set and read")]
    [InlineData(1, 1)]
    [InlineData(4, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 1)]
    [InlineData(5, 2)]
    public void TestVariantVersion(Int32 version, Int32 variant) {
        var vers = Format.ToVersion(version);
        var vari = Format.ToVariant(variant);

        Vector128<Byte> data = Utillity.PinnedUUIDVector();
        var uuid = UUID.Create(vers, vari, data);

        Assert.Equal(vers, uuid.Version);
        Assert.Equal(vari, uuid.Variant);
    }
}