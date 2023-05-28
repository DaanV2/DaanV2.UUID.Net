using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Convert {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="uuid"></param>
    /// <returns></returns>
    public static Guid ToGuid(this UUID uuid) {
        Span<Byte> bytes = stackalloc Byte[Format.UUID_BYTE_LENGTH];
        Vector128.CopyTo(uuid._Data, bytes);

        Convert.ToBigEndianFormat(bytes);

        return new Guid(bytes);
    }
}
