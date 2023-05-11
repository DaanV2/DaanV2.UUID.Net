
using System.Security.Cryptography;

namespace DaanV2.UUID.Generators.V5 {
    /// <summary>The UUID Generator Version 5, Variant 1</summary>
    public partial class GeneratorVariant1 {
        /// <summary>Creates a new instance of <see cref="GeneratorVariant1"/></summary>
        public GeneratorVariant1() {
            this._Hasher = SHA1.Create();
        }
    }
}
