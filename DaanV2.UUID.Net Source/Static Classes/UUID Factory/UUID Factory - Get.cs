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
    public static partial class UUIDFactory {
        /// <summary>Returns an array of available version of generators</summary>
        /// <returns>An array of <see cref="Int32"/> contaning version numbering</returns>
        public static Int32[] GetAvailableVersion() {
            return new Int32[] { 3, 4, 5 };
        }

        /// <summary>Returns an array of available variants of generators for a specified version</summary>
        /// <param name="Version">The version to check which variants are aviable</param>
        /// <returns>An array of <see cref="Int32"/> contaning variant numbering</returns>
        public static Int32[] GetAvailableVariants(Int32 Version) {
            switch (Version) {
                case 3:
                    return new Int32[] { 1 };
                case 4:
                    return new Int32[] { 1, 2 };
                case 5:
                    return new Int32[] { 1 };
            }

            return null;
        }
    }
}
