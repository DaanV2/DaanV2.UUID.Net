
using System;
using DaanV2.UUID.Generators;

namespace DaanV2.UUID {
    public static partial class UUIDFactory {
        /// <summary>Returns the type needed for the generator needs</summary>
        /// <param name="Version">The version of the generator to use</param>
        /// <param name="Variant">The variant of the generator to use</param>
        /// <param name="ForMultipleUUIDGeneration">Marks if there should be multiple items or single</param>
        /// <returns>Returns the type needed for the generator needs</returns>
        public static Type GetContext(Int32 Version, Int32 Variant, Boolean ForMultipleUUIDGeneration = false) {
            GeneratorInfo Info = UUIDFactory.GetInfo(Version, Variant);

            return ForMultipleUUIDGeneration ?
                Info.ContextType.MakeArrayType() :
                Info.ContextType;
        }

        /// <summary>Returns if the specified generator needs context</summary>
        /// <param name="Version">The version of the generator to use</param>
        /// <param name="Variant">The variant of the generator to use</param>
        /// <returns>Returns if the specified generator needs context</returns>
        public static Boolean? NeedContext(Int32 Version, Int32 Variant) {
            GeneratorInfo Info = UUIDFactory.GetInfo(Version, Variant);

            return Info.NeedContext;
        }
    }
}
