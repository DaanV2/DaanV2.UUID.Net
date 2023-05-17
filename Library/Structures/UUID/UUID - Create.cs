using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

/// <summary>An Unique Universal IDentifier, 128 bits of data</summary>
public partial struct UUID {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <param name="variant"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static UUID Create(Version version, Variant variant, Vector128<Byte> data) {
        Vector128<Byte> formatted = Format.Create(version, variant, data);
        return new UUID(formatted);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <param name="variant"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static UUID Create(Version version, Variant variant, ReadOnlySpan<Byte> data) {
        return Create(version, variant, Vector128.Create(data));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <param name="variant"></param>
    /// <param name="upper"></param>
    /// <param name="lower"></param>
    /// <returns></returns>
    public static UUID Create(Version version, Variant variant, UInt64 upper, UInt64 lower) {
        return Create(version, variant, Vector128.Create(upper, lower).AsByte());
    }
}