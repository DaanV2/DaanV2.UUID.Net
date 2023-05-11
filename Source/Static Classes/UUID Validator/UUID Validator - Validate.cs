
using System;

namespace DaanV2.UUID {
    public static partial class UUIDValidator {
        /// <summary>Validates the <see cref="UUID"/>, Checks if it is properly formatted, right version and variant</summary>
        /// <param name="Value">The <see cref="UUID"/> to check</param>
        /// <returns>A <see cref="Boolean"/> that marks if the output was valid or not</returns>
        public static Boolean IsValidUUID(UUID Value) {
            if (Value == UUID.Nill) {
                return true;
            }

            Char[] Values = Value.Chars;
            Char C;

            if (Values.Length != 36) {
                return false;
            }

            for (Int32 I = 0; I < 36; I++) {
                C = Values[I];
                if (!(Char.IsLetterOrDigit(C) || C == '-')) {
                    return false;
                }
            }

            if (!(Values[8] == '-' && Values[13] == '-' && Values[18] == '-' && Values[23] == '-')) {
                return false;
            }

            Int32 Version = Value.GetVersion();
            Int32 Variant = Value.GetVariant();

            return Version > 0 && Version < 6 && Variant > -1 && Variant < 4;
        }

        /// <summary>Validates the <see cref="UUID"/>, Checks if it is properly formatted, right version and variant. throws exeception when an error is encountered</summary>
        /// <param name="Value">The <see cref="UUID"/> to check</param>
        public static void Validate(UUID Value) {
            if (Value == UUID.Nill) {
                return;
            }

            Char[] Values = Value.Chars;
            Char C;

            if (Values.Length != 36) {
                throw new Exception($"UUID has wrong length: {Values.Length}, should be 36.");
            }

            for (Int32 I = 0; I < 36; I++) {
                C = Values[I];
                if (!(Char.IsLetterOrDigit(C) || C == '-')) {
                    throw new Exception($"UUID has invalid character at: {I}: '{C}'.");
                }
            }

            Int32 Version = Value.GetVersion();
            Int32 Variant = Value.GetVariant();

            if (Version > 0 && Version < 6) {
                if (!(Variant > -1 && Variant < 4)) {
                    throw new Exception($"UUID has invalid variant: {Variant}, expected one of these values:  0, 1, 2, 3");
                }
            }
            else {
                throw new Exception($"UUID has invalid version: {Version}, expected one of these values: 1, 2, 3, 4, 5");
            }
        }
    }
}
