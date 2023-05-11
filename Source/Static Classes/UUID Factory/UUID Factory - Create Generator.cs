
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
