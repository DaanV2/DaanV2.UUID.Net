using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V7 {
    /// <summary>Generates a new random <see cref="UUID"/></summary>
    /// <param name="timestamp">The timestamp to include</param>
    /// <param name="random">The random data to put on the end</param>
    /// <param name="rnd">The randomizer to used</param>
    /// <param name="bytes10">10 bytes of random data</param>
    /// <returns>A new <see cref="UUID"/></returns>
    public static UUID Generate() {
        DateTime timestamp = DateTime.UtcNow;
        return Generate(timestamp);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(DateTime timestamp) {
        return Generate(timestamp, Random.Shared);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(Random rnd) {
        DateTime timestamp = DateTime.UtcNow;
        return Generate(timestamp, rnd);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(ReadOnlySpan<Byte> bytes10) {
        DateTime timestamp = DateTime.UtcNow;
        return Generate(timestamp, bytes10);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(DateTime timestamp, Random rnd) {
        UInt16 randomA = (UInt16)rnd.Next();
        UInt64 randomB = (UInt64)rnd.Next();

        return Generate(timestamp, randomA, randomB);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(DateTime timestamp, ReadOnlySpan<Byte> bytes10) {
        UInt16 randomA = BitConverter.ToUInt16(bytes10);
        UInt64 randomB = BitConverter.ToUInt64(bytes10[2..]);

        return Generate(timestamp, randomA, randomB);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(UInt64 utc, Random rnd) {
        UInt16 randomA = (UInt16)rnd.Next();
        UInt64 randomB = (UInt64)rnd.Next();

        return Generate(utc, randomA, randomB);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(UInt64 utc, ReadOnlySpan<Byte> bytes10) {
        UInt16 randomA = BitConverter.ToUInt16(bytes10);
        UInt64 randomB = BitConverter.ToUInt64(bytes10[2..]);

        return Generate(utc, randomA, randomB);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(DateTime timestamp, UInt16 randomA, UInt64 randomB) {
        // RFC9562: V7 uses Unix epoch timestamp in milliseconds (48 bits)
        UInt64 unixMs = DateTimeToUnixMilliseconds(timestamp);

        return Generate(unixMs, randomA, randomB);
    }

    /// <inheritdoc cref="Generate()"/>
    /// <param name="unixMs">Unix timestamp in milliseconds (48-bit value)</param>
    /// <param name="randomA">12 bits of random data</param>
    /// <param name="randomB">62 bits of random data</param>
    public static UUID Generate(UInt64 unixMs, UInt16 randomA, UInt64 randomB) {
        Vector128<Byte> u = Format.Create(V7.Version, V7.Variant, unixMs, randomA, randomB);

        return new UUID(u);
    }
    
    /// <summary>Converts a DateTime to Unix milliseconds</summary>
    /// <param name="timestamp">The DateTime to convert</param>
    /// <returns>Milliseconds since Unix epoch (1970-01-01 00:00:00 UTC)</returns>
    private static UInt64 DateTimeToUnixMilliseconds(DateTime timestamp) {
        // Unix epoch: January 1, 1970 00:00:00 UTC
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var milliseconds = (timestamp.ToUniversalTime() - unixEpoch).TotalMilliseconds;
        
        // Ensure non-negative and within 48-bit range
        if (milliseconds < 0) milliseconds = 0;
        if (milliseconds > 0xFFFFFFFFFFFF) milliseconds = 0xFFFFFFFFFFFF;
        
        return (UInt64)milliseconds;
    }
}
