
using System;

namespace DaanV2.UUID {
    public partial class UUID {
        /// <summary>Returns the version of this UUID</summary>
        /// <returns>The version number that is stored within the UUID</returns>
        public Int32 GetVersion() {
            Char C = this._Chars[14];

            if (C >= '0' && C <= '9') {
                return C - '0';
            }

            if (C >= 'a' && C <= 'f') {
                return C - 'a' + 10;
            }

            return -1;
        }

        /// <summary>Returns the variant of this UUID</summary>
        /// <returns>The variant number that is stored within the UUID</returns>
        public Int32 GetVariant() {
            Char C = this._Chars[19];

            if (C >= '0' && C < '8') {
                return 0;
            }
            else if (C >= '8' && C <= 'b') {
                return 1;
            }
            else if (C == 'c' || C == 'd') {
                return 2;
            }
            else if (C == 'e' || C == 'f') {
                return 3;
            }

            return -1;
        }
    }
}
