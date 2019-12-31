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
        /// <summary>Generate a <see cref="UUID"/> using the specified version and variant</summary>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <returns>Generate a <see cref="UUID"/> using the specified version and variant and specified amount</returns>
        public static UUID CreateUUID(Int32 Version, Int32 Variant, Object Context = default) {
            IUUIDGenerator generator = UUIDFactory.CreateGenerator(Version, Variant);
            return generator.Generate(Context);
        }

        /// <summary>Generate a <see cref="UUID[]"/> using the specified version and variant and specified amount</summary>
        /// <param name="Amount">The amount of UUID to generate</param>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <returns>Generate a <see cref="UUID[]"/> using the specified version and variant and specified amount</returns>
        public static UUID[] CreateUUIDs(Int32 Amount, Int32 Version, Int32 Variant, Object[] Context = default) {
            IUUIDGenerator generator = UUIDFactory.CreateGenerator(Version, Variant);
            return generator.Generate(Amount, Context);
        }
    }
}
