using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>Converts a <see cref="Guid"/> to <see cref="UUID"/></summary>
    /// <param name="guid">The <see cref="Guid"/> to convert to <see cref="UUID"/></param>
    /// <returns>Returns a <see cref="UUID"/></returns>
    public static UUID From(Guid guid) {
        return Convert.ToUUID(guid);
    }

    /// <summary>Converts a <see cref="UInt128"/> to <see cref="UUID"/></summary>
    /// <param name="value">The <see cref="UInt128"/> to convert to <see cref="UUID"/></param>
    /// <returns>Returns a <see cref="UUID"/></returns>
    public static UUID From(UInt128 value) {
        Vector128<Byte> data = Vector128.Create(value).AsByte();

        return new UUID(data);
    }

    /// <summary>Implicitly casts a <see cref="Guid"/> to a <see cref="UUID"/></summary>
    /// <param name="guid">The <see cref="Guid"/> to convert</param>
    public static implicit operator UUID(Guid guid) {
        return Convert.ToUUID(guid);
    }

    /// <summary>Implicitly casts a <see cref="UUID"/> to a <see cref="Guid"/></summary>
    /// <param name="uuid">The <see cref="UUID"/> to convert</param>
    public static implicit operator Guid(UUID uuid) {
        return Convert.ToGuid(uuid);
    }

    /// <summary>Implicitly casts a <see cref="UInt128"/> to a <see cref="UUID"/></summary>
    /// <param name="value">The <see cref="UInt128"/> to convert</param>
    public static implicit operator UUID(UInt128 value) {
        return From(value);
    }

    /// <summary>Implicitly casts a <see cref="UUID"/> to a <see cref="UInt128"/></summary>
    /// <param name="uuid">The <see cref="UUID"/> to convert</param>
    public static implicit operator UInt128(UUID uuid) {
        Vector128<UInt64> data = uuid._Data.AsUInt64();
        return new UInt128(data.GetElement(1), data.GetElement(0));
    }
}
