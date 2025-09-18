using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V2 {
    /// <summary>
    /// Generates a Version 2 (DCE Security) UUID using the current time, UID, and MAC address.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate() {
        // Use current time, current UID, and MAC address
        return Generate(DateTime.UtcNow, GetCurrentUid(), V1.GetMacAddressBytes());
    }

    /// <summary>
    /// Generates a Version 2 UUID with custom timestamp, UID, and MAC address.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(DateTime timestamp, UInt32 localIdentifier, ReadOnlySpan<Byte> macAddress, Byte domain = 0) {
        UInt64 uuidTimestamp = V1.TimeStamp(timestamp);

        Span<Byte> data = stackalloc Byte[16];

        // Write node (MAC address)
        macAddress.CopyTo(data[10..]);

        // Split timestamp
        UInt32 timeLow = (UInt32)(uuidTimestamp & 0xFFFFFFFF);
        UInt16 timeMid = (UInt16)((uuidTimestamp >> 32) & 0xFFFF);
        UInt16 timeHi = (UInt16)((uuidTimestamp >> 48) & 0x0FFF); // 12 bits for time_hi

        BinaryPrimitives.WriteUInt32BigEndian(data, timeLow);
        BinaryPrimitives.WriteUInt16BigEndian(data[4..], timeMid);
        BinaryPrimitives.WriteUInt16BigEndian(data[6..], timeHi);

        // Per RFC 4122 DCE Security UUID:
        // data[8]: high 2 bits = variant, low 6 bits = high 6 bits of local identifier
        // data[9]: domain (per spec), or low 8 bits of local identifier if domain not used
        data[8] = (Byte)((localIdentifier >> 8) & 0x3F);
        data[9] = domain; // Store domain in data[9]
        Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);

        return new UUID(uuid);
    }

    /// <summary>
    /// Gets the current user's UID (Linux only). Returns 0 if not available.
    /// </summary>
    private static UInt32 GetCurrentUid() {
        try {
            return (UInt32)System.Convert.ToInt32(Environment.GetEnvironmentVariable("UID") ?? "0");
        }
        catch {
            return 0;
        }
    }

    /// <summary>
    /// Generates a Version 2 UUID from a byte source (not standard, but for API compatibility).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID Generate(ReadOnlySpan<Byte> source) {
        // Not standard for V2, but for API compatibility: hash and overlay version/variant
        Span<Byte> data = stackalloc Byte[16];
        System.Security.Cryptography.MD5.HashData(source, data);
        // Set version and variant using V2.Version and V2.Variant constants
        data[6] = (Byte)((data[6] & 0x0F) | (Byte)Version.V2);
        data[8] = (Byte)((data[8] & 0x3F) | (Byte)Variant.V1);

        var uuid = Vector128.Create<Byte>(data);
        return new UUID(uuid);
    }
}
