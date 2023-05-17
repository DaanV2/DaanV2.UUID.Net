using DaanV2.UUID;

namespace Tests;

public sealed partial class FormatTest {
    [Theory(DisplayName = "Int <---> version")]
    [InlineData(0, Variant.V0)]
    [InlineData(1, Variant.V1)]
    [InlineData(2, Variant.V2)]
    [InlineData(3, Variant.V3)]
    public void VersionIntToVersion(Int32 input, Variant expected) {
        var actual = Format.ToVariant(input);
        Assert.Equal(expected, actual);
        Int32 back = Format.ToInt32(actual);
        Assert.Equal(input, back);
    }
}