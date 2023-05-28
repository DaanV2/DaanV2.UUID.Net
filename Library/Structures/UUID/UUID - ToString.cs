using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID : IEquatable<UUID> {
    /// <inheritdoc/>
    public override String ToString() {
        return Format.ToString(this._Data);
    }
}