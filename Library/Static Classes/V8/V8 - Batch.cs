using System.Runtime.CompilerServices;

namespace DaanV2.UUID;

public static partial class V8 {
    /// <summary>Turns the entire bytes collection into UUIDs</summary>
    /// <param name="bytes">The byte to chunk into <see cref="UUID"/></param>
    /// <returns>A collection of <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static UUID[] Batch(ReadOnlySpan<Byte> bytes) {
        return Convert.Slice(bytes, _VersionMask, _VersionOverlay);
    }
}
