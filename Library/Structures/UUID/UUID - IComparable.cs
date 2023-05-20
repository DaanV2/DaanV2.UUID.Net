using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID :
          IComparable,
          IComparable<UUID> {

    /// <inheritdoc/>
    public Int32 CompareTo(Object? obj) {
        return obj is UUID uUID ? this.CompareTo(uUID) : 1;
    }

    /// <inheritdoc/>
    public Int32 CompareTo(UUID other) {
        Vector128<Byte> source = this._Data;
        Vector128<Byte> target = other._Data;

        for (Int32 I = 0; I < Vector128<Byte>.Count; I++) {
            Int32 R = source[I].CompareTo(target[I]);
            if (R != 0) {
                return R;
            }
        }

        return 0;
    }
}
