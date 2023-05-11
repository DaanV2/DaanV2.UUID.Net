
using System;

namespace DaanV2.UUID {
    public static partial class UUIDFactory {
        /// <summary>Generate a <see cref="UUID"/> using the specified version and variant</summary>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <param name="Context">The context needed to generate the UUID(s)</param>
        /// <returns>Generate a <see cref="UUID"/> using the specified version and variant and specified amount</returns>
        public static UUID CreateUUID(Int32 Version, Int32 Variant, Object Context = default) {
            IUUIDGenerator generator = UUIDFactory.CreateGenerator(Version, Variant);
            return generator.Generate(Context);
        }

        /// <summary>Generate a <see cref="UUID"/>[] using the specified version and variant and specified amount</summary>
        /// <param name="Amount">The amount of UUID to generate</param>
        /// <param name="Version">The version of the generator</param>
        /// <param name="Variant">The variant of the generator</param>
        /// <param name="Context">The context needed to generate the UUID(s)</param>
        /// <returns>Generate a <see cref="UUID"/>[] using the specified version and variant and specified amount</returns>
        public static UUID[] CreateUUIDs(Int32 Amount, Int32 Version, Int32 Variant, Object[] Context = default) {
            IUUIDGenerator generator = UUIDFactory.CreateGenerator(Version, Variant);
            return generator.Generate(Amount, Context);
        }
    }
}
