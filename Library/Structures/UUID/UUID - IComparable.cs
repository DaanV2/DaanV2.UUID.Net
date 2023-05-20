using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID :
          IComparable,
          IComparable<UUID> {

    public Int32 CompareTo(Object? obj) {
        return obj is UUID uUID ? this.CompareTo(uUID) : 1;
    }

    public Int32 CompareTo(UUID other) {
        Vector128<Byte> source = this._Data;
        Vector128<Byte> target = other._Data;

        for (Int32 I = 0; I < Vector128<Byte>.Count; I++) {
            if (source.GetElement(I) > target.GetElement(I)) {
                return 1;
            }
            else if (source.GetElement(I) < target.GetElement(I)) {
                return -1;
            }
        }

        return 0;
    }
}
