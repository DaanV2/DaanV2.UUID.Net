
// Copyright (c) 2024 IETF Trust and the persons identified as the document authors. All rights reserved.
//
// This code is subject to BCP 78 and the IETF Trust's Legal Provisions Relating to IETF Documents (https://trustee.ietf.org/license-info) in effect on the date of publication of RFC 9562.
// Code Components extracted from RFC 9562 must include Revised BSD License text as described in Section 4.e of the Trust Legal Provisions and are provided without warranty as described in the Revised BSD License.
//
// This code was derived from IETF RFC 9562. Please reproduce this note if possible.
using System.Net.NetworkInformation;

namespace DaanV2.UUID;

/// <summary>The <see cref="UUID"/> version that is based around timestamps and macaddress</summary>
public static partial class V6 {
    static V6() {
        _EmptyMacAddress = new Byte[6];
        Random.Shared.NextBytes(_EmptyMacAddress);
    }
}