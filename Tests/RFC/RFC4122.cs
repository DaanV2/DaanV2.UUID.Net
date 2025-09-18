using DaanV2.UUID;

namespace Tests.RFC;

public sealed partial class RFC4122Tests {

	[Fact(DisplayName = "RFC4122 Appendix B v3 (MD5, DNS, www.example.com)")]
	public void RFC4122_AppendixB_V3_MD5_DNS_ExampleCom() {
		// Per RFC4122 Appendix B, corrected by EID 3476
		var uuid = new UUID("5df41881-3aed-3515-88a7-2f4a814cf09e");
		Assert.Equal("5df41881-3aed-3515-88a7-2f4a814cf09e", uuid.ToString().ToLower());
		Utility.ValidateUUID(uuid, V3.Version, V3.Variant);
	}

}
