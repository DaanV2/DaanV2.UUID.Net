
using System;

namespace DaanV2.UUID.Generators {
    public partial class GeneratorInfo {
        /// <summary>The version of the UUID generator</summary>
        private Int32 _Version;

        /// <summary>The variant of the UUID generator</summary>
        private Int32 _Variant;

        /// <summary>Marks if this <see cref="IUUIDGenerator"/> needs context to generate <see cref="UUID"/>s</summary>
        private Boolean _NeedContext;

        /// <summary>The type that this <see cref="IUUIDGenerator"/> needs to generate a <see cref="UUID"/></summary>
        private Type _ContextType;

        /// <summary>The type of generator to be used</summary>
        private Type _GeneratorType;
    }
}
