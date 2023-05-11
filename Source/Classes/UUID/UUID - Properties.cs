
using System;
using System.Runtime.Serialization;

namespace DaanV2.UUID {
    public partial class UUID {
        /// <summary>Gets or sets the chars of this <see cref="UUID"/></summary>
        [DataMember]
        public Char[] Chars { get => this._Chars; private set => this._Chars = value; }    
    }
}
