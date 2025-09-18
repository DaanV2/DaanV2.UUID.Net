using System.Buffers.Binary;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V2 {
    /// <summary>A record of what information can be returned by a <see cref="UUID"/> of version 2 (DCE Security)</summary>
    public record Information {
        /// <summary>The timestamp it was made at (may be imprecise due to overlays)</summary>
        public DateTime Timestamp { get; init; }
        /// <summary>The local identifier (UID/GID) embedded in the UUID</summary>
        public UInt16 LocalIdentifier { get; init; }
        /// <summary>The domain (person, group, org) embedded in the UUID</summary>
        public Byte Domain { get; init; }
        /// <summary>The mac address of the machine it was made on</summary>
        public required Byte[] MacAddress { get; init; }
    }

    /// <summary>Extract from the given <see cref="UUID"/> its information record, if made with <see cref="V2"/></summary>
    /// <param name="uuid">The <see cref="UUID"/> to extract from</param>
    /// <returns>A record of <see cref="Information"/></returns>
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

        // Convert timestampTicks to DateTime (uses V1 epoch, as V2 overlays V1 layout)
        Int64 timestampFileTime = (Int64)(timestampTicks - V1.Epoch);
        var timestamp = DateTime.FromFileTimeUtc(timestampFileTime);

        // Extract domain (high 6 bits of data[8])
        Byte domain = (Byte)(data[8] & 0x3F);
        // Extract local identifier (UID/GID)
        UInt16 localIdentifier = (UInt16)((data[8] & 0x3F) << 8);

        // Extract mac address
        Byte[] macAddress = data.Slice(10, 6).ToArray();

        return new Information() {
            MacAddress = macAddress,
            LocalIdentifier = localIdentifier,
            Domain = domain,
            Timestamp = timestamp
        };
    }
}
