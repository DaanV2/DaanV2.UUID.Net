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
        /// <returns></returns>
        public static UUID CreateUUID(Int32 Version = 4, Int32 Variant = 1) {
            IUUIDGenerator Generator = UUIDFactory.CreateGenerator(Version, Variant);

            return Generator == null ?
                UUID.Nill :
                Generator.Generate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Version"></param>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static UUID[] CreateUUIDs(Int32 Amount, Int32 Version = 4, Int32 Variant = 1) {
            UUID[] Out = new UUID[Amount];

            IUUIDGenerator Generator = UUIDFactory.CreateGenerator(Version, Variant);

            if (Generator == null) {
                return Out;
            }

            for (Int32 I = 0; I < Amount; I++) {
                Out[I] = Generator.Generate();
            }

            return Out;
        }
    }
}
