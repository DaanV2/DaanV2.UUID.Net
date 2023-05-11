
using System;

namespace DaanV2.UUID.Generators.V4 {
    public abstract partial class RandomGeneratorBase {
        /// <summary>The number generator used for generating the <see cref="UUID"/></summary>
        private protected Random _NumberGenerator;
    }
}
