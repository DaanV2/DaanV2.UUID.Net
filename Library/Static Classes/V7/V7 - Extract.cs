namespace DaanV2.UUID;

public static partial class V7 {
    /// <summary>Extracts the Unix milliseconds timestamp from the UUID</summary>
    /// <param name="uuid">The <see cref="UUID"/> to extract the timestamp from</param>
    /// <returns>Unix timestamp in milliseconds</returns>
    public static UInt64 ExtractUtc(UUID uuid) {
        (UInt64 bits48, _, _) = Format.Extract(uuid);

        return bits48;
    }

    /// <summary>Extracts the datetime from the UUID</summary>
    /// <param name="uuid">The <see cref="UUID"/> to extract the timestamp from</param>
    /// <returns>The <see cref="DateTime"/></returns>
    public static DateTime Extract(UUID uuid) {
        UInt64 unixMs = ExtractUtc(uuid);

        return UnixMillisecondsToDateTime(unixMs);
    }
    
    /// <summary>Converts Unix milliseconds to DateTime</summary>
    /// <param name="unixMs">Milliseconds since Unix epoch (1970-01-01 00:00:00 UTC)</param>
    /// <returns>The corresponding DateTime in UTC</returns>
    private static DateTime UnixMillisecondsToDateTime(UInt64 unixMs) {
        // Unix epoch: January 1, 1970 00:00:00 UTC
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        try {
            return unixEpoch.AddMilliseconds(unixMs);
        }
        catch (ArgumentOutOfRangeException) {
            // If the milliseconds value is too large, return MaxValue
            return DateTime.MaxValue;
        }
    }
}
