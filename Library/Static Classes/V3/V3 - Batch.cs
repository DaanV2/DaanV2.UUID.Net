using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Text;

namespace DaanV2.UUID;
public static partial class V3 {
    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(String source) {
        return Batch(source, Encoding.UTF8);
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, String source) {
        return Batch(amount, source, Encoding.UTF8);
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(String source, Encoding encoding) {
        Byte[] bytes = encoding.GetBytes(source);
        return Batch(bytes);
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, String source, Encoding encoding) {
        Byte[] bytes = encoding.GetBytes(source);
        return Batch(amount, bytes);
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Byte[] source) {
        return Batch(source.AsSpan());
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, Byte[] source) {
        return Batch(amount, source.AsSpan());
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID[] Batch(ReadOnlySpan<Byte> source) {
        return Batch(source.Length / MinimumDataLength, source);
    }

    /// <summary>Cuts up the given data into chunks and each gets turned into a <see cref="UUID"/></summary>
    /// <param name="amount">How many items to cut up the data into</param>
    /// <param name="source">The data to create a <see cref="UUID"/>[] from</param>
    /// <param name="encoding">The encoding to use to turn the string to bytes</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID[] Batch(Int32 amount, ReadOnlySpan<Byte> source) {
        Int32 step = source.Length / amount;
        Int32 max = source.Length - step;

        Span<Byte> hash = stackalloc Byte[MD5.HashSizeInBytes];

        var uuids = new UUID[amount];
        Int32 J = 0;
        for (Int32 I = 0; I < max; I += step) {
            ReadOnlySpan<Byte> section = source.Slice(I, step);
            _ = MD5.TryHashData(section, hash, out Int32 _);

            var data = Vector128.Create<Byte>(hash);
            Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
            uuids[J++] = new UUID(uuid);
        }

        return uuids;
    }
}
