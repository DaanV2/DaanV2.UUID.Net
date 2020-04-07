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
using DaanV2.UUID.Generators;

namespace DaanV2.UUID {
    public static partial class UUIDFactory {
        /// <summary>Returns the type needed for the generator needs</summary>
        /// <param name="Version">The version of the generator to use</param>
        /// <param name="Variant">The variant of the generator to use</param>
        /// <param name="ForMultipleUUIDGeneration">Marks if there should be multiple items or single</param>
        /// <returns>Returns the type needed for the generator needs</returns>
        public static Type GetContext(Int32 Version, Int32 Variant, Boolean ForMultipleUUIDGeneration = false) {
            GeneratorInfo Info = UUIDFactory.GetInfo(Version, Variant);

            return ForMultipleUUIDGeneration ?
                Info.ContextType.MakeArrayType() :
                Info.ContextType;
        }

        /// <summary>Returns if the specified generator needs context</summary>
        /// <param name="Version">The version of the generator to use</param>
        /// <param name="Variant">The variant of the generator to use</param>
        /// <returns>Returns if the specified generator needs context</returns>
        public static Boolean? NeedContext(Int32 Version, Int32 Variant) {
            GeneratorInfo Info = UUIDFactory.GetInfo(Version, Variant);

            return Info.NeedContext;
        }
    }
}
