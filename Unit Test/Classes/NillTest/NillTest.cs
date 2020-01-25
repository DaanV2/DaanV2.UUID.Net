using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DaanV2.UUID;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test {
    ///DOLATER <summary>add description for class: NillTest</summary>
    [TestClass]
    public partial class NillTest {
        [TestMethod]
        public void ValidNill() {
            Assert.IsTrue(UUID.Nill.ToString() == "00000000-0000-0000-0000-000000000000", "Nill UUID is not an proper nill uuid");
        }
    }
}
