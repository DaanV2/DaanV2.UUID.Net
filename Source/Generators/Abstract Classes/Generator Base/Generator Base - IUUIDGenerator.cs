
using System;

namespace DaanV2.UUID.Generators {
    /// <summary>The base of the a <see cref="UUID"/></summary>
    public abstract partial class GeneratorBase : IUUIDGenerator {
        /// <summary>Gets the version of the generator</summary>
        public abstract Int32 Version { get; }

        /// <summary>Gets the variant of the generator</summary>
        public abstract Int32 Variant { get; }

        /// <summary>Gets if this generator need context to generate a UUID</summary>
        public abstract Boolean NeedContext { get; }

        /// <summary>Gets the type needed for the context to generate a UUID</summary>
        public abstract Type ContextType { get; }

        /// <summary>Returns a new <see cref="UUID"/></summary>
        /// <param name="Context">The context needed to generate this UUID</param>
        /// <returns>Returns a new <see cref="UUID"/></returns>
        public abstract UUID Generate(Object Context = default);

        /// <summary>Returns a new collection of <see cref="UUID"/></summary>
        /// <param name="Count">The amount of UUID to generate</param>
        /// <param name="Context">The context needed to generate this UUIDs</param>
        /// <returns>Returns a new collection of <see cref="UUID"/></returns>
        public abstract UUID[] Generate(Int32 Count, Object[] Context = null);
    }
}
