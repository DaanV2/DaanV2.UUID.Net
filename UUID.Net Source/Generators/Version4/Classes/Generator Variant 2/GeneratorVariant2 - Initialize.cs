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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DaanV2.UUID.Generators.Version4 {
    ///DOLATER <summary> add description for class: GeneratorVariant2</summary>
	[Serializable, DataContract]
    public partial class GeneratorVariant2 {

        /// <summary>Creates a new instance of <see cref="GeneratorVariant1"/></summary>
        public GeneratorVariant2() : base() {

        }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="Seed"></param>
        public GeneratorVariant2(Int32 Seed) : base(Seed) { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="NumberGenerator"></param>
        public GeneratorVariant2(Random NumberGenerator) : base(NumberGenerator) { }
    }
}
