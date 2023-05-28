namespace DaanV2.UUID;
public static partial class V5 {
    /// <summary>Checks if the data source has the correct length for turning into a <see cref="UUID"/></summary>
    /// <param name="amount">The amount of bytes in the collection</param>
    /// <returns>True if has the minimum length requirement</returns>
    public static Boolean HasMinimumLength(Int32 amount) {
        return amount >= MinimumDataLength;
    }

    /// <summary>Throws an error if the minimum length is not met</summary>
    /// <param name="amount">The amount of bytes in the collection</param>
    /// <exception cref="Exception">Throw if the minimum amount of data is not met</exception>
    public static void ThrowIfMinimumLength(Int32 amount) {
        if (!HasMinimumLength(amount)) {
            throw new Exception($"Source data must be at least {MinimumDataLength} bytes");
        }
    }

}
