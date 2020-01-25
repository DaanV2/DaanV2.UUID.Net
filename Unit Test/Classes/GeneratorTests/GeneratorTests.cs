using System;
using DaanV2.UUID;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test {
    ///DOLATER <summary>add description for class: GeneratorTests</summary>
    [TestClass]
    public partial class GeneratorTests {
        [TestMethod]
        public void TestAllGenerators() {
            Int32[] Versions = UUIDFactory.GetAvailableVersion();
            Int32 CurVersion;
            Int32 CurVariant;

            for (Int32 VersionIndex = 0; VersionIndex < Versions.Length; VersionIndex++) {
                CurVersion = Versions[VersionIndex];
                Int32[] Variants = UUIDFactory.GetAvailableVariants(Versions[VersionIndex]);

                for (Int32 VariantIndex = 0; VariantIndex < Variants.Length; VariantIndex++) {
                    CurVariant = Variants[VariantIndex];
                    IUUIDGenerator Generator = UUIDFactory.CreateGenerator(CurVersion, CurVariant);

                    if (Generator.NeedContext) {
                        Assert.IsFalse(Generator.ContextType == null, $"{CurVersion}:{CurVariant} if context text is needed then context type cannot be null");
                    }

                    Assert.IsTrue(Generator.Version == CurVersion, "Wrong version of generator");
                    Assert.IsTrue(Generator.Variant == CurVariant, "Wrong variant of generator");
                }
            }
        }
    }
}
