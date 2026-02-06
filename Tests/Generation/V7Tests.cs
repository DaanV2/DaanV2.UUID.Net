using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V7Tests {
    // From https://www.ietf.org/archive/id/draft-peabody-dispatch-new-uuid-format-04.html#name-example-of-a-uuidv7-value
    [Fact(DisplayName = "Given a known example, will generate the expected UUID")]
    public void TestVector() {
        // RFC9562 test vector: UUID 017f22e2-79b0-7cc3-98c4-dc0c0c07398f
        // First 48 bits are Unix milliseconds: 0x017f22e279b0 = 1645557742000
        // This is 2022-02-22 19:22:22 UTC
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var timestamp = unixEpoch.AddMilliseconds(1645557742000);
        
        UInt16 randA = (UInt16)0xCC3;
        UInt64 randB = (UInt64)0x18C4DC0C0C07398F;

        UUID u = V7.Generate(timestamp, randA, randB);

        Assert.Equal("017f22e2-79b0-7cc3-98c4-dc0c0c07398f", u.ToString());

        UInt64 extractedMs = V7.ExtractUtc(u);
        Assert.Equal(1645557742000UL, extractedMs);

        DateTime extracted = V7.Extract(u);
        Assert.Equal(timestamp, extracted);
    }
}
