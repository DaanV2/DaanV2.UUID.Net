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
    public static partial class Converter {
        /// <summary>Converts a <see cref="Char[]"/> to a <see cref="Byte[]"/> using hexadecimal</summary>
        /// <param name="Chars">The array to convert to <see cref="Byte[]"/>, array needs to be 35 items</param>
        /// <returns>Converts a <see cref="Char[]"/> to a <see cref="Byte[]"/> using hexadecimal</returns>
        public static Byte[] ToBytes(Char[] Chars) {
            Byte[,] T = Converter._ToByte;

            return new Byte[] {
                T[Chars[0], Chars[1]],
                T[Chars[2], Chars[3]],
                T[Chars[4], Chars[5]],
                T[Chars[6], Chars[7]],

                T[Chars[9], Chars[10]],
                T[Chars[11], Chars[12]],

                T[Chars[14], Chars[15]],
                T[Chars[16], Chars[17]],

                T[Chars[19], Chars[20]],
                T[Chars[21], Chars[22]],

                T[Chars[24], Chars[25]],
                T[Chars[26], Chars[27]],
                T[Chars[28], Chars[29]],
                T[Chars[30], Chars[31]],
                T[Chars[32], Chars[33]],
                T[Chars[34], Chars[35]]
            };
        }
    }
}
