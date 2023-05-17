using System.Runtime.Intrinsics;

namespace DaanV2.UUID;
public partial class Generator {
    /// <summary>Version/Variant mask</summary>
    private readonly Vector128<Byte> _Mask;
    /// <summary>Version/Variant overlay</summary>
    private readonly Vector128<Byte> _Overlay;
}
