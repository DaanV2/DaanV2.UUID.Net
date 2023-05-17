using DaanV2.UUID;

namespace Tests;

public sealed partial class FormatTest {
    [Theory(DisplayName = "Int <---> variant")]
    [InlineData(0, Variant.V0)]
    [InlineData(1, Variant.V1)]
    [InlineData(2, Variant.V2)]
    [InlineData(3, Variant.V3)]
    public void VariantIntToVariant(Int32 input, Variant expected) {
        var actual = Format.ToVariant(input);
        Assert.Equal(expected, actual);
        Int32 back = Format.ToInt32(actual);
        Assert.Equal(input, back);
    }

    [Theory(DisplayName = "Variant mask")]
    [InlineData(Variant.V0, 0b1000_0000)]
    [InlineData(Variant.V1, 0b1100_0000)]
    [InlineData(Variant.V2, 0b1110_0000)]
    [InlineData(Variant.V3, 0b1110_0000)]
    public void VariantMask(Variant input, UInt32 expectedMask) {
        UInt32 mask = input.GetMask();

        Assert.Equal(expectedMask, mask);
    }
}