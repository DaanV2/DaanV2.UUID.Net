using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V3Tests {
    [Fact(DisplayName = "When generating with specific data returns expected result")]
    public void TestSpecific1() {
        String data = "DaanV2.UUID;DaanV2.UUID;";
        UUID uuid = V3.Generate(data);

        Utility.ValidateUUID(uuid, V3.Version, V3.Variant);
        Assert.Equal("89445ea6-f5d7-35aa-9d39-b589895bdcd6", uuid.ToString());
    }

    [Theory(DisplayName = "When batch generating, will always return unique UUIDs")]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void TestBatchUnique(Int32 Amount) {
        Int32 byteCount = Amount * V3.MinimumDataLength / 2;
        Byte[] data = new Byte[byteCount];
        Random.Shared.NextBytes(data);
        //Data to hex
        String Hex = BitConverter.ToString(data).Replace("-", String.Empty);

        UUID[] UUIDs = V3.Batch(Hex);
        Assert.Equal(Amount, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            Utility.ValidateUUID(UUIDs[i], V3.Version, V3.Variant);

            for (Int32 j = 0; j < UUIDs.Length; j++) {
                if (i == j) {
                    continue;
                }

                Assert.NotEqual(UUIDs[i], UUIDs[j]);
            }
        }
    }
}
