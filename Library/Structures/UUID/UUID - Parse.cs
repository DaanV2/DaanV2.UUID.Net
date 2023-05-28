using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID : IEquatable<UUID> {
    /// <summary>Parses the given string into a <see cref="UUID"/></summary>
    /// <param name="uuid">The string uuid representation to parse</param>
    /// <returns>A <see cref="UUID"/></returns>
    public static UUID Parse(String uuid) {
        return Parse(uuid.AsSpan());
    }

    /// <summary>Parses the given characters into a <see cref="UUID"/></summary>
    /// <param name="uuid">The characters uuid representation to parse</param>
    /// <returns>A <see cref="UUID"/></returns>
    public static UUID Parse(ReadOnlySpan<Char> uuid) {
        Vector128<Byte> data = Format.Parse(uuid);
        return new UUID(data);
    }

    public static Boolean TryParse(String uuid, out UUID result) {
        return TryParse(uuid.AsSpan(), out result);
    }

    /// <summary>Tries parsing</summary>
    /// <param name="data"></param>
    /// <param name="uuid"></param>
    /// <returns></returns>
    public static Boolean TryParse(ReadOnlySpan<Char> uuid, out UUID result) {
        Boolean r = false;

        try {
            result = Parse(uuid);
            r = true;
        }
        catch (Exception) {
            result = default;
        }

        return r;
    }
}