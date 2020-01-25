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
    public partial class GeneratorInfo {
        /// <summary>The version of the UUID generator</summary>
        private Int32 _Version;

        /// <summary>The variant of the UUID generator</summary>
        private Int32 _Variant;

        /// <summary>Marks if this <see cref="IUUIDGenerator"/> needs context to generate <see cref="UUID"/>s</summary>
        private Boolean _NeedContext;

        /// <summary>The type that this <see cref="IUUIDGenerator"/> needs to generate a <see cref="UUID"/></summary>
        private Type _ContextType;

        /// <summary>The type of generator to be used</summary>
        private Type _GeneratorType;
    }
}
