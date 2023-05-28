using System.Runtime.CompilerServices;
using System.Text;

namespace DaanV2.UUID;
public static partial class V5 {
    /// <summary>Cuts up the given data into chunks and each gets turned into a <see cref="UUID"/></summary>
    /// <param name="source">The data to create a <see cref="UUID[]"/> from</param>
    /// <returns>A new <see cref="UUID[]"/></returns>
    public static UUID[] GenerateBatch(String source) {
        return GenerateBatch(source, Encoding.UTF8);
    }

    /// <summary>Cuts up the given data into chunks and each gets turned into a <see cref="UUID"/></summary>
    /// <param name="source">The data to create a <see cref="UUID[]"/> from</param>
    /// <param name="encoding">The encoding to use to turn the string to bytes</param>
    /// <returns>A new <see cref="UUID[]"/></returns>
    public static UUID[] GenerateBatch(String source, Encoding encoding) {
        Byte[] bytes = encoding.GetBytes(source);
        return GenerateBatch(bytes);
    }

    /// <summary>Cuts up the given data into chunks and each gets turned into a <see cref="UUID"/></summary>
    /// <param name="source">The data to create a <see cref="UUID[]"/> from</param>
    /// <returns>A new <see cref="UUID[]"/></returns>
    public static UUID[] GenerateBatch(Byte[] source) {
        return GenerateBatch(source.AsSpan());
    }

    /// <summary>Cuts up the given data into chunks and each gets turned into a <see cref="UUID"/></summary>
    /// <param name="source">The data to create a <see cref="UUID[]"/> from</param>
    /// <returns>A new <see cref="UUID[]"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID[] GenerateBatch(ReadOnlySpan<Byte> source) {
        Int32 count = source.Length;
        Int32 amount = count / MinimumDataLength;
        Int32 max = count - MinimumDataLength;
        var uuids = new UUID[amount];

        Int32 J = 0;
        for (Int32 I = 0; I <= max; I += MinimumDataLength) {
            uuids[J++] = Generate(source.Slice(I, MinimumDataLength));
        }

        return uuids;
    }
}
