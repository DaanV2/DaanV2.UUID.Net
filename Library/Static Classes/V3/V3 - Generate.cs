using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Text;

namespace DaanV2.UUID;
public static partial class V3 {
    /// <inheritdoc cref="Generate(ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate() {
        return Generate(DateTime.Now.ToString());
    }


    /// <inheritdoc cref="Generate(ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(String source) {
        return Generate(source, Encoding.UTF8);
    }

    /// <inheritdoc cref="Generate(ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(String source, Encoding encoding) {
        Byte[] bytes = encoding.GetBytes(source);

        return Generate(bytes);
    }

    /// <inheritdoc cref="Generate(ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID Generate(Byte[] source) {
        return Generate(source.AsSpan());
    }

    /// <summary>Generates a <see cref="UUID"/> from the given data by hashing (MD5) it</summary>
    /// <param name="source">The data to create a <see cref="UUID"/> from</param>
    /// <param name="encoding">The encoding to use to turn the string to bytes</param>
    /// <returns>A new <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID Generate(ReadOnlySpan<Byte> source) {
        Span<Byte> hash = stackalloc Byte[SHA1.HashSizeInBytes];
        _ = MD5.TryHashData(source, hash, out Int32 _);

        var data = Vector128.Create<Byte>(hash);
        Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
        return new UUID(uuid);
    }
}
