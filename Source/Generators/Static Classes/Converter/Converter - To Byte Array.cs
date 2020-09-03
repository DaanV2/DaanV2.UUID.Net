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
        /// <summary>Converts a <see cref="Char"/>[] to a <see cref="Byte"/>[] using hexadecimal</summary>
        /// <param name="Chars">The array to convert to <see cref="Byte"/>[], array needs to be 35 items</param>
        /// <returns>Converts a <see cref="Char"/>[] to a <see cref="Byte"/>[] using hexadecimal</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Byte[] ToBytes(Char[] Chars) {
            Byte[] Data = new Byte[16];
            Int32 WriteIndex = 0;

            const Char SubA = (Char)('a' - 10);
            const Char Sub0 = '0';
            const Byte Mask = 0b0000_1111;

            for (Int32 I = 0; I < 35; I++) {
                Char Char = Chars[I];

                if (Char == '-') {
                    I++;
                    Char = Chars[I];
                }

                //Out[WriteIndex++] = (Char)((Byte >> 4) + '0');
                Byte Byte;
                if (Char >= 'a') {
                    Char -= SubA;
                    Byte = (Byte)(Char << 4);
                }
                else {
                    Byte = (Byte)((Char - Sub0) << 4);
                }

                I++;
                //Out[WriteIndex++] = (Char)((Byte & 0b0000_1111) + '0');
                Char = Chars[I];
                if (Char >= 'a') {
                    Char -= SubA;
                    Byte |= (Byte)(Char & Mask);
                }
                else {
                    Byte |= (Byte)((Char - Sub0) & Mask);
                }

                Data[WriteIndex++] = Byte;
            }

            return Data;
        }
    }
}
