using System.Net.NetworkInformation;

namespace DaanV2.UUID;

public static partial class V2 {

    /// <inheritdoc cref="V1.GetMacAddress"/>
    public static PhysicalAddress? GetMacAddress() {
        return V1.GetMacAddress();
    }

    /// <inheritdoc cref="V1.GetMacAddressBytes"/>
    public static Byte[] GetMacAddressBytes() {
        return V1.GetMacAddressBytes();
    }
}