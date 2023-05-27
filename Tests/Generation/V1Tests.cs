using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V1Tests {
    [Fact(DisplayName = "When generating with specific time returns expected result")]
    public void TestSpecific1() {
        var dateTime = new DateTime(2019, 1, 2, 3, 4, 5, DateTimeKind.Utc);
        UUID uuid = V1.Generate(dateTime, (Byte)0);

        Byte[] macAddress = V1.GetMacAddressBytes();
        String machex = BitConverter.ToString(macAddress).Replace("-", String.Empty).ToLower();

        Assert.Equal($"e57e8080-c019-1386-8300-{machex}", uuid.ToString());

        V1.Information data = V1.Extract(uuid);
        Assert.Equal(dateTime, data.Timestamp);
        Assert.Equal((Byte)0, data.Nanoseconds);
        Assert.Equal(V1.GetMacAddressBytes(), data.MacAddress);
    }

    [Theory(DisplayName = "When batch generating, will always return unique UUIDs")]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void TestBatchUnique(Int32 Amount) {
        UUID[] UUIDs = V1.GenerateBatch(Amount);
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
