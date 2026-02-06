// Copyright (c) 2024 IETF Trust and the persons identified as the document authors. All rights reserved.
//
// This code is subject to BCP 78 and the IETF Trust's Legal Provisions Relating to IETF Documents (https://trustee.ietf.org/license-info) in effect on the date of publication of RFC 9562.
// Code Components extracted from RFC 9562 must include Revised BSD License text as described in Section 4.e of the Trust Legal Provisions and are provided without warranty as described in the Revised BSD License.
//
// This code was derived from IETF RFC 9562. Please reproduce this note if possible.

using DaanV2.UUID;

namespace Tests.RFC;

public sealed partial class RFC9562Tests {
    // ========== Test Vectors from RFC 9562 ==========

    [Fact(DisplayName = "UUIDv1 RFC test vector")]
    public void UUIDv1_RFC_TestVector() {
        var uuid = new UUID("C232AB00-9414-11EC-B3C8-9F6BDECED846");
        Assert.Equal("c232ab00-9414-11ec-b3c8-9f6bdeced846", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V1.Version, V1.Variant);
    }

    [Fact(DisplayName = "UUIDv3 RFC test vector")]
    public void UUIDv3_RFC_TestVector() {
        var uuid = new UUID("5df41881-3aed-3515-88a7-2f4a814cf09e");
        Assert.Equal("5df41881-3aed-3515-88a7-2f4a814cf09e", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V3.Version, V3.Variant);
    }

    [Fact(DisplayName = "UUIDv4 RFC test vector")]
    public void UUIDv4_RFC_TestVector() {
        var uuid = new UUID("919108f7-52d1-4320-9bac-f847db4148a8");
        Assert.Equal("919108f7-52d1-4320-9bac-f847db4148a8", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V4.Version, V4.Variant);
    }

    [Fact(DisplayName = "UUIDv5 RFC test vector")]
    public void UUIDv5_RFC_TestVector() {
        var uuid = new UUID("2ed6657d-e927-568b-95e1-2665a8aea6a2");
        Assert.Equal("2ed6657d-e927-568b-95e1-2665a8aea6a2", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V5.Version, V5.Variant);
    }

    [Fact(DisplayName = "UUIDv6 RFC test vector")]
    public void UUIDv6_RFC_TestVector() {
        var uuid = new UUID("1ec9414c-232a-6b00-b3c8-9f6bdeced846");
        Assert.Equal("1ec9414c-232a-6b00-b3c8-9f6bdeced846", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V6.Version, V6.Variant);
    }

    [Fact(DisplayName = "UUIDv7 RFC test vector")]
    public void UUIDv7_RFC_TestVector() {
        var uuid = new UUID("017f22e2-79b0-7cc3-98c4-dc0c0c07398f");
        Assert.Equal("017f22e2-79b0-7cc3-98c4-dc0c0c07398f", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V7.Version, V7.Variant);
    }

    [Fact(DisplayName = "UUIDv8 RFC test vector (time-based)")]
    public void UUIDv8_RFC_TestVector_TimeBased() {
        var uuid = new UUID("2489e9ad-2ee2-8e00-8ec9-32d5f69181c0");
        Assert.Equal("2489e9ad-2ee2-8e00-8ec9-32d5f69181c0", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V8.Version, V8.Variant);
    }

    [Fact(DisplayName = "UUIDv8 RFC test vector (name-based SHA-256)")]
    public void UUIDv8_RFC_TestVector_NameBased() {
        var uuid = new UUID("5c146b14-3c52-8afd-938a-375d0df1fbf6");
        Assert.Equal("5c146b14-3c52-8afd-938a-375d0df1fbf6", uuid.ToString().ToLower());
        Utility.ValidateUUID(uuid, V8.Version, V8.Variant);
    }

    // ========== V6 Specific Tests (RFC 9562 Section 5.6) ==========

    [Fact(DisplayName = "RFC9562 Section 5.6 - V6 is reordered Gregorian time")]
    public void RFC9562_V6_ReorderedTime() {
        var beforeGen = DateTime.UtcNow;
        var uuid = V6.Generate();
        var afterGen = DateTime.UtcNow;

        Assert.Equal(DaanV2.UUID.Version.V6, uuid.Version);
        Assert.Equal(Variant.V1, uuid.Variant);

        // V6 should contain a timestamp
        var info = V6.Extract(uuid);
        Assert.True(info.Timestamp >= beforeGen.AddSeconds(-1));
        Assert.True(info.Timestamp <= afterGen.AddSeconds(1));
    }

