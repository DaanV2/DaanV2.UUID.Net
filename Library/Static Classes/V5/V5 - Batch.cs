using System.Runtime.CompilerServices;
using System.Text;

namespace DaanV2.UUID;
public static partial class V5 {
    /// <inheritdoc cref="Batch(String, Encoding)"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Byte[] source) {
        return Batch(source.AsSpan());
    }

    /// <inheritdoc cref="Batch(String, Encoding)"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(ReadOnlySpan<Byte> source) {
        return Batch(source.Length / MinimumDataLength, source);
    }

    /// <inheritdoc cref="Batch(String, Encoding)"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(String source) {
        return Batch(source, Encoding.UTF8);
    }

    /// <summary>Cuts up the given data into chunks and each gets turned into a <see cref="UUID"/></summary>
    /// <param name="source">The data to create a <see cref="UUID"/>[] from</param>
    /// <param name="encoding">The encoding to use to turn the string to bytes</param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(String source, Encoding encoding) {
        Byte[] bytes = encoding.GetBytes(source);
        return Batch(bytes);
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, String source) {
        return Batch(amount, source, Encoding.UTF8);
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, String source, Encoding encoding) {
        Byte[] bytes = encoding.GetBytes(source);
        return Batch(amount, bytes);
    }

    /// <inheritdoc cref="Batch(Int32, ReadOnlySpan{Byte})"/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(Int32 amount, Byte[] source) {
        return Batch(amount, source.AsSpan());
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

        var uuids = new UUID[amount];
        Int32 J = 0;
        for (Int32 I = 0; I < max; I += step) {
            uuids[J++] = Generate(source.Slice(I, step));
        }

        return uuids;
    }
}
