using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>The data field</summary>
    private readonly Vector128<Byte> _Data;
}