using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UUID {
    ///DOLATER <summary>add description for class: UUIDTests</summary>
    public partial class UUIDTests {
        public static void ValidateUUID(DaanV2.UUID.UUID data) {
            String Temp = data;
            Assert.IsTrue(
                Regex.IsMatch(Temp, @"\b[0-9a-f]{8}\b-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-\b[0-9a-f]{12}\b"), 
                $"uuid doesn't match pattern: '{Temp}'");
        }

        public static void ValidateUUID(IEnumerable<DaanV2.UUID.UUID> data) {
            foreach (DaanV2.UUID.UUID Item in data) {
                ValidateUUID(Item);
            }
        }

        public static void ValidateUUID(DaanV2.UUID.UUID[] data) {
            foreach (DaanV2.UUID.UUID Item in data) {
                ValidateUUID(Item);
            }
        }

        public static void ValidateUUID(List<DaanV2.UUID.UUID> data) {
            foreach (DaanV2.UUID.UUID Item in data) {
                ValidateUUID(Item);
            }
        }
    }
}
