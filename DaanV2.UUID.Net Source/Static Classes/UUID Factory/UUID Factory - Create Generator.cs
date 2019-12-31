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
        /// <summary>Creates the specified generator or returns null</summary>
        /// <param name="Version">The version of the generator to create</param>
        /// <param name="Variant">The variant of the generator to create</param>
        /// <returns>Creates the specified generator or returns null</returns>
        public static IUUIDGenerator CreateGenerator(Int32 Version, Int32 Variant) {
            switch (Version) {
                case 3:
                    return CreateGeneratorVersion3(Variant);
                case 4:
                    return CreateGeneratorVersion4(Variant);
                case 5:
                    return CreateGeneratorVersion5(Variant);
                default:
                    return null;
            }
        }

        /// <summary>Creates the specified generator of version 3 or returns null</summary>
        /// <param name="Variant">The variant of the generator to create</param>
        /// <returns>Creates the specified generator of version 3 or returns null</returns>
        public static IUUIDGenerator<String> CreateGeneratorVersion3(Int32 Variant) {
            switch (Variant) {
                case 1:
                    return new Generators.Version3.GeneratorVariant1();
                default:
                    return null;
            }
        }

        /// <summary>Creates the specified generator of version 4 or returns null</summary>
        /// <param name="Variant">The variant of the generator to create</param>
        /// <returns>Creates the specified generator of version 4 or returns null</returns>
        public static IUUIDGenerator<Int32> CreateGeneratorVersion4(Int32 Variant) {
            switch (Variant) {
                case 1:
                    return new Generators.Version4.GeneratorVariant1();
                case 2:
                    return new Generators.Version4.GeneratorVariant2();
                default:
                    return null;
            }
        }

        /// <summary>Creates the specified generator of version 5 or returns null</summary>
        /// <param name="Variant">The variant of the generator to create</param>
        /// <returns>Creates the specified generator of version 5 or returns null</returns>
        public static IUUIDGenerator<String> CreateGeneratorVersion5(Int32 Variant) {
            switch (Variant) {
                case 1:
                    return new Generators.Version5.GeneratorVariant1();
                default:
                    return null;
            }
        }
    }
}
