
using System;

namespace DaanV2.UUID.Generators.V4 {
    /// <summary>The UUID generator Version 4, Variant 2</summary>
    public partial class GeneratorVariant2 {

        /// <summary>Creates a new instance of <see cref="GeneratorVariant1"/></summary>
        public GeneratorVariant2() : base() { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="Seed">The seed used in the randomiser</param>
        public GeneratorVariant2(Int32 Seed) : base(Seed) { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="NumberGenerator">The random number randomiser</param>
        public GeneratorVariant2(Random NumberGenerator) : base(NumberGenerator) { }
    }
}
