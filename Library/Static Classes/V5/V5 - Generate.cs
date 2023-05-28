using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Text;

namespace DaanV2.UUID;
public static partial class V5 {
    /// <summary>Generates a <see cref="UUID"/> from the given data</summary>
    /// <param name="source">The data to create a <see cref="UUID"/> from</param>
    /// <returns>A new <see cref="UUID"/></returns>
    public static UUID Generate(String source) {
        return Generate(source, Encoding.UTF8);
    }

    /// <summary>Generates a <see cref="UUID"/> from the given data</summary>
    /// <param name="source">The data to create a <see cref="UUID"/> from</param>
    /// <param name="encoding">The encoding to use to turn the string to bytes</param>
    /// <returns>A new <see cref="UUID"/></returns>
    public static UUID Generate(String source, Encoding encoding) {
        Byte[] bytes = encoding.GetBytes(source);

        return Generate(bytes);
    }

    /// <summary>Generates a <see cref="UUID"/> from the given data</summary>
    /// <param name="source">The data to create a <see cref="UUID"/> from</param>
    /// <returns>A new <see cref="UUID"/></returns>
    public static UUID Generate(Byte[] source) {
        return Generate(source.AsSpan());
    }

    /// <summary>Generates a <see cref="UUID"/> from the given data</summary>
    /// <param name="source">The data to create a <see cref="UUID"/> from</param>
    /// <returns>A new <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID Generate(ReadOnlySpan<Byte> source) {
        Span<Byte> hash = stackalloc Byte[SHA1.HashSizeInBytes];
        _ = SHA1.HashData(source, hash);

        var data = Vector128.Create<Byte>(hash);
        Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
        return new UUID(uuid);
    }
}
