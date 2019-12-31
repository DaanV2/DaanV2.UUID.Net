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

namespace DaanV2.UUID.Generators.Version4 {
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
