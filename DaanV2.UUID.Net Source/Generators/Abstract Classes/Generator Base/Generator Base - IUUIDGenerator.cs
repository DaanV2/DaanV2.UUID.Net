/*ISC License

Copyright (c) 2019, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;

namespace DaanV2.UUID.Generators {
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
