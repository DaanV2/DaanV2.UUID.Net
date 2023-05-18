using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public partial struct UUID {
    /// <summary>Converts a <see cref="Guid"/> to <see cref="UUID"/></summary>
    /// <param name="guid">The <see cref="Guid"/> to convert to <see cref="UUID"/></param>
    /// <returns>Returns a <see cref="UUID"/></returns>
    public static UUID From(Guid guid) {
        return Convert.ToUUID(guid);
    }

    /// <summary>Implicitly casts a <see cref="Guid"/> to a <see cref="UUID"/></summary>
    /// <param name="guid"></param>
    public static implicit operator UUID(Guid guid) {
        return Convert.ToUUID(guid);
    }
}
