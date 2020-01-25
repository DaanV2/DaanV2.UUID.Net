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

        /// <summary>Compare two <see cref="UUID"/> if they are equal to each other</summary>
        /// <param name="left">The first <see cref="UUID"/></param>
        /// <param name="right">the second <see cref="UUID"/> to compare to the first</param>
        /// <returns>Returns true if two UUID are equal</returns>
        public static Boolean operator ==(UUID left, UUID right) {
            if (Object.ReferenceEquals(left, right))
                return true;

            Boolean Bl = left is Object;
            Boolean Br = right is Object;

            if (Bl == Br) {
                if (left._Chars.Length != right._Chars.Length) {
                    return false;
                }

                if (Bl) {
                    for (Int32 I = 0; I < left._Chars.Length; I++) {
                        if (left._Chars[I] != right._Chars[I]) {
                            return false;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>Compare two <see cref="UUID"/> if they are not equal to each other</summary>
        /// <param name="left">The first <see cref="UUID"/></param>
        /// <param name="right">the second <see cref="UUID"/> to compare to the first</param>
        /// <returns>Returns true if two UUID are not equal</returns>
        public static Boolean operator !=(UUID left, UUID right) {
            if (Object.ReferenceEquals(left, right))
                return false;

            Boolean Bl = left is Object;
            Boolean Br = right is Object;

            if (Bl == Br) {
                if (left._Chars.Length != right._Chars.Length) {
                    return true;
                }

                if (Bl) {
                    for (Int32 I = 0; I < left._Chars.Length; I++) {
                        if (left._Chars[I] != right._Chars[I]) {
                            return true;
                        }
                    }

                    return false;
                }
            }

            return true;
        }


        /// <summary>Auto converts the <see cref="UUID"/> to a <see cref="String"/></summary>
        /// <param name="value">The <see cref="UUID"/> to convert to <see cref="String"/></param>
        public static implicit operator String(UUID value) {
            return value.ToString();
        }

        /// <summary>Auto converts the <see cref="UUID"/> to a <see cref="Char[]"/></summary>
        /// <param name="value">The <see cref="UUID"/> to convert to <see cref="Char[]"/></param>
        public static implicit operator Char[](UUID value) {
            return value._Chars;
        }

        /// <summary>Auto converts the <see cref="String"/> to a <see cref="UUID"/></summary>
        /// <param name="value">The <see cref="String"/> to convert to <see cref="UUID[]"/></param>
        public static implicit operator UUID(String value) {
            return new UUID(value);
        }

        /// <summary>Auto converts the <see cref="Char[]"/> to a <see cref="UUID"/></summary>
        /// <param name="value">The <see cref="Char[]"/> to convert to <see cref="UUID[]"/></param>
        public static implicit operator UUID(Char[] Values) {
            return new UUID(Values);
        }
    }
}
