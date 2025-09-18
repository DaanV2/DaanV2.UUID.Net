using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V2Tests {
    [Fact(DisplayName = "When generating with specific time returns expected result")]
    public void TestSpecific1() {
        var dateTime = new DateTime(2019, 1, 2, 3, 4, 5, DateTimeKind.Utc);
        UUID uuid = V2.Generate(dateTime, 0, V2.GetMacAddressBytes());

        Utility.ValidateUUID(uuid, V2.Version, V2.Variant);
        Byte[] macAddress = V2.GetMacAddressBytes();
        String machex = BitConverter.ToString(macAddress).Replace("-", String.Empty).ToLower();

        String str = uuid.ToString();

        // V2 string format may differ, so only check length and mac ending
        Assert.EndsWith($"-{machex}", str);
        Assert.Equal(36, str.Length);

        V2.Information data = V2.Extract(uuid);
        Assert.Equal(dateTime, data.Timestamp);
        Assert.Equal(0u, data.LocalIdentifier);
        Assert.Equal(V2.GetMacAddressBytes(), data.MacAddress);
    }

    [Theory(DisplayName = "When batch generating, will always return unique UUIDs")]
    [InlineData(10)]
    public void TestBatchUnique(Int32 Amount) {
        UUID[] UUIDs = V2.Batch(Amount);
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
