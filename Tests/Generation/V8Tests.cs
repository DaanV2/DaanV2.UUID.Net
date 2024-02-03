using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V8Tests {
    [Theory(DisplayName = "When batch generating, will always return unique UUIDs")]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void TestBatchUnique(Int32 Amount) {
        Int32 byteCount = Amount * UUID.BYTE_LENGTH;
        Byte[] data = new Byte[byteCount];
        Random.Shared.NextBytes(data);

        UUID[] UUIDs = V8.Batch(data);
        Assert.Equal(Amount, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            Utility.ValidateUUID(UUIDs[i], V8.Version, V8.Variant);

            for (Int32 j = 0; j < UUIDs.Length; j++) {
                if (i == j) {
                    continue;
                }

                Assert.NotEqual(UUIDs[i], UUIDs[j]);
            }
        }
    }
}
