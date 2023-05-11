
using System.Security.Cryptography;

namespace DaanV2.UUID.Generators.V5 {
    public partial class GeneratorVariant1 {
        /// <summary>Gets or sets the hasher used to generate UUID</summary>
        public SHA1 Hasher { get => this._Hasher; set => this._Hasher = value; }
    }
}
