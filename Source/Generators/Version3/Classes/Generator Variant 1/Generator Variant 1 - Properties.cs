
using System.Security.Cryptography;

namespace DaanV2.UUID.Generators.V3 {
    public partial class GeneratorVariant1 {
        /// <summary>The hasher used to generate the UUID</summary>
        public MD5 Hasher { get => this._Hasher; set => this._Hasher = value; }
    }
}
