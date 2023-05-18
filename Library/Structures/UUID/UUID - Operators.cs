using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Boolean operator ==(UUID left, UUID right) {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Boolean operator !=(UUID left, UUID right) {
        return !(left == right);
    }
}