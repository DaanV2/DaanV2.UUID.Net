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
using System.Runtime.Serialization;

namespace DaanV2.UUID {
    /// <summary>The class that holds the information of a <see cref="UUID"/> string</summary>
	[Serializable, DataContract]
    public partial class UUID {
        /// <summary>Creates a new instance of <see cref="UUID"/></summary>
        public UUID() {
            this._Chars = new Char[36];
        }

        /// <summary>Creates a new instance of <see cref="UUID"/></summary>
        /// <param name="Values">The char values of the <see cref="UUID"/></param>
        public UUID(Char[] Values) {
            this._Chars = Values;
        }

        /// <summary>Creates a new instance of <see cref="UUID"/></summary>
        /// <param name="Text">The string representation of the <see cref="UUID"/></param>
        public UUID(String Text) {
            this._Chars = Text.ToCharArray();
        }
    }
}
