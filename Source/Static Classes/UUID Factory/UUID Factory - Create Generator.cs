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
            if (UUIDFactory._Generators.Length <= Version || //No room for version
                UUIDFactory._Generators[Version].Length <= Variant || //No room for variant
                UUIDFactory._Generators[Version][Variant] == null) { //No type has been filled
                throw new ArgumentException($"No such generator with: {Version}.{Variant}");
            }

            return (IUUIDGenerator)Activator.CreateInstance(UUIDFactory._Generators[Version][Variant].GeneratorType);
        }
    }
}
