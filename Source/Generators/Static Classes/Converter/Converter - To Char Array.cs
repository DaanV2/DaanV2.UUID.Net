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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Char[] ToCharArray(Byte[] Bytes) {
            Char[] Out = new Char[36];

            Int32 WriteIndex = 0;

            for (Int32 I = 0; I < 16; I++) {
                Byte Byte = Bytes[I];
                Char Temp = (Char)(Byte >> 4);

                if (Temp > 9) {
                    Temp += (Char)('a' - 10);
                }
                else {
                    Temp += '0';
                }
                Out[WriteIndex++] = Temp;

                Temp = (Char)(Byte & 0b0000_1111);
                if (Temp > 9) {
                    Temp += (Char)('a' - 10);
                }
                else {
                    Temp += '0';
                }
                Out[WriteIndex++] = Temp;

                if (WriteIndex == 8 || WriteIndex == 13 || WriteIndex == 18 || WriteIndex == 23) {
                    Out[WriteIndex++] = '-';
                }
            }

            return Out;
        }

        /// <summary>Converts a <see cref="Byte"/>[] to <see cref="Char"/>[] using hexidecimal. Size needs to be atleast 16 + startindex</summary>
        /// <param name="Bytes">The <see cref="Byte"/>[] that need to be converted to <see cref="Char"/>[]. The size needs to be atleast 16 items + startindex</param>
        /// <param name="StartIndex">The index to start at in the byte array</param>
        /// <returns>Converts a <see cref="Byte"/>[] to <see cref="Char"/>[] using hexidecimal. Size needs to be atleast 16</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Char[] ToCharArray(Byte[] Bytes, Int32 StartIndex) {
            Char[] Out = new Char[36];

            Int32 WriteIndex = 0;

            Int32 Max = StartIndex + 16;
            for (Int32 I = StartIndex; I < Max; I++) {
                Byte Byte = Bytes[I];
                Char Temp = (Char)(Byte >> 4);

                if (Temp > 9) {
                    Temp += (Char)('a' - 10);
                }
                else {
                    Temp += '0';
                }
                Out[WriteIndex++] = Temp;

                Temp = (Char)(Byte & 0b0000_1111);
                if (Temp > 9) {
                    Temp += (Char)('a' - 10);
                }
                else {
                    Temp += '0';
                }
                Out[WriteIndex++] = Temp;

                if (WriteIndex == 8 || WriteIndex == 13 || WriteIndex == 18 || WriteIndex == 23) {
                    Out[WriteIndex++] = '-';
                }
            }

            return Out;
        }
    }
}
