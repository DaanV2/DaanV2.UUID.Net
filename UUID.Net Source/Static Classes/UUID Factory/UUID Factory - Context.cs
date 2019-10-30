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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Version"></param>
        /// <param name="Variant"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        public static Type GetContext(Int32 Version, Int32 Variant, Object Context = default, Boolean ForMultipleUUIDGeneration = false) {
            Type T = null;

            T = CreateGenerator(Version, Variant)?.ContextType;

            if (T == null) {
                return T;
            }
            else if (ForMultipleUUIDGeneration) {
                return T.MakeArrayType();
            }
            else {
                return T;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Version"></param>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static Boolean? NeedContext(Int32 Version, Int32 Variant) {
            return CreateGenerator(Version, Variant)?.NeedContext;
        }
    }
}
