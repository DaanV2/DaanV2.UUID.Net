
using System;

namespace DaanV2.UUID.Generators.V4 {
    public abstract partial class RandomGeneratorBase {
        /// <summary>Gets or sets the random number generator used for generating <see cref="UUID"/></summary>
        public Random NumberGenerator { get => this._NumberGenerator; set => this._NumberGenerator = value; }
    }
}
