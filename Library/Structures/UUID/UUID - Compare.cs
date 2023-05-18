using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public partial struct UUID {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Int32 Compare(UUID other) {
        for (Int32 I = 0; I < Vector128<Byte>.Count; I++) {
            Int32 Result = this._Data[I].CompareTo(other._Data[I]);
            if (Result != 0) {
                return Result;
            }
        }

        return 0;
    }
}
