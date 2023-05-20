namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>Converts a <see cref="Guid"/> to <see cref="UUID"/></summary>
    /// <param name="guid">The <see cref="Guid"/> to convert to <see cref="UUID"/></param>
    /// <returns>Returns a <see cref="UUID"/></returns>
    public static UUID From(Guid guid) {
        return Convert.ToUUID(guid);
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
}
