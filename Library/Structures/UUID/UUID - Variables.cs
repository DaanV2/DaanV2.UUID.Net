using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>The data field</summary>
    internal readonly Vector128<Byte> _Data;
}