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
        UInt64 t = (UInt64)timestamp.ToFileTimeUtc();

        return Generate(t, randomA, randomB);
    }

    /// <inheritdoc cref="Generate()"/>
    public static UUID Generate(UInt64 utc, UInt16 randomA, UInt64 randomB) {
        Vector128<Byte> u = Format.Create(V7.Version, V7.Variant, utc, randomA, randomB);

        return new UUID(u);
    }
}
