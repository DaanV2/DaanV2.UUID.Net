using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID : IEquatable<UUID> {
    /// <see cref="Parse(ReadOnlySpan{Char})"/>"/>
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

    /// <see cref="TryParse(ReadOnlySpan{Char}, out UUID)"/>"/>
    public static Boolean TryParse(String uuid, out UUID result) {
        return TryParse(uuid.AsSpan(), out result);
    }

    /// <summary>Tries parsing</summary>
    /// <param name="uuid">The data to try to parse into a <see cref="UUID"/></param>
    /// <param name="result">The resulting <see cref="UUID"/></param>
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