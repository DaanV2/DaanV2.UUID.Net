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

        /// <summary>Generate a <see cref="UUID"/> using the specified version and variant</summary>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <returns>A newly generated <see cref="UUID"/></returns>
        public static UUID CreateUUID(Int32 Version, Int32 Variant, Object Context = default) {
            switch (Version) {
                case 3:
                    return UUIDFactory.CreateUUIDVersion3(Variant, (String)Context);
                case 4:
                    return UUIDFactory.CreateUUIDVersion4(Variant, (Int32)Context);
                case 5:
                    return UUIDFactory.CreateUUIDVersion5(Variant, (String)Context);

                default:
                    return UUID.Nill;
            }
        }

        /// <summary>Generate a <see cref="UUID"/> using the specified version and variant</summary>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <returns>A newly generated <see cref="UUID"/></returns>
        public static Task<UUID> CreateUUIDAsync(Int32 Version, Int32 Variant, Object Context = default) {
            return Task.Run(() => CreateUUID(Version, Variant, Context));
        }

        /// <summary>Generate a <see cref="UUID[]"/> using the specified version and variant and specified amount</summary>
        /// <param name="Amount">The amount of UUID to generate</param>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <returns>A newly generated <see cref="UUID[]"/></returns>
        public static UUID[] CreateUUIDs(Int32 Amount, Int32 Version, Int32 Variant, Object Context = default) {
            switch (Version) {
                case 3:
                    return UUIDFactory.CreateUUIDsVersion3(Variant, Amount, (String[])Context);
                case 4:
                    return UUIDFactory.CreateUUIDsVersion4(Variant, Amount, (Int32[])Context);
                case 5:
                    return UUIDFactory.CreateUUIDsVersion5(Variant, Amount, (String[])Context);

                default:
                    return new UUID[] { UUID.Nill };
            }
        }

        /// <summary>Generate a <see cref="UUID[]"/> using the specified version and variant and specified amount</summary>
        /// <param name="Amount">The amount of UUID to generate</param>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <returns>A newly generated <see cref="UUID[]"/></returns>
        public static Task<UUID[]> CreateUUIDsAsync(Int32 Amount, Int32 Version, Int32 Variant, Object Context = default) {
            return Task<UUID[]>.Run(() => CreateUUIDs(Amount, Version, Variant, Context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TypeContext"></typeparam>
        /// <param name="Generator"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        public static UUID[] CreateUUIDs<TypeContext>(Int32 Amount, IUUIDGenerator<TypeContext> Generator, TypeContext[] Context) {
            UUID[] Out = new UUID[Amount];

            if (Generator == null) { return new UUID[] { UUID.Nill }; }
            if (Context == null) { Context = new TypeContext[] { default }; }
            Int32 J = 0;
            Int32 Max = Context.Length - 1;

            for (Int32 I = 0; I < Amount; I++) {
                Out[I] = Generator.Generate(Context[J++]);

                if (J > Max) { J = 0; }
            }

            return Out;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TypeContext"></typeparam>
        /// <param name="Generator"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        public static UUID CreateUUID<TypeContext>(IUUIDGenerator<TypeContext> Generator, TypeContext Context) {
            return Generator?.Generate(Context) ?? UUID.Nill;
        }
    }
}
