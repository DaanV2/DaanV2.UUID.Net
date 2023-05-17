using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

///DOLATER <summary>add description for struct: UUID</summary>
public partial struct UUID {
    /// <summary>Creates a new instance of <see cref="UUID"/></summary>
    /// <param name="data">The bytes to set</param>
    public UUID(ReadOnlySpan<Byte> data) : this(Vector128.Create(data)) { }

    /// <summary>Creates a new instance of <see cref="UUID"/></summary>
    /// <param name="e0">The first part of the <see cref="UUID"/></param>
    /// <param name="e1">The second part of the <see cref="UUID"/></param>
    public UUID(UInt64 e0, UInt64 e1) : this(Vector128.Create(e0, e1).AsByte()) { }

    /// <summary>Creates a new instance of <see cref="UUID"/></summary>
    /// <param name="data">The bytes to set</param>
    public UUID(Vector128<Byte> data) {
        this._Data = data;
    }
}