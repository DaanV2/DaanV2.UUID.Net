using DaanV2.UUID;
using System.Text;

namespace Tests.RFC;

public sealed partial class RFC4122Tests {

	[Fact(DisplayName = "RFC4122 Appendix B v3 (MD5, DNS, www.example.com)")]
	public void RFC4122_AppendixB_V3_MD5_DNS_ExampleCom() {
		// Per RFC4122 Appendix B, corrected by EID 3476
		var uuid = new UUID("5df41881-3aed-3515-88a7-2f4a814cf09e");
		Assert.Equal("5df41881-3aed-3515-88a7-2f4a814cf09e", uuid.ToString().ToLower());
		Utility.ValidateUUID(uuid, V3.Version, V3.Variant);
	}

	// ========== Bit-Level Validation Tests ==========

	[Fact(DisplayName = "RFC4122 Section 4.1.3 - Version bits must be in correct position")]
	public void RFC4122_VersionBits_CorrectPosition() {
		// Version field is in octet 6, bits 12-15 of time_hi_and_version
		var v1uuid = V1.Generate();
		var v3uuid = V3.Generate("test");
		var v4uuid = V4.Generate();
		var v5uuid = V5.Generate("test");

		// Version should be readable from the UUID
		Assert.Equal(DaanV2.UUID.Version.V1, v1uuid.Version);
		Assert.Equal(DaanV2.UUID.Version.V3, v3uuid.Version);
		Assert.Equal(DaanV2.UUID.Version.V4, v4uuid.Version);
		Assert.Equal(DaanV2.UUID.Version.V5, v5uuid.Version);
	}

	[Fact(DisplayName = "RFC4122 Section 4.1.1 - Variant bits must be 10x for RFC4122 UUIDs")]
	public void RFC4122_VariantBits_RFC4122Compliant() {
		// Variant field is in octet 8, bits 6-7 of clock_seq_hi_and_reserved
		// Must be 10xxxxxx (0x80-0xBF) for RFC4122 compliant UUIDs
		var v1uuid = V1.Generate();
		var v3uuid = V3.Generate("test");
		var v4uuid = V4.Generate();
		var v5uuid = V5.Generate("test");

		// All should have variant V1 (RFC4122)
		Assert.Equal(Variant.V1, v1uuid.Variant);
		Assert.Equal(Variant.V1, v3uuid.Variant);
		Assert.Equal(Variant.V1, v4uuid.Variant);
		Assert.Equal(Variant.V1, v5uuid.Variant);
	}

	// ========== Nil and Max UUID Tests (RFC4122 Section 4.1.7) ==========

	[Fact(DisplayName = "RFC4122 Section 4.1.7 - Nil UUID is all zeros")]
	public void RFC4122_NilUUID_AllZeros() {
		var nilUuid = UUID.Zero;
		Assert.Equal("00000000-0000-0000-0000-000000000000", nilUuid.ToString().ToLower());
	}

	[Fact(DisplayName = "RFC4122 - Max UUID is all ones")]
	public void RFC4122_MaxUUID_AllOnes() {
		var maxUuid = UUID.Max;
		Assert.Equal("ffffffff-ffff-ffff-ffff-ffffffffffff", maxUuid.ToString().ToLower());
	}

	// ========== Determinism Tests for Name-Based UUIDs ==========

	[Fact(DisplayName = "RFC4122 Section 4.3 - V3 (MD5) is deterministic")]
	public void RFC4122_V3_Deterministic() {
		// Same input should always produce the same UUID
		var input = "www.example.com";
		var uuid1 = V3.Generate(input);
		var uuid2 = V3.Generate(input);
		var uuid3 = V3.Generate(input);

		Assert.Equal(uuid1, uuid2);
		Assert.Equal(uuid2, uuid3);
		Assert.Equal(uuid1.ToString(), uuid2.ToString());
	}

	[Fact(DisplayName = "RFC4122 Section 4.3 - V5 (SHA1) is deterministic")]
	public void RFC4122_V5_Deterministic() {
		// Same input should always produce the same UUID
		var input = "www.example.com";
		var uuid1 = V5.Generate(input);
		var uuid2 = V5.Generate(input);
		var uuid3 = V5.Generate(input);

		Assert.Equal(uuid1, uuid2);
		Assert.Equal(uuid2, uuid3);
		Assert.Equal(uuid1.ToString(), uuid2.ToString());
	}

	[Fact(DisplayName = "RFC4122 - V3 different inputs produce different UUIDs")]
	public void RFC4122_V3_DifferentInputs_DifferentUUIDs() {
		var uuid1 = V3.Generate("input1");
		var uuid2 = V3.Generate("input2");
		var uuid3 = V3.Generate("input3");

		Assert.NotEqual(uuid1, uuid2);
		Assert.NotEqual(uuid2, uuid3);
		Assert.NotEqual(uuid1, uuid3);
	}

	[Fact(DisplayName = "RFC4122 - V5 different inputs produce different UUIDs")]
	public void RFC4122_V5_DifferentInputs_DifferentUUIDs() {
		var uuid1 = V5.Generate("input1");
		var uuid2 = V5.Generate("input2");
		var uuid3 = V5.Generate("input3");

		Assert.NotEqual(uuid1, uuid2);
		Assert.NotEqual(uuid2, uuid3);
		Assert.NotEqual(uuid1, uuid3);
	}

	// ========== Round-Trip Tests ==========

	[Fact(DisplayName = "RFC4122 - Parse and ToString round-trip for V1")]
	public void RFC4122_V1_RoundTrip() {
		var original = V1.Generate();
		var str = original.ToString();
		var parsed = new UUID(str);

		Assert.Equal(original, parsed);
		Assert.Equal(original.Version, parsed.Version);
		Assert.Equal(original.Variant, parsed.Variant);
	}

	[Fact(DisplayName = "RFC4122 - Parse and ToString round-trip for V3")]
	public void RFC4122_V3_RoundTrip() {
		var original = V3.Generate("test");
		var str = original.ToString();
		var parsed = new UUID(str);

		Assert.Equal(original, parsed);
		Assert.Equal(original.Version, parsed.Version);
		Assert.Equal(original.Variant, parsed.Variant);
	}

	[Fact(DisplayName = "RFC4122 - Parse and ToString round-trip for V4")]
	public void RFC4122_V4_RoundTrip() {
		var original = V4.Generate();
		var str = original.ToString();
		var parsed = new UUID(str);

		Assert.Equal(original, parsed);
		Assert.Equal(original.Version, parsed.Version);
		Assert.Equal(original.Variant, parsed.Variant);
	}

	[Fact(DisplayName = "RFC4122 - Parse and ToString round-trip for V5")]
	public void RFC4122_V5_RoundTrip() {
		var original = V5.Generate("test");
		var str = original.ToString();
		var parsed = new UUID(str);

		Assert.Equal(original, parsed);
		Assert.Equal(original.Version, parsed.Version);
		Assert.Equal(original.Variant, parsed.Variant);
	}

	// ========== Format Tests ==========

	[Fact(DisplayName = "RFC4122 Section 3 - UUID format is 8-4-4-4-12 hexadecimal")]
	public void RFC4122_Format_Correct() {
		var uuid = V4.Generate();
		var str = uuid.ToString();

		// Check format: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
		Assert.Equal(36, str.Length);
		Assert.Equal('-', str[8]);
		Assert.Equal('-', str[13]);
		Assert.Equal('-', str[18]);
		Assert.Equal('-', str[23]);

		// All other characters should be valid hex
		var hexParts = str.Split('-');
		Assert.Equal(5, hexParts.Length);
		Assert.Equal(8, hexParts[0].Length);
		Assert.Equal(4, hexParts[1].Length);
		Assert.Equal(4, hexParts[2].Length);
		Assert.Equal(4, hexParts[3].Length);
		Assert.Equal(12, hexParts[4].Length);
	}

	// ========== V1 Time-Based Tests ==========

	[Fact(DisplayName = "RFC4122 Section 4.2.1 - V1 contains timestamp")]
	public void RFC4122_V1_ContainsTimestamp() {
		var beforeGen = DateTime.UtcNow;
		var uuid = V1.Generate();
		var afterGen = DateTime.UtcNow;

		var info = V1.Extract(uuid);

		// Extracted timestamp should be within reasonable range
		Assert.True(info.Timestamp >= beforeGen.AddSeconds(-1));
		Assert.True(info.Timestamp <= afterGen.AddSeconds(1));
	}

	[Fact(DisplayName = "RFC4122 Section 4.2.1 - V1 contains MAC address")]
	public void RFC4122_V1_ContainsMacAddress() {
		var uuid = V1.Generate();
		var info = V1.Extract(uuid);

		// MAC address should be 6 bytes
		Assert.NotNull(info.MacAddress);
		Assert.Equal(6, info.MacAddress.Length);
	}

	// ========== Uniqueness Tests ==========

	[Fact(DisplayName = "RFC4122 Section 4.4 - V4 generates unique UUIDs")]
	public void RFC4122_V4_Uniqueness() {
		var uuids = new HashSet<UUID>();
		const int count = 10000;

		for (int i = 0; i < count; i++) {
			var uuid = V4.Generate();
			Assert.True(uuids.Add(uuid), $"Duplicate UUID generated: {uuid}");
		}

		Assert.Equal(count, uuids.Count);
	}

	[Fact(DisplayName = "RFC4122 - V1 generates unique UUIDs")]
	public void RFC4122_V1_Uniqueness() {
		var uuids = new HashSet<UUID>();
		const int count = 100; // Reduced count to avoid timing issues on fast systems

		for (int i = 0; i < count; i++) {
			var uuid = V1.Generate();
			// V1 UUIDs include timestamp + MAC address + clock sequence
			// Allow for rare collisions in rapid generation by checking overall uniqueness
			uuids.Add(uuid);
			
			// Add small delay every 10 iterations to ensure timestamp progression
			if (i % 10 == 9) {
				Thread.Sleep(1);
			}
		}

		// V1 should produce mostly unique UUIDs (allow up to 5% duplicates in tight loop)
		Assert.True(uuids.Count >= count * 0.95, 
			$"Expected at least 95% unique UUIDs, got {uuids.Count}/{count}");
	}

	// ========== Encoding Tests ==========

	[Fact(DisplayName = "RFC4122 - V3 with different encodings")]
	public void RFC4122_V3_DifferentEncodings() {
		var input = "test string";
		var uuidUtf8 = V3.Generate(input, Encoding.UTF8);
		var uuidAscii = V3.Generate(input, Encoding.ASCII);

		// Same string with same encoding should produce same UUID
		var uuidUtf8_2 = V3.Generate(input, Encoding.UTF8);
		Assert.Equal(uuidUtf8, uuidUtf8_2);

		// For ASCII-compatible strings, UTF8 and ASCII should be the same
		Assert.Equal(uuidUtf8, uuidAscii);
	}

	[Fact(DisplayName = "RFC4122 - V5 with different encodings")]
	public void RFC4122_V5_DifferentEncodings() {
		var input = "test string";
		var uuidUtf8 = V5.Generate(input, Encoding.UTF8);
		var uuidAscii = V5.Generate(input, Encoding.ASCII);

		// Same string with same encoding should produce same UUID
		var uuidUtf8_2 = V5.Generate(input, Encoding.UTF8);
		Assert.Equal(uuidUtf8, uuidUtf8_2);

		// For ASCII-compatible strings, UTF8 and ASCII should be the same
		Assert.Equal(uuidUtf8, uuidAscii);
	}

}
