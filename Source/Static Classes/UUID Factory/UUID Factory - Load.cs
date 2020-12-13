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
using System.Reflection;
using DaanV2.UUID.Generators;

namespace DaanV2.UUID {
    public static partial class UUIDFactory {
        /// <summary>Loads all <see cref="IUUIDGenerator"/>s</summary>
        public static void Load() {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Int32 Count = assemblies.Length;

            for (Int32 I = 0; I < Count; I++) {
                Load(assemblies[I]);
            }
        }

        /// <summary>Loads all <see cref="IUUIDGenerator"/>s from the given assembly</summary>
        /// <param name="asm">The assemblies to spit through</param>
        public static void Load(Assembly asm) {
            try {
                Type[] types = asm.GetTypes();
                Int32 Count = types.Length;
                Type[] Interfaces;
                Int32 JCount;
                Type Current;

                for (Int32 I = 0; I < Count; I++) {
                    Current = types[I];

                    if (Current.IsAbstract) {
                        continue;
                    }

                    Interfaces = Current.GetInterfaces();
                    JCount = Interfaces.Length;

                    for (Int32 J = 0; J < JCount; J++) {
                        if (Interfaces[J] == typeof(IUUIDGenerator)) {
                            var Generator = (IUUIDGenerator)Activator.CreateInstance(Current);
                            Add(Generator);

                            break;
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>Add the given generator to the interal list</summary>
        /// <param name="Generator">The generator to add to the list</param>
        public static void Add(IUUIDGenerator Generator) {
            Int32 Variant = Generator.Variant;
            Int32 Version = Generator.Version;

            if (UUIDFactory._Generators.Length <= Version) {
                Array.Resize(ref UUIDFactory._Generators, Version + 1);
            }

            if (UUIDFactory._Generators[Version] == null) {
                UUIDFactory._Generators[Version] = new GeneratorInfo[Variant + 1];
            }

            if (UUIDFactory._Generators[Version].Length <= Variant) {
                Array.Resize(ref UUIDFactory._Generators[Version], Variant + 1);
            }

            UUIDFactory._Generators[Version][Variant] = new GeneratorInfo(Generator);
        }
    }
}
