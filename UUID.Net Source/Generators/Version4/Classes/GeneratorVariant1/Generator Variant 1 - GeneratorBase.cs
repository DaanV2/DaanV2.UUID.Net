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
    public partial class GeneratorVariant1 : GeneratorBase {
        
        /// <summary>
        /// 
        /// </summary>
        public override Int32 Version => 4;

        /// <summary>
        /// 
        /// </summary>
        public override Int32 Variant => 1;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override UUID Generate() {
            Byte[] Bytes = new Byte[16];

            this._NumberGenerator.NextBytes(Bytes);

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0100_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0011_1111) | 0b1000_0000);

            Char[] Out = new Char[] {
                this._ToHexChars[Bytes[0], 0],
                this._ToHexChars[Bytes[0], 1],
                this._ToHexChars[Bytes[1], 0],
                this._ToHexChars[Bytes[1], 1],
                this._ToHexChars[Bytes[2], 0],
                this._ToHexChars[Bytes[2], 1],
                this._ToHexChars[Bytes[3], 0],
                this._ToHexChars[Bytes[3], 1],
                '-',
                this._ToHexChars[Bytes[4], 0],
                this._ToHexChars[Bytes[4], 1],
                this._ToHexChars[Bytes[5], 0],
                this._ToHexChars[Bytes[5], 1],
                '-',
                this._ToHexChars[Bytes[6], 0],
                this._ToHexChars[Bytes[6], 1],
                this._ToHexChars[Bytes[7], 0],
                this._ToHexChars[Bytes[7], 1],
                '-',
                this._ToHexChars[Bytes[8], 0],
                this._ToHexChars[Bytes[8], 1],
                this._ToHexChars[Bytes[9], 0],
                this._ToHexChars[Bytes[9], 1],
                '-',
                this._ToHexChars[Bytes[10], 0],
                this._ToHexChars[Bytes[10], 1],
                this._ToHexChars[Bytes[11], 0],
                this._ToHexChars[Bytes[11], 1],
                this._ToHexChars[Bytes[12], 0],
                this._ToHexChars[Bytes[12], 1],
                this._ToHexChars[Bytes[13], 0],
                this._ToHexChars[Bytes[13], 1],
                this._ToHexChars[Bytes[14], 0],
                this._ToHexChars[Bytes[14], 1],
                this._ToHexChars[Bytes[15], 0],
                this._ToHexChars[Bytes[15], 1]
            };

            return new UUID(Out);
        }
    }
}
