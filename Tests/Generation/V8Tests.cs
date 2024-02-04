using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V8Tests {
    // From https://www.ietf.org/archive/id/draft-peabody-dispatch-new-uuid-format-04.html#name-example-of-a-uuidv8-value
    [Theory(DisplayName = "Given a known vector, will generate the expected UUID")]
    [InlineData(0x320C3D4DCC00, 0x75B, 0xEC932D5F69181C0, "320c3d4d-cc00-875b-8ec9-32d5f69181c0")]
    public void TestVector(UInt64 customA, UInt16 customB, UInt64 customC, String expected) {
        UUID u = V8.Generate(customA, customB, customC);
        Assert.Equal(expected, u.ToString());

        Utility.ValidateUUID(u, V8.Version, V8.Variant);

        (UInt64 bits48, UInt16 bits12, UInt64 bits62) = V8.Extract(u);
        Assert.Equal(customA, bits48);
        Assert.Equal(customB, bits12);
        Assert.Equal(customC, bits62);
    }

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
