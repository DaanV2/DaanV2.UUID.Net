using System.Buffers.Binary;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V6 {
    /// <summary>A record of what information can be returned by a <see cref="UUID"/> of V6 1</summary>
    public record Information {
        /// <summary>The timestamp it was made at, Note; because of overlaying with V6 and variant, might get corrupt</summary>
        public DateTime Timestamp { get; init; }
        /// <summary>The nanoseconds it was made at, Note; because of overlaying with V6 and variant, might get corrupt</summary>
        public Byte Nanoseconds { get; init; }
        /// <summary>The mac address of the machine it was made on</summary>
        public required Byte[] MacAddress { get; init; }
    }

    /// <summary>Extract from the given <see cref="UUID"/> Its information record, if made with <see cref="V6"/></summary>
    /// <param name="uuid">The <see cref="UUID"/> to extract from</param>
    /// <returns>A record of <see cref="Information"/></returns>
    public static Information Extract(UUID uuid) {
        Span<Byte> data = stackalloc Byte[Format.UUID_BYTE_LENGTH];
        uuid._Data.CopyTo(data);

        // Extract time_low (first 32 bits)
        UInt32 timeHigh = BinaryPrimitives.ReadUInt32BigEndian(data);

        // Extract time_mid (next 16 bits)
        UInt16 timeMid = BinaryPrimitives.ReadUInt16BigEndian(data[4..]);   

        // Extract time_hi_V6 (next 16 bits)
        UInt16 timeLowV6 = BinaryPrimitives.ReadUInt16BigEndian(data[6..]);

        UInt64 timestampTicks = (UInt64)timeHigh << 32;
        timestampTicks |= (UInt64)timeMid << 16;
        timestampTicks |= (UInt64)timeLowV6 & 0x0FFF; // Clear V6 bits

        // Convert timestampTicks to DateTime
        Int64 timestampFileTime = (Int64)(timestampTicks - V6.Epoch);
        var timestamp = DateTime.FromFileTimeUtc(timestampFileTime);

        // Extract clock_seq_low and nanoseconds
        Byte clockSeqLow = data[9];
        Byte nanoseconds = (Byte)(clockSeqLow & 0x3F); // Extract 6 least significant bits

        // Extract mac address
        Byte[] macAddress = data.Slice(10, 6).ToArray();

        return new Information() {
            MacAddress = macAddress,
            Nanoseconds = nanoseconds,
            Timestamp = timestamp
        };
    }
}
