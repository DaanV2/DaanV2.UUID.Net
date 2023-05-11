
using System;

namespace DaanV2.UUID.Generators.V4 {
    /// <summary>An abstract class that has a built in random generator</summary>
    public abstract partial class RandomGeneratorBase {
        /// <summary>Creates a new instance of <see cref="RandomGeneratorBase"/></summary>
        public RandomGeneratorBase() : base() {
            this._NumberGenerator = new Random();
        }

        /// <summary>Creates a new instance of <see cref="RandomGeneratorBase"/></summary>
        /// <param name="Seed">The seed used for the random generator</param>
        public RandomGeneratorBase(Int32 Seed) : base() {
            this._NumberGenerator = new Random(Seed);
        }

        /// <summary>Creates a new instance of <see cref="RandomGeneratorBase"/></summary>
        /// <param name="NumberGenerator"></param>
        public RandomGeneratorBase(Random NumberGenerator) : base() {
            this._NumberGenerator = NumberGenerator;
        }
    }
}
