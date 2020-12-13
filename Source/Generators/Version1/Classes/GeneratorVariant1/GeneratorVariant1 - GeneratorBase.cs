using System;

namespace DaanV2.UUID.Generators.Version1 {
    ///DOLATER <summary>add description for class: GeneratorVariant1</summary>
    public partial class GeneratorVariant1 : GeneratorBase {
        /// <summary></summary>
        public override Int32 Version => 1;

        /// <summary></summary>
        public override Int32 Variant => 1;

        /// <summary></summary>
        public override Boolean NeedContext => false;

        /// <summary></summary>
        public override Type ContextType => null;

        public override UUID Generate(Object Context = null) {
            //Compute hash
            Byte[] Bytes = new Byte[16];

            UInt64 Value = (UInt64)DateTime.UtcNow.ToFileTimeUtc();
            Byte[] Converted = BitConverter.GetBytes(Value);

            //Set mac address
            Byte[] MacAddress = Utillity.GetMacAddressBytes();

            if (MacAddress == null) {
                MacAddress = new Byte[6];
            }

            for (Int32 I = 0; I < 6; I++) {
                Bytes[I + 10] = MacAddress[I];
            }

            //First 32 bites = time_low
            Bytes[0] = Converted[0];
            Bytes[1] = Converted[1];
            Bytes[2] = Converted[2];
            Bytes[3] = Converted[3];

            //next 16 bites = time_mid
            //next 16 bites = time_hi_version
            //next 8 bites = clock_seq_hi_variant 
            //last 48 bites mac address

            //set version and variant
            Bytes[6] = (Byte)((Bytes[6] & 0b0000_1111) | 0b0001_0000);
            Bytes[8] = (Byte)((Bytes[8] & 0b0011_1111) | 0b1000_0000);

            return new UUID(Converter.ToCharArray(Bytes));
        }

        public override UUID[] Generate(Int32 Count, Object[] Context = null) {
            throw new NotImplementedException();
        }
    }
}
