/* ISC License

 Copyright(c) 2019, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;
namespace DaanV2.UUID.Generators {
    ///DOLATER <summary> add description for class: Converter</summary>
    public static partial class Converter {
        /// <summary>Creates a new instance of <see cref="Converter"/></summary>
        static Converter() {
            Converter._ToChars = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            Converter._ToByte = new Byte[103, 103];

            for (Int32 I = 0; I < Converter._ToChars.Length; I++) {
                for (Int32 J = 0; J < Converter._ToChars.Length; J++) {
                    Converter._ToByte[Converter._ToChars[I], Converter._ToChars[J]] = (Byte)((I << 4) | J);
                }
            }
        }
    }
}
