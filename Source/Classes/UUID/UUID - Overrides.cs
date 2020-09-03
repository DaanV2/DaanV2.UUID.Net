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
using System.Collections.Generic;

namespace DaanV2.UUID {
    public partial class UUID : IEquatable<UUID> {

        /// <summary>Returns the <see cref="String"/> representation of the UUID</summary>
        /// <returns>Returns a <see cref="String"/> that represents the UUID</returns>
        public override String ToString() {
            return new String(this._Chars);
        }

        /// <summary>Checks if the given obj is equal to this object</summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>Returns if true is the obj is the same as this object</returns>
        public override Boolean Equals(Object obj) {
            if (Object.ReferenceEquals(this, obj)) {
                return true;
            }

            if (obj is null) {
                return false;
            }
            else if (obj is UUID Same) {
                return this._Chars == Same._Chars;
            }
            else if (obj is Char[] Values) {
                return this == Values;
            }

            return this._Chars.Equals(obj);
        }

        /// <summary>Checks if the given <see cref="UUID"/> is equal to this object</summary>
        /// <param name="other">The <see cref="UUID"/> to compare to</param>
        /// <returns>Returns if true is the obj is the same as this object</returns>
        public Boolean Equals(UUID other) {
            if (other is null) {
                return false;
            }

            return this._Chars == other._Chars;
        }

        /// <summary>Generates the hashcode for this <see cref="UUID"/></summary>
        /// <returns>A hashcode for this <see cref="UUID"/></returns>
        public override Int32 GetHashCode() {
            return -14269637 + EqualityComparer<Char[]>.Default.GetHashCode(this._Chars);
        }

    }
}
