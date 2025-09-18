using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.InteropServices;
using System;

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
    public static UUID Generate(DateTime timestamp, uint localIdentifier, ReadOnlySpan<byte> macAddress, byte domain = 0) {
        ulong uuidTimestamp = V1.TimeStamp(timestamp);

        Span<byte> data = stackalloc byte[16];

        // Write node (MAC address)
        macAddress.CopyTo(data[10..]);

        // Split timestamp
        uint timeLow = (uint)(uuidTimestamp & 0xFFFFFFFF);
        ushort timeMid = (ushort)((uuidTimestamp >> 32) & 0xFFFF);
        ushort timeHi = (ushort)((uuidTimestamp >> 48) & 0x0FFF); // 12 bits for time_hi
        ushort timeHiAndVersion = (ushort)(timeHi | ((ushort)Version.V2)); // Set version 2

        BinaryPrimitives.WriteUInt32BigEndian(data, timeLow);
        BinaryPrimitives.WriteUInt16BigEndian(data[4..], timeMid);
        BinaryPrimitives.WriteUInt16BigEndian(data[6..], timeHiAndVersion);

        // Per RFC 4122 DCE Security UUID:
        // data[8]: high 2 bits = variant, low 6 bits = high 6 bits of local identifier
        // data[9]: domain (per spec), or low 8 bits of local identifier if domain not used
        data[8] = (byte)(((localIdentifier >> 8) & 0x3F) | (byte)Variant.V1);
        data[9] = domain; // Store domain in data[9]

        var uuid = Vector128.Create<Byte>(data);
        return new UUID(uuid);
    }

    /// <summary>
    /// Gets the current user's UID (Linux only). Returns 0 if not available.
    /// </summary>
    private static uint GetCurrentUid() {
        try {
            return (uint)System.Convert.ToInt32(Environment.GetEnvironmentVariable("UID") ?? "0");
        } catch {
            return 0;
        }
    }

    /// <summary>
    /// Generates a Version 2 UUID from a byte source (not standard, but for API compatibility).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID Generate(ReadOnlySpan<Byte> source) {
        // Not standard for V2, but for API compatibility: hash and overlay version/variant
        Span<byte> data = stackalloc byte[16];
        System.Security.Cryptography.MD5.HashData(source, data);
        // Set version and variant using V2.Version and V2.Variant constants
        data[6] = (byte)((data[6] & 0x0F) | (byte)Version.V2);
        data[8] = (byte)((data[8] & 0x3F) | (byte)Variant.V1);

        var uuid = Vector128.Create<Byte>(data);
        return new UUID(uuid);
    }
}
