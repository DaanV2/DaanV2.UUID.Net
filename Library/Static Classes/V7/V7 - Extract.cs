namespace DaanV2.UUID;

public static partial class V7 {
    /// <summary>Extracts the UTC from the UUID</summary>
    /// <param name="uuid">The <see cref="UUID"/> to extract the UTC from</param>
    /// <returns>The UTC value</returns>
    public static UInt64 ExtractUtc(UUID uuid) {
        (UInt64 bits48, _, _) = Format.Extract(uuid);

        return bits48;
    }

    /// <summary>Extracts the datetime from the UUID</summary>
    /// <param name="uuid">The <see cref="UUID"/> to extract the UTC from</param>
    /// <returns>The <see cref="DateTime"/></returns>
    public static DateTime Extract(UUID uuid) {
        UInt64 fileUTC = ExtractUtc(uuid);

        return DateTime.FromFileTimeUtc((Int64)fileUTC);
    }
}
