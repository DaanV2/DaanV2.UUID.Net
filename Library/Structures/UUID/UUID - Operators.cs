namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Boolean operator ==(UUID left, UUID right) {
        return left._Data == right._Data;
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