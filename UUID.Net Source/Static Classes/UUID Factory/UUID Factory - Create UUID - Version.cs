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
using System.Threading.Tasks;

namespace DaanV2.UUID {
    public static partial class UUIDFactory {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static UUID CreateUUIDVersion3(Int32 Variant, String Context = default) {
            return CreateUUID<String>(UUIDFactory.CreateGeneratorVersion3(Variant), Context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static UUID[] CreateUUIDsVersion3(Int32 Variant, Int32 Amount, String[] Context = default) {
            return CreateUUIDs<String>(Amount, UUIDFactory.CreateGeneratorVersion3(Variant), Context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static UUID CreateUUIDVersion4(Int32 Variant, Int32 Context = default) {
            return CreateUUID<Int32>(UUIDFactory.CreateGeneratorVersion4(Variant), Context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static UUID[] CreateUUIDsVersion4(Int32 Variant, Int32 Amount, Int32[] Context = default) {
            return CreateUUIDs<Int32>(Amount, UUIDFactory.CreateGeneratorVersion4(Variant), Context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static UUID CreateUUIDVersion5(Int32 Variant, String Context = default) {
            return CreateUUID<String>(UUIDFactory.CreateGeneratorVersion5(Variant), Context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Variant"></param>
        /// <returns></returns>
        public static UUID[] CreateUUIDsVersion5(Int32 Variant, Int32 Amount, String[] Context = default) {
            return CreateUUIDs<String>(Amount, UUIDFactory.CreateGeneratorVersion5(Variant), Context);
        }


    }
}
