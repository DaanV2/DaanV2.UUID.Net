﻿/*ISC License

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
    public partial class GeneratorVariant1 : RandomGeneratorBase {
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
        /// <param name="Context"></param>
        /// <returns></returns>
        public override UUID Generate(Int32 Context = 0) {
            if (Context != 0) {
                this.NumberGenerator = new Random(Context);
            }

            Byte[] Bytes = new Byte[16];
            this._NumberGenerator.NextBytes(Bytes);

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0100_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0011_1111) | 0b1000_0000);

            return new UUID(Converter.ToCharArray(Bytes));
        }
    }
}
