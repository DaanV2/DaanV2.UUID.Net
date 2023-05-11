
using System;
using System.Runtime.Serialization;

namespace DaanV2.UUID {
    /// <summary>The class that holds the information of a <see cref="UUID"/> string</summary>
	[Serializable, DataContract]
    public partial class UUID {
        /// <summary>Creates a new instance of <see cref="UUID"/></summary>
        public UUID() {
            this._Chars = new Char[36];
        }

        /// <summary>Creates a new instance of <see cref="UUID"/></summary>
        /// <param name="Values">The char values of the <see cref="UUID"/></param>
        public UUID(Char[] Values) {
            this._Chars = Values;
        }

        /// <summary>Creates a new instance of <see cref="UUID"/></summary>
        /// <param name="Text">The string representation of the <see cref="UUID"/></param>
        public UUID(String Text) {
            this._Chars = Text.ToCharArray();
        }
    }
}
