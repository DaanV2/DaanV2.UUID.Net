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
