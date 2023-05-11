
using System;

namespace DaanV2.UUID.Generators.V4 {
    /// <summary>The UUID generator version 4, variant 1</summary>
    public partial class GeneratorVariant1 {

        /// <summary>Creates a new instance of <see cref="GeneratorVariant1"/></summary>
        public GeneratorVariant1() : base() { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="Seed"></param>
        public GeneratorVariant1(Int32 Seed) : base(Seed) { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="NumberGenerator"></param>
        public GeneratorVariant1(Random NumberGenerator) : base(NumberGenerator) { }
    }
}
