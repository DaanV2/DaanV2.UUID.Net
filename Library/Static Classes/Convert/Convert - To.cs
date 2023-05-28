using System.Runtime.CompilerServices;

namespace DaanV2.UUID;

///DOLATER <summary>add description for class: Converty</summary>
public static partial class Convert {
    /// <summary>Converts a <see cref="Guid"/> to <see cref="UUID"/></summary>
    /// <param name="guid">The <see cref="Guid"/> to convert to <see cref="UUID"/></param>
    /// <returns>Returns a <see cref="UUID"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static UUID ToUUID(Guid guid) {
        //If not the same, just copy the bytes
        Span<Byte> bytes = stackalloc Byte[Format.UUID_BYTE_LENGTH];
        guid.TryWriteBytes(bytes);

        Convert.ToLittleEndianFormat(bytes);

        return new UUID(bytes);
    }
}
