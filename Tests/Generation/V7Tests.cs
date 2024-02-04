using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V7Tests {
    // From https://www.ietf.org/archive/id/draft-peabody-dispatch-new-uuid-format-04.html#name-example-of-a-uuidv7-value
    [Fact(DisplayName = "Given a known example, will generate the expected UUID")]
    public void TestVector() {
        var timestamp = DateTime.FromFileTimeUtc(1645557742000);
        UInt16 randA = (UInt16)0xCC3;
        UInt64 randB = (UInt64)0x18C4DC0C0C07398F;

        UUID u = V7.Generate(timestamp, randA, randB);

        Assert.Equal("017f22e2-79b0-7cc3-98c4-dc0c0c07398f", u.ToString());

        Int64 extractedUTC = (Int64)V7.ExtractUtc(u);
        Assert.Equal(timestamp.ToFileTimeUtc(), extractedUTC);

        DateTime extracted = V7.Extract(u);
        Assert.Equal(timestamp, extracted);
    }
}
