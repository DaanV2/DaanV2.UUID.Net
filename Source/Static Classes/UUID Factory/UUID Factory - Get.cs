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
        /// <summary>Returns an array of available version of generators</summary>
        /// <returns>An array of <see cref="Int32"/> contaning version numbering</returns>
        public static Int32[] GetAvailableVersion() {
            Int32 Length = UUIDFactory._Generators.Length;
            Int32[] Out = new Int32[Length];
            Int32 Index = 0;

            for (Int32 Version = 0; Version < Length; Version++) {
                if (UUIDFactory._Generators[Version] != null) {
                    Out[Index++] = Version;
                }
            }

            if (Index != Out.Length) {
                Array.Resize(ref Out, Index);
            }

            return Out;
        }

        /// <summary>Returns an array of available variants of generators for a specified version</summary>
        /// <param name="Version">The version to check which variants are aviable</param>
        /// <returns>An array of <see cref="Int32"/> contaning variant numbering</returns>
        public static Int32[] GetAvailableVariants(Int32 Version) {
            if (UUIDFactory._Generators.Length <= Version) {
                throw new ArgumentException($"No such generator with: {Version}");
            }

            GeneratorInfo[] Generators = UUIDFactory._Generators[Version];

            if (Generators == null || Generators.Length == 0) {
                throw new ArgumentException($"No such generator with: {Version}");
            }

            Int32 Length = Generators.Length;
            Int32[] Out = new Int32[Length];
            Int32 Index = 0;

            for (Int32 Variant = 0; Variant < Length; Variant++) {
                if (Generators[Variant] != null) {
                    Out[Index++] = Variant;
                }
            }

            if (Index != Out.Length) {
                Array.Resize(ref Out, Index);
            }

            return Out;
        }

        /// <summary>Returns a <see cref="GeneratorInfo"/> about the specified generator</summary>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <returns>Returns a <see cref="GeneratorInfo"/> about the specified generator</returns>
        public static GeneratorInfo GetInfo(Int32 Version, Int32 Variant) {
            if (UUIDFactory._Generators.Length <= Version || //No room for version
                UUIDFactory._Generators[Version].Length <= Variant || //No room for variant
                UUIDFactory._Generators[Version][Variant] == null) { //No type has been filled
                throw new ArgumentException($"No such generator with: {Version}.{Variant}");
            }

            return UUIDFactory._Generators[Version][Variant];
        }
    }
}
