using System.Buffers.Binary;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;



public static partial class V1 {
    public record Information {
        public DateTime Timestamp { get; init; }
        public Byte Nanoseconds { get; init; }
        public required Byte[] MacAddress { get; init; }
    }

    public static Information Extract(UUID uuid) {
        Span<Byte> data = stackalloc Byte[Format.UUID_BYTE_LENGTH];
        uuid._Data.CopyTo(data);

        // Extract time_low (first 32 bits)
        UInt32 timeLow = BinaryPrimitives.ReadUInt32BigEndian(data);
        UInt64 timestampTicks = (UInt64)timeLow;

        // Extract time_mid (next 16 bits)
        UInt16 timeMid = BinaryPrimitives.ReadUInt16BigEndian(data[4..]);
        timestampTicks |= (UInt64)timeMid << 32;

        // Extract time_hi_version (next 16 bits)
        UInt16 timeHiVersion = BinaryPrimitives.ReadUInt16BigEndian(data[6..]);
        timestampTicks |= (UInt64)(timeHiVersion & 0x0FFF) << 48; // Clear version bits

        // Convert timestampTicks to DateTime
        Int64 timestampFileTime = (Int64)(timestampTicks - V1.Epoch);
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
