
using System.Security.Cryptography;

namespace DaanV2.UUID.Generators.V3 {
    /// <summary>The UUID Generator Version 3, Variant 1</summary>
    public partial class GeneratorVariant1 {
        /// <summary>Creates a new instance of <see cref="GeneratorVariant1"/></summary>
        public GeneratorVariant1() : base() {
            this.Hasher = MD5.Create();
        }
    }
}
