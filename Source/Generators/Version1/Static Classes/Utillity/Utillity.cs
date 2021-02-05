using System;
using System.Net.NetworkInformation;

namespace DaanV2.UUID.Generators.V1 {
    ///DOLATER <summary>add description for class: Utillity</summary>
    public static partial class Utillity {
        private static PhysicalAddress _Address = null;
        private static Byte[] _AddressBytes = null;

        /// <summary>Looks for the mac address of this instance</summary>
        /// <returns>The mac address</returns>
        public static PhysicalAddress GetMacAddress() {
            if (_Address == null) {
                foreach (NetworkInterface NI in NetworkInterface.GetAllNetworkInterfaces()) {
                    if (NI.NetworkInterfaceType == NetworkInterfaceType.Ethernet && NI.OperationalStatus == OperationalStatus.Up) {
                        _Address = NI.GetPhysicalAddress();

                        break;
                    }
                }
            }

            return _Address;
        }

        /// <summary>Looks for the mac address of this instance</summary>
        /// <returns>The mac address</returns>
        public static Byte[] GetMacAddressBytes() {
            if (_AddressBytes == null) {
                PhysicalAddress Temp = GetMacAddress();

                if (Temp != null) {
                    _AddressBytes = Temp.GetAddressBytes();
                }
            }

            return _AddressBytes;
        }
    }
}
