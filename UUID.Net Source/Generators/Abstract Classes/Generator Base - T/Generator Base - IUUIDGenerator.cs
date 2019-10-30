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
    public abstract partial class GeneratorBase<TypeContext> : IUUIDGenerator<TypeContext> {
        /// <summary>Gets the version of the generator</summary>
        public abstract Int32 Version { get; }

        /// <summary>Gets the variant of the generator</summary>
        public abstract Int32 Variant { get; }

        /// <summary></summary>
        public abstract Boolean NeedContext { get; }

        /// <summary></summary>
        public virtual Type ContextType => typeof(TypeContext);

        /// <summary>Generates a <see cref="UUID"/> specified by this version and variant format </summary>
        /// <param name="Context">The context needed to generate this UUID can be null</param>
        /// <returns>A new generated <see cref="UUID"/></returns>
        public abstract UUID Generate(TypeContext Context = default);
    }
}
