using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;




public static partial class V8 {
    /// <summary>Creates a <see cref="UUID"/> of the data around the version and variant, the provided data will be placed around the version and variant</summary>
    /// <param name="dataA">48 bits of data, top 16 will be removed</param>
    /// <param name="dataB">12 bits of data, top 4 will be removed</param>
    /// <param name="dataC">62 bits of data, top 2 will be removed</param>
    /// <returns>A new <see cref="UUID"/></returns>
    public static UUID Generate(UInt64 dataA, UInt16 dataB, UInt64 dataC) {
        Vector128<Byte> u = Format.Create(V8.Version, V8.Variant, dataA, dataB, dataC);
        return new UUID(u);
    }


    /// <summary>Generates a <see cref="UUID"/> from the given data, will override the necessary bits to write the version and variant</summary>
    /// <param name="source">The data to create a <see cref="UUID"/> from</param>
    /// <returns>A new <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID Generate(ReadOnlySpan<Byte> source) {
        Vector128<Byte> u = Format.Create(V8.Version, V8.Variant, source);
        return new UUID(u);
    }
}
