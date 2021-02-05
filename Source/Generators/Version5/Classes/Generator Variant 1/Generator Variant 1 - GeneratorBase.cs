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

namespace DaanV2.UUID.Generators.V5 {
    public partial class GeneratorVariant1 : GeneratorBase {
        /// <summary>Gets the version of the UUID generator</summary>
        public override Int32 Version => 5;

        /// <summary>Gets the variant of the UUID generator</summary>
        public override Int32 Variant => 1;

        /// <summary>Gets if this Generator needs context to generate a <see cref="UUID"/></summary>
        public override Boolean NeedContext => true;

        /// <summary>Gets what type this <see cref="IUUIDGenerator"/> needs to generate a <see cref="UUID"/></summary>
        public override Type ContextType => typeof(String);

        /// <summary>Returns a new <see cref="UUID"/></summary>
        /// <param name="Context">The context needed to generate this UUID</param>
        /// <returns>Returns a new <see cref="UUID"/></returns>
        public override UUID Generate(Object Context = null) {
            String Value;

            if (Context == null) {
                Value = DateTime.Now.ToString();
            }
            else if (Context is String T) {
                Value = T;
            }
            else {
                Value = Context.ToString();
            }

            //Compute hash
            Byte[] Bytes = this._Hasher.ComputeHash(Encoding.Default.GetBytes(Value));

            if (Bytes.Length < 16) {
                Array.Resize(ref Bytes, 16);
            }

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0101_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0011_1111) | 0b1000_0000);

            return new UUID(Converter.ToCharArray(Bytes));
        }

        /// <summary>Generate a <see cref="UUID"/> with the specified context</summary>
        /// <param name="Context">The text to use to create the <see cref="UUID"/></param>
        /// <param name="encoding">The encoding to use for converting to bytes</param>
        /// <returns>Generate a <see cref="UUID"/> with the specified context</returns>
        public UUID Generate(Object Context, Encoding encoding) {
            String Value;

            if (Context == null) {
                Value = DateTime.Now.ToString();
            }
            else if (Context is String T) {
                Value = T;
            }
            else {
                Value = Context.ToString();
            }

            //Compute hash
            Byte[] Bytes = this._Hasher.ComputeHash(encoding.GetBytes(Value));

            if (Bytes.Length < 16) {
                Array.Resize(ref Bytes, 16);
            }

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0101_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0011_1111) | 0b1000_0000);

            return new UUID(Converter.ToCharArray(Bytes));
        }

        /// <summary>Returns a new collection of <see cref="UUID"/></summary>
        /// <param name="Count">The amount of UUID to generate</param>
        /// <param name="Context">The context needed to generate this UUIDs</param>
        /// <returns>Returns a new collection of <see cref="UUID"/></returns>
        public override UUID[] Generate(Int32 Count, Object[] Context = null) {
            var Out = new UUID[Count];
            Int32 Index = 0;
            Int32 Max;

            if (Context == null || Context.Length == 0) {
                Context = new Object[1];
            }
            Max = Context.Length - 1;

            for (Int32 I = 0; I < Count; I++) {
                Out[I] = this.Generate(Out[Index++]);

                if (Index > Max) {
                    Index = 0;
                }
            }

            return Out;
        }

        /// <summary>Returns a new collection of <see cref="UUID"/></summary>
        /// <param name="Count">The amount of UUID to generate</param>
        /// <param name="Context">The context needed to generate this UUIDs</param>
        /// <param name="encoding">The encoding to use for converting to bytes</param>
        /// <returns>Returns a new collection of <see cref="UUID"/></returns>
        public UUID[] Generate(Int32 Count, Encoding encoding, Object[] Context = null) {
            var Out = new UUID[Count];
            Int32 Index = 0;
            Int32 Max;

            if (Context == null || Context.Length == 0) {
                Context = new Object[1];
            }
            Max = Context.Length - 1;

            for (Int32 I = 0; I < Count; I++) {
                Out[I] = this.Generate(Out[Index++], encoding);

                if (Index > Max) {
                    Index = 0;
                }
            }

            return Out;
        }
    }
}
