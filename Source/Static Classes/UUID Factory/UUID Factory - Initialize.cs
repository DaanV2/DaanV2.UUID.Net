

using DaanV2.UUID.Generators;

namespace DaanV2.UUID {
    /// <summary>the static class that handles the generations of UUIDs or generators through version numbering</summary>
    public static partial class UUIDFactory {
        /// <summary>Creates a new instance of <see cref="UUIDFactory"/></summary>
        static UUIDFactory() {
            UUIDFactory._Generators = new GeneratorInfo[5][];
            UUIDFactory.Load();
        }
    }
}
