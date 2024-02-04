using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <summary>Extracts the three given data set that a UUID holds, without version and variant</summary>
    /// <param name="uuid">The UUID to extract the data from</param>
    /// <returns>48 bits of data, 12 bits of data, and 62 bits data</returns>
    public static (UInt64 bits48, UInt16 bits12, UInt64 bits62) Extract(UUID uuid) {
        Vector128<UInt64> d = uuid._Data.Reverse().AsUInt64();

        UInt64 dataA = d.GetElement(1);
        UInt64 dataC = d.GetElement(0);
        // Lower 12 bits of the first 64 bits
        UInt16 dataB = (UInt16)(dataA & 0b1111_1111_1111);

        // Remove the lower 16 bits, so we have 48 bits of data
        dataA >>= 16;

        // Remove top 2 bits, so we have 62 bits of data
        const UInt64 mask = 0xC000000000000000u;
        dataC = (dataC & ~mask);

        return (dataA, dataB, dataC);
    }
}