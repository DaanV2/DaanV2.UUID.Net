using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public partial class Generator {
    /// <summary>Turns the given data into a <see cref="UUID"/></summary>
    /// <param name="data">The data to use</param>
    /// <returns>A <see cref="UUID"/></returns>
    public UUID Create(ReadOnlySpan<Byte> data) {
        return this.Create(Vector128.Create(data));
    }

    /// <summary>Turns the given data into a <see cref="UUID"/></summary>
    /// <param name="data">The data to use</param>
    /// <returns>A <see cref="UUID"/></returns>
    public UUID Create(Vector128<Byte> data) {
        Vector128<Byte> uuid = Format.StampVersion(this._Mask, this._Overlay, data);

        return new UUID(uuid);
    }
}
