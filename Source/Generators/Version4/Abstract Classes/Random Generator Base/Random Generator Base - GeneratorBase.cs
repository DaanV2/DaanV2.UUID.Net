
using System;

namespace DaanV2.UUID.Generators.V4 {
    public abstract partial class RandomGeneratorBase : GeneratorBase {
        /// <summary>Gets the version of the generator</summary>
        public abstract override Int32 Version { get; }

        /// <summary>Gets the variant of the generator</summary>
        public abstract override Int32 Variant { get; }

        /// <summary>Gets if this <see cref="RandomGeneratorBase"/> needs context to generate <see cref="UUID"/>s</summary>
        public override Boolean NeedContext => false;

        /// <summary>Gets what type this <see cref="IUUIDGenerator"/> needs to generate a <see cref="UUID"/></summary>
        public override Type ContextType => typeof(Int32);
    }
}
