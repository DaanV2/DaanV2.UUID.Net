using System.Net.NetworkInformation;

namespace DaanV2.UUID;

/// <summary>The <see cref="UUID"/> version that is based around timestamps and macaddress</summary>
public static partial class V6 {
    static V6() {
        _EmptyMacAddress = new Byte[6];
        Random.Shared.NextBytes(_EmptyMacAddress);
    }
}