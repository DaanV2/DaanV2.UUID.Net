using DaanV2.UUID;

namespace Tests.Generation;
public sealed partial class V4Tests {
    [Fact(DisplayName = "Can generate a single valid UUID")]
    public void TestUUID() {
        UUID UUID = V4.Generate();
        Utility.ValidateUUID(UUID, V4.Version, V4.Variant);
    }

    [Fact(DisplayName = "Can generate a single valid UUID with a supplied random")]
    public void TestUUIDRandom() {
        UUID UUID = V4.Generate(new Random());
        Utility.ValidateUUID(UUID, V4.Version, V4.Variant);
    }

    [Fact(DisplayName = "Can generate a batch of UUIDs")]
    public void TestUUIDBatch() {
        UUID[] UUIDs = V4.Batch(100);
        Assert.Equal(100, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            Utility.ValidateUUID(UUIDs[i], V4.Version, V4.Variant);
        }
    }

    [Fact(DisplayName = "Can generate a large batch of UUIDs")]
    public void TestUUIDLargeBatch() {
        UUID[] UUIDs = V4.Batch(1000_000);
        Assert.Equal(1000_000, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            Utility.ValidateUUID(UUIDs[i], V4.Version, V4.Variant);
        }
    }

    [Fact(DisplayName = "Can generate a batch of UUIDs with a supplied random")]
    public void TestUUIDBatchRandom() {
        UUID[] UUIDs = V4.Batch(100, new Random());
        Assert.Equal(100, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            Utility.ValidateUUID(UUIDs[i], V4.Version, V4.Variant);
        }
    }

    [Theory(DisplayName = "Can generate a batch of UUIDs from a supplied byte array")]
    [InlineData(10, 0)]
    [InlineData(10, 1)]
    [InlineData(10, 15)]
    [InlineData(100, 0)]
    [InlineData(100, 15)]
    public void TestUUIDBatchBytes(Int32 Amount, Int32 Additional) {
        Byte[] Bytes = new Byte[(Format.UUID_BYTE_LENGTH * Amount) + Additional];
        var R = new Random();
        R.NextBytes(Bytes);

        UUID[] UUIDs = V4.Batch(Bytes);
        Assert.Equal(Amount, UUIDs.Length);

        for (Int32 i = 0; i < UUIDs.Length; i++) {
            Utility.ValidateUUID(UUIDs[i], V4.Version, V4.Variant);
        }
    }

    [Theory(DisplayName = "When generating a large set of UUIDs, will always return unique UUIDs")]
    [InlineData(10_000)]
    [InlineData(100_000)]
    [InlineData(1000_000)]
    public void TestUUIDBatchUnique(Int32 Amount) {
        UUID[] UUIDs = V4.Batch(Amount);
        Assert.Equal(Amount, UUIDs.Length);

        var counters = new Dictionary<UUID, Int32>(UUIDs.Length);
        foreach (UUID u in UUIDs) {
            if (counters.TryGetValue(u, out Int32 c)) {
                Assert.True(c > 1, "UUIDs are not unique");
                counters[u] = c + 1;
            }
            else {
                counters.Add(u, 1);
            }
        }
    }

    [Fact(DisplayName = "Stream handling should be the same as the array")]
    public void TestUUIDStream() {
        Byte[] data = new Byte[32];
        Random.Shared.NextBytes(data);

        UUID expected = DaanV2.UUID.V4.Generate(data);

        using (var stream = new MemoryStream(data)) {
            UUID actual = DaanV2.UUID.V4.Generate(stream);

            Assert.Equal(expected, actual);
        }
    }
}
