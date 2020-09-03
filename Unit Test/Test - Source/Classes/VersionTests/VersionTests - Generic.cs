using System;
using DaanV2.UUID;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.UUID;

namespace Unit_Test {
    [TestClass]
    public partial class VersionTests {
        [TestMethod()]
        public void TestAll() {
            Int32[] Versions = UUIDFactory.GetAvailableVersion();
            Int32 CurVersion;
            Int32 CurVariant;

            for (Int32 VersionIndex = 0; VersionIndex < Versions.Length; VersionIndex++) {
                CurVersion = Versions[VersionIndex];
                Int32[] Variants = UUIDFactory.GetAvailableVariants(Versions[VersionIndex]);

                for (Int32 VariantIndex = 0; VariantIndex < Variants.Length; VariantIndex++) {
                    CurVariant = Variants[VariantIndex];

                    UUID ID = UUIDFactory.CreateUUID(CurVersion, CurVariant);
                    UUIDTests.ValidateUUID(ID);

                    Assert.IsTrue(ID.GetVersion() == CurVersion, $"Tried to generate {CurVersion}:{CurVariant} but got version {ID.GetVersion()}");
                    Assert.IsTrue(ID.GetVariant() == CurVariant, $"Tried to generate {CurVersion}:{CurVariant} but got variant {ID.GetVariant()}");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void TestAllArray() {
            Int32[] Versions = UUIDFactory.GetAvailableVersion();
            Int32 CurVersion;
            Int32 CurVariant;
            Int32 Amount = 100;

            for (Int32 VersionIndex = 0; VersionIndex < Versions.Length; VersionIndex++) {
                CurVersion = Versions[VersionIndex];
                Int32[] Variants = UUIDFactory.GetAvailableVariants(Versions[VersionIndex]);

                for (Int32 VariantIndex = 0; VariantIndex < Variants.Length; VariantIndex++) {
                    CurVariant = Variants[VariantIndex];

                    UUID[] IDs = UUIDFactory.CreateUUIDs(Amount, CurVersion, CurVariant);
                    UUIDTests.ValidateUUID(IDs);

                    Assert.IsTrue(IDs.Length == Amount, $"{CurVersion}:{CurVariant} didn't generate {Amount} UUIDs");

                    foreach (UUID ID in IDs) {
                        if (ID == (Object)null) {
                            Assert.Fail($"Generated null {CurVersion}:{CurVariant}");
                        }

                        Assert.IsTrue(ID.GetVersion() == CurVersion, $"Tried to generate {CurVersion} but got {ID.GetVersion()}");
                        Assert.IsTrue(ID.GetVariant() == CurVariant, $"Tried to generate {CurVariant} but got {ID.GetVariant()}");
                    }
                }
            }
        }
    }
}