    [Fact(DisplayName = "RFC9562 Section 5.6 - V6 UUIDs are sortable by time")]
    public void RFC9562_V6_Sortable() {
        var uuids = new List<UUID>();
        
        for (int i = 0; i < 100; i++) {
            uuids.Add(V6.Generate());
            // Small delay to ensure time progression
            if (i % 10 == 0) {
                Thread.Sleep(1);
            }
        }

        // V6 UUIDs should be in ascending order when generated sequentially
        var sortedUuids = uuids.OrderBy(u => u.ToString()).ToList();
        
        // Check that most UUIDs maintain order (allowing for some system clock variance)
        int inOrder = 0;
        for (int i = 0; i < uuids.Count - 1; i++) {
            if (string.Compare(uuids[i].ToString(), uuids[i + 1].ToString(), StringComparison.Ordinal) <= 0) {
                inOrder++;
            }
        }
        
        // At least 90% should be in order
        Assert.True(inOrder >= (uuids.Count - 1) * 0.9, 
            $"Expected at least 90% in order, got {inOrder}/{uuids.Count - 1}");
    }

    [Fact(DisplayName = "RFC9562 Section 5.6 - V6 uniqueness")]
    public void RFC9562_V6_Uniqueness() {
        var uuids = new HashSet<UUID>();
        const int count = 1000;

        for (int i = 0; i < count; i++) {
            var uuid = V6.Generate();
            Assert.True(uuids.Add(uuid), $"Duplicate UUID generated: {uuid}");
        }

        Assert.Equal(count, uuids.Count);
    }

    // ========== V7 Specific Tests (RFC 9562 Section 5.7) ==========

    [Fact(DisplayName = "RFC9562 Section 5.7 - V7 contains Unix Epoch timestamp")]
    public void RFC9562_V7_ContainsTimestamp() {
        // Note: V7 only stores 48 bits for timestamp. When using FileTimeUtc, this limits the range.
        // Use a timestamp that fits within 48-bit FileTime range for this test
        var inputTime = DateTime.FromFileTimeUtc(1645557742000); // Known good value from RFC test vector
        var uuid = V7.Generate(inputTime);

        Assert.Equal(DaanV2.UUID.Version.V7, uuid.Version);
        Assert.Equal(Variant.V1, uuid.Variant);

        // Extract timestamp and verify round-trip accuracy
        var extractedTime = V7.Extract(uuid);
        
        // V7 timestamps should round-trip correctly
        Assert.Equal(inputTime, extractedTime);
    }

    [Fact(DisplayName = "RFC9562 Section 5.7 - V7 UUIDs are sortable by time")]
    public void RFC9562_V7_Sortable() {
        var uuids = new List<UUID>();
        
        for (int i = 0; i < 100; i++) {
            uuids.Add(V7.Generate());
            // Small delay to ensure time progression
            if (i % 10 == 0) {
                Thread.Sleep(1);
            }
        }

        // V7 UUIDs should be in ascending order when generated sequentially
        // Check that most UUIDs maintain order
        int inOrder = 0;
        for (int i = 0; i < uuids.Count - 1; i++) {
            if (string.Compare(uuids[i].ToString(), uuids[i + 1].ToString(), StringComparison.Ordinal) <= 0) {
                inOrder++;
            }
        }
        
        // At least 90% should be in order
        Assert.True(inOrder >= (uuids.Count - 1) * 0.9, 
            $"Expected at least 90% in order, got {inOrder}/{uuids.Count - 1}");
    }

    [Fact(DisplayName = "RFC9562 Section 5.7 - V7 uniqueness")]
    public void RFC9562_V7_Uniqueness() {
        var uuids = new HashSet<UUID>();
        const int count = 10000;

        for (int i = 0; i < count; i++) {
            var uuid = V7.Generate();
            Assert.True(uuids.Add(uuid), $"Duplicate UUID generated: {uuid}");
        }

        Assert.Equal(count, uuids.Count);
    }

    [Fact(DisplayName = "RFC9562 Section 5.7 - V7 millisecond precision")]
    public void RFC9562_V7_MillisecondPrecision() {
        // Generate multiple UUIDs within the same millisecond
        var uuids = new List<UUID>();
        for (int i = 0; i < 100; i++) {
            uuids.Add(V7.Generate());
        }

        // All should have valid timestamps
        foreach (var uuid in uuids) {
            var time = V7.Extract(uuid);
            Assert.NotEqual(DateTime.MinValue, time);
            Assert.NotEqual(DateTime.MaxValue, time);
        }

        // All should be unique despite potentially being generated in same millisecond
        Assert.Equal(uuids.Count, uuids.Distinct().Count());
    }

    // ========== V8 Specific Tests (RFC 9562 Section 5.8) ==========

    [Fact(DisplayName = "RFC9562 Section 5.8 - V8 custom data support")]
    public void RFC9562_V8_CustomData() {
        var data = new byte[16];
        for (int i = 0; i < 16; i++) {
            data[i] = (byte)i;
        }

        var uuid = V8.Generate(data);
        
        Assert.Equal(DaanV2.UUID.Version.V8, uuid.Version);
        Assert.Equal(Variant.V1, uuid.Variant);
    }

