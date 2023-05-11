
using System;

namespace DaanV2.UUID.Generators.V4 {
    public partial class GeneratorVariant2 : RandomGeneratorBase {
        /// <summary>Gets the version of the UUID generator</summary>
        public override Int32 Version => 4;

        /// <summary>Gets the variant of the UUID generator</summary>
        public override Int32 Variant => 2;

        /// <summary>Generates a <see cref="UUID"/> specified by this version and variant format </summary>
        /// <param name="Context">The context needed to generate this UUID can be null</param>
        /// <returns>A new generated <see cref="UUID"/></returns>
        public override UUID Generate(Object Context = null) {
            if (Context is Int32 Value) {
                this.NumberGenerator = new Random(Value);
            }

            Byte[] Bytes = new Byte[16];
            this._NumberGenerator.NextBytes(Bytes);

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0100_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0001_1111) | 0b1100_0000);

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
            Byte[] Bytes = new Byte[16];

            for (Int32 I = 0; I < Count; I++) {
                this._NumberGenerator.NextBytes(Bytes);

                //set version and variant
                Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0100_0000);
                Bytes[8] = (Byte)((Bytes[8] & 0b0001_1111) | 0b1100_0000);

                Out[I] = new UUID(Converter.ToCharArray(Bytes));

                if (Index > Max) {
                    Index = 0;
                }
            }

            return Out;
        }
    }
}
