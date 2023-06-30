using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V4 {
    /// <inheritdoc cref="Generate(UInt64, UInt64)"/>
    public static UUID Generate() {
        return Generate(Random.Shared);
    }

    /// <inheritdoc cref="Generate(UInt64, UInt64)"/>
    public static UUID Generate(Random rnd) {
        Span<Byte> bytes = stackalloc Byte[Format.UUID_BYTE_LENGTH];
        rnd.NextBytes(bytes);

        return Generate(bytes);
    }

    /// <inheritdoc cref="Generate(UInt64, UInt64)"/>
    public static UUID Generate(Stream stream) {
        Span<Byte> bytes = stackalloc Byte[Format.UUID_BYTE_LENGTH];
        stream.Read(bytes);

        return Generate(bytes);
    }

    /// <inheritdoc cref="Generate(UInt64, UInt64)"/>
    public static UUID Generate(ReadOnlySpan<Byte> bytes) {
        var data = Vector128.Create(bytes);
        Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
        return new UUID(uuid);
    }

    /// <summary>Generates a new random <see cref="UUID"/></summary>
    /// <param name="e0">The lower set of data</param>
    /// <param name="e1">The higher set of data</param>
    /// <param name="bytes">The byte to use to fill the <see cref="UUID"/> expects it to be atleast 16 bytes long</param>
    /// <param name="rnd">The randomizer to use to create <see cref="UUID"/></param>
    /// <param name="stream">The stream to read from, will read <see cref="Format.UUID_BYTE_LENGTH"/> bytes</param>
    /// <returns>A new <see cref="UUID"/></returns>
    public static UUID Generate(UInt64 e0, UInt64 e1) {
        Vector128<Byte> data = Vector128.Create(e0, e1).AsByte();
        Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
        return new UUID(uuid);
    }
}