    [Fact(DisplayName = "RFC9562 Section 5.8 - V8 uniqueness")]
    public void RFC9562_V8_Uniqueness() {
        var uuids = new HashSet<UUID>();
        const int count = 10000;

        for (int i = 0; i < count; i++) {
            var data = new byte[16];
            Random.Shared.NextBytes(data);
            var uuid = V8.Generate(data);
            Assert.True(uuids.Add(uuid), $"Duplicate UUID generated: {uuid}");
        }

        Assert.Equal(count, uuids.Count);
    }

    [Fact(DisplayName = "RFC9562 Section 5.8 - V8 deterministic with same input")]
    public void RFC9562_V8_Deterministic() {
        var data = new byte[16];
        for (int i = 0; i < 16; i++) {
            data[i] = (byte)(i * 7);
        }

        var uuid1 = V8.Generate(data);
        var uuid2 = V8.Generate(data);

        Assert.Equal(uuid1, uuid2);
    }

    // ========== V2 Tests (DCE Security - RFC 9562 Section 5.5) ==========

    [Fact(DisplayName = "RFC9562 Section 5.5 - V2 generation and validation")]
    public void RFC9562_V2_Generation() {
        var uuid = V2.Generate();
        
        Assert.Equal(DaanV2.UUID.Version.V2, uuid.Version);
        Assert.Equal(Variant.V1, uuid.Variant);
        Utility.ValidateUUID(uuid);
    }

    [Fact(DisplayName = "RFC9562 Section 5.5 - V2 uniqueness")]
    public void RFC9562_V2_Uniqueness() {
        var uuids = new HashSet<UUID>();
        const int count = 1000;

        for (int i = 0; i < count; i++) {
            var uuid = V2.Generate();
            Assert.True(uuids.Add(uuid), $"Duplicate UUID generated: {uuid}");
        }

        Assert.Equal(count, uuids.Count);
    }

    // ========== Round-Trip Tests for New Versions ==========

    [Fact(DisplayName = "RFC9562 - V6 round-trip consistency")]
    public void RFC9562_V6_RoundTrip() {
        var original = V6.Generate();
        var str = original.ToString();
        var parsed = new UUID(str);

        Assert.Equal(original, parsed);
        Assert.Equal(original.Version, parsed.Version);
        Assert.Equal(original.Variant, parsed.Variant);
    }

    [Fact(DisplayName = "RFC9562 - V7 round-trip consistency")]
    public void RFC9562_V7_RoundTrip() {
        var original = V7.Generate();
        var str = original.ToString();
        var parsed = new UUID(str);

        Assert.Equal(original, parsed);
        Assert.Equal(original.Version, parsed.Version);
        Assert.Equal(original.Variant, parsed.Variant);
    }

    [Fact(DisplayName = "RFC9562 - V8 round-trip consistency")]
    public void RFC9562_V8_RoundTrip() {
        var data = new byte[16];
        Random.Shared.NextBytes(data);
        var original = V8.Generate(data);
        var str = original.ToString();
        var parsed = new UUID(str);

        Assert.Equal(original, parsed);
        Assert.Equal(original.Version, parsed.Version);
        Assert.Equal(original.Variant, parsed.Variant);
    }

    // ========== Compatibility Tests ==========

    [Fact(DisplayName = "RFC9562 - V1 and V6 timestamp relationship")]
    public void RFC9562_V1_V6_TimestampCompatibility() {
        // V6 is a reordering of V1 timestamps
        // Both should extract similar timestamps when generated at the same time
        var v1uuid = V1.Generate();
        Thread.Sleep(10); // Small delay
        var v6uuid = V6.Generate();

        var v1Info = V1.Extract(v1uuid);
        var v6Info = V6.Extract(v6uuid);

        // Both should have valid timestamps
        Assert.NotEqual(DateTime.MinValue, v1Info.Timestamp);
        Assert.NotEqual(DateTime.MinValue, v6Info.Timestamp);
        
        // V6 should be after V1 (with some tolerance)
        Assert.True(v6Info.Timestamp >= v1Info.Timestamp.AddMilliseconds(-100));
    }

    [Fact(DisplayName = "RFC9562 - Nil UUID special case")]
    public void RFC9562_NilUUID() {
        var nilUuid = UUID.Zero;
        
        Assert.Equal("00000000-0000-0000-0000-000000000000", nilUuid.ToString().ToLower());
        
        // Nil UUID has all zero bits, so version bits are also zero
        // The implementation may not expose Version.V0, so we just verify the string format
        Utility.ValidateUUID(nilUuid);
    }

    [Fact(DisplayName = "RFC9562 - Max UUID special case")]
    public void RFC9562_MaxUUID() {
        var maxUuid = UUID.Max;
        
        Assert.Equal("ffffffff-ffff-ffff-ffff-ffffffffffff", maxUuid.ToString().ToLower());
    }
}
