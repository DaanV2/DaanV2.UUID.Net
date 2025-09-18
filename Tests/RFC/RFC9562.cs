// Copyright (c) 2024 IETF Trust and the persons identified as the document authors. All rights reserved.
//
// This code is subject to BCP 78 and the IETF Trust's Legal Provisions Relating to IETF Documents (https://trustee.ietf.org/license-info) in effect on the date of publication of RFC 9562.
// Code Components extracted from RFC 9562 must include Revised BSD License text as described in Section 4.e of the Trust Legal Provisions and are provided without warranty as described in the Revised BSD License.
//
// This code was derived from IETF RFC 9562. Please reproduce this note if possible.

using DaanV2.UUID;

namespace Tests.RFC;

public sealed partial class RFC9562Tests {
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
}
