using System;
using DaanV2.UUID;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test {
    public partial class VersionTests {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void TestCasting() {
            Int32[] Versions = UUIDFactory.GetAvailableVersion();
            Int32 CurVersion;
            Int32 CurVariant;

            for (Int32 VersionIndex = 0; VersionIndex < Versions.Length; VersionIndex++) {
                CurVersion = Versions[VersionIndex];
                Int32[] Variants = UUIDFactory.GetAvailableVariants(Versions[VersionIndex]);

                for (Int32 VariantIndex = 0; VariantIndex < Variants.Length; VariantIndex++) {
                    CurVariant = Variants[VariantIndex];

                    UUID ID = UUIDFactory.CreateUUID(CurVersion, CurVariant);
                    String Temp = ID;
                    UUID New = Temp;

                    Assert.IsTrue(ID == New, "UUID casting to string failed");
                    Assert.IsTrue(New.GetVersion() == CurVersion, $"Tried to generate {CurVersion} but got {ID.GetVersion()}");
                    Assert.IsTrue(New.GetVariant() == CurVariant, $"Tried to generate {CurVariant} but got {ID.GetVariant()}");

                    Char[] Test = ID;
                    New = Test;

                    Assert.IsTrue(ID == New, "UUID casting to char array failed");
                    Assert.IsTrue(New.GetVersion() == CurVersion, $"Tried to generate {CurVersion} but got {ID.GetVersion()}");
                    Assert.IsTrue(New.GetVariant() == CurVariant, $"Tried to generate {CurVariant} but got {ID.GetVariant()}");
                }
            }
        }
    }
}
