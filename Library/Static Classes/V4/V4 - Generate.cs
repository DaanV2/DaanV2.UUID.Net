using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V4 {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static UUID Generate() {
        return Generate(Random.Shared);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rnd"></param>
    /// <returns></returns>
    public static UUID Generate(Random rnd) {
        Span<Byte> bytes = stackalloc Byte[Format.UUID_BYTE_LENGTH];
        rnd.NextBytes(bytes);

        return Generate(bytes);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static UUID Generate(ReadOnlySpan<Byte> bytes) {
        var data = Vector128.Create(bytes);
        Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
        return new UUID(uuid);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e0"></param>
    /// <param name="e1"></param>
    /// <returns></returns>
    public static UUID Generate(UInt64 e0, UInt64 e1) {
        Vector128<Byte> data = Vector128.Create(e0, e1).AsByte();
        Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
        return new UUID(uuid);
    }
}
