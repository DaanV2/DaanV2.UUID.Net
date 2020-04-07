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
using System.Runtime.CompilerServices;

namespace DaanV2.UUID.Generators {
    public static partial class Converter {
        /// <summary>Converts a <see cref="Byte"/>[] to <see cref="Char"/>[] using hexidecimal. Size needs to be atleast 16</summary>
        /// <param name="Bytes">The <see cref="Byte"/>[] that need to be converted to <see cref="Char"/>[]. The size needs to be atleast 16 items</param>
        /// <returns>Converts a <see cref="Byte"/>[] to <see cref="Char"/>[] using hexidecimal. Size needs to be atleast 16</returns>
        public static Char[] ToCharArray(Byte[] Bytes) {
            Char[] T = Converter._ToChars;

            return new Char[]{
                T[Bytes[0] >> 4],
                T[Bytes[0] & 0b0000_1111],
                T[Bytes[1] >> 4],
                T[Bytes[1] & 0b0000_1111],
                T[Bytes[2] >> 4],
                T[Bytes[2] & 0b0000_1111],
                T[Bytes[3] >> 4],
                T[Bytes[3] & 0b0000_1111],
                '-',
                T[Bytes[4] >> 4],
                T[Bytes[4] & 0b0000_1111],
                T[Bytes[5] >> 4],
                T[Bytes[5] & 0b0000_1111],
                '-',
                T[Bytes[6] >> 4],
                T[Bytes[6] & 0b0000_1111],
                T[Bytes[7] >> 4],
                T[Bytes[7] & 0b0000_1111],
                '-',
                T[Bytes[8] >> 4],
                T[Bytes[8] & 0b0000_1111],
                T[Bytes[9] >> 4],
                T[Bytes[9] & 0b0000_1111],
                '-',
                T[Bytes[10] >> 4],
                T[Bytes[10] & 0b0000_1111],
                T[Bytes[11] >> 4],
                T[Bytes[11] & 0b0000_1111],
                T[Bytes[12] >> 4],
                T[Bytes[12] & 0b0000_1111],
                T[Bytes[13] >> 4],
                T[Bytes[13] & 0b0000_1111],
                T[Bytes[14] >> 4],
                T[Bytes[14] & 0b0000_1111],
                T[Bytes[15] >> 4],
                T[Bytes[15] & 0b0000_1111],
            };
        }
    }
}
