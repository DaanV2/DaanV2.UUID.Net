using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V5Tests {
    [Fact(DisplayName = "When generating with specific data returns expected result")]
    public void TestSpecific1() {
        String data = "DaanV2.UUID;DaanV2.UUID;";
        UUID uuid = V5.Generate(data);

        Utility.ValidateUUID(uuid, V5.Version, V5.Variant);
        Assert.Equal("f4f8e8db-6c96-5fa8-b503-d6ebd40cf5f3", uuid.ToString());
    }

    [Theory(DisplayName = "When batch generating, will always return unique UUIDs")]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void TestBatchUnique(Int32 Amount) {
        Int32 byteCount = Amount * V5.MinimumDataLength / 2;
        Byte[] data = new Byte[byteCount];
        Random.Shared.NextBytes(data);
        //Data to hex
        String Hex = BitConverter.ToString(data).Replace("-", String.Empty);

        UUID[] UUIDs = V5.Batch(Hex);
        Assert.Equal(Amount, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            for (Int32 j = 0; j < UUIDs.Length; j++) {
                if (i == j) {
                    continue;
                }

                Assert.NotEqual(UUIDs[i], UUIDs[j]);
            }
        }
    }
}
