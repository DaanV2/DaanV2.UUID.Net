using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V8 {
    /// <summary>Extracts the three given data set that UUID 8 holds</summary>
    /// <param name="uuid">The UUID to extract the data from</param>
    /// <returns>48 bits of data, 12 bits of data, and 62 bits data</returns>
    public static (UInt64 bits48, UInt16 bits12, UInt64 bits62) Extract(UUID uuid) {
        return Format.Extract(uuid);
    }
}
