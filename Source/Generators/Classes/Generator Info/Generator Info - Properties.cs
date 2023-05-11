
using System;

namespace DaanV2.UUID.Generators {
    public partial class GeneratorInfo {

        /// <summary>Gets or sets the version of the UUID generator</summary>
        public Int32 Version { get => this._Version; set => this._Version = value; }

        /// <summary>Gets or sets the variant of the UUID generator</summary>
        public Int32 Variant { get => this._Variant; set => this._Variant = value; }

        /// <summary>Gets or sets if this <see cref="IUUIDGenerator"/> needs context to generate <see cref="UUID"/>s</summary>
        public Boolean NeedContext { get => this._NeedContext; set => this._NeedContext = value; }

        /// <summary>Gets or sets what type this <see cref="IUUIDGenerator"/> needs to generate a <see cref="UUID"/></summary>
        public Type ContextType { get => this._ContextType; set => this._ContextType = value; }

        /// <summary>Gets or sets the type of generator to be used</summary>
        public Type GeneratorType { get => this._GeneratorType; set => this._GeneratorType = value; }
    }
}
