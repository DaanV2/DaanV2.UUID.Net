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
using System.Text;

namespace DaanV2.UUID.Generators.Version3 {
    public partial class GeneratorVariant1 : GeneratorBase<String> {
        /// <summary>Gets the version of this <see cref="GeneratorVariant1"/></summary>
        public override Int32 Version => 3;

        /// <summary>Gets the variant of this <see cref="GeneratorVariant1"/></summary>
        public override Int32 Variant => 1;

        /// <summary>Gets if this Generator needs context to generate a <see cref="UUID"/></summary>
        public override Boolean NeedContext => true;

        /// <summary>Generate a <see cref="UUID"/> with the specified context</summary>
        /// <param name="Context">The context to use to generate the <see cref="UUID"/>. If the context is null or empty then the datetime is converted to a string</param>
        /// <returns>Generate a <see cref="UUID"/> with the specified context</returns>
        public override UUID Generate(String Context = null) {
            if (String.IsNullOrEmpty(Context)) {
                Context = DateTime.Now.ToString();
            }

            //Compute hash
            Byte[] Bytes = this._Hasher.ComputeHash(Encoding.Default.GetBytes(Context));

            if (Bytes.Length < 16) {
                Array.Resize(ref Bytes, 16);
            }

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0011_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0011_1111) | 0b1000_0000);

            return new UUID(Converter.ToCharArray(Bytes));
        }

        /// <summary>Generate a <see cref="UUID"/> with the specified context</summary>
        /// <param name="Text">The text to use to create the <see cref="UUID"/></param>
        /// <param name="encoding">The encoding to use for converting to bytes</param>
        /// <returns>Generate a <see cref="UUID"/> with the specified context</returns>
        public UUID Generate(String Text, Encoding encoding) {
            //Compute hash
            Byte[] Bytes = this._Hasher.ComputeHash(encoding.GetBytes(Text));

            if (Bytes.Length < 16) {
                Array.Resize(ref Bytes, 16);
            }

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0011_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0011_1111) | 0b1000_0000);

            return new UUID(Converter.ToCharArray(Bytes));
        }
    }
}
