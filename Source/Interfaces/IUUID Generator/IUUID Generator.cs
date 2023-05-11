
using System;

namespace DaanV2.UUID {
    /// <summary>The interface responsible for determing how a <see cref="UUID"/> generator should behave</summary>
    public interface IUUIDGenerator {

        /// <summary>Gets the version of the UUID generator</summary>
        Int32 Version { get; }

        /// <summary>Gets the variant of the UUID generator</summary>
        Int32 Variant { get; }

        /// <summary>Gets if this <see cref="IUUIDGenerator"/> needs context to generate <see cref="UUID"/>s</summary>
        Boolean NeedContext { get; }

        /// <summary>Gets what type this <see cref="IUUIDGenerator"/> needs to generate a <see cref="UUID"/></summary>
        Type ContextType { get; }

        /// <summary>Returns a new <see cref="UUID"/></summary>
        /// <param name="Context">The context needed to generate this UUID</param>
        /// <returns>Returns a new <see cref="UUID"/></returns>
        UUID Generate(Object Context = default);

        /// <summary>Returns a new collection of <see cref="UUID"/></summary>
        /// <param name="Count">The amount of UUID to generate</param>
        /// <param name="Context">The context needed to generate this UUIDs</param>
        /// <returns>Returns a new collection of <see cref="UUID"/></returns>
        UUID[] Generate(Int32 Count, Object[] Context = default);
    }
}