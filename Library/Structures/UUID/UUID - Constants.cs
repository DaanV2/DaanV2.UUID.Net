using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public partial struct UUID {
    /// <summary>00000000-0000-0000-0000-000000000000</summary>
    public static readonly UUID Zero = new(Vector128<Byte>.Zero);
}
