using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V6Tests {
    [Fact(DisplayName = "When generating with specific time returns expected result")]
    public void TestSpecific1() {
        var dateTime = new DateTime(2019, 1, 2, 3, 4, 5, DateTimeKind.Utc);
        UUID uuid = V6.Generate(dateTime, (Byte)0);

        Utility.ValidateUUID(uuid, V6.Version, V6.Variant);
        Byte[] macAddress = V6.GetMacAddressBytes();
        String machex = BitConverter.ToString(macAddress).Replace("-", String.Empty).ToLower();

        String str = uuid.ToString();

        Assert.EndsWith($"-{machex}", str);
        Assert.StartsWith("0386c019-e57e-6080-", str);

        V6.Information data = V6.Extract(uuid);
        Assert.Equal(dateTime.Year, data.Timestamp.Year);
        Assert.Equal(dateTime.Month, data.Timestamp.Month);
        Assert.Equal(dateTime.Day, data.Timestamp.Day);
        Assert.Equal(dateTime.Hour, data.Timestamp.Hour);
        Assert.Equal(dateTime.Minute, data.Timestamp.Minute);

        Assert.Equal((Byte)0, data.Nanoseconds);
        Assert.Equal(V6.GetMacAddressBytes(), data.MacAddress);
    }

    [Theory(DisplayName = "When batch generating, will always return unique UUIDs")]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void TestBatchUnique(Int32 Amount) {
        UUID[] UUIDs = V6.Batch(Amount);
        Assert.Equal(Amount, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            Utility.ValidateUUID(UUIDs[i], V6.Version, V6.Variant);

            for (Int32 j = 0; j < UUIDs.Length; j++) {
                if (i == j) {
                    continue;
                }

                Assert.NotEqual(UUIDs[i], UUIDs[j]);
            }
        }
    }
}
