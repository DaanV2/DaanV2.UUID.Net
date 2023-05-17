namespace DaanV2.UUID;

/// <summary>The possible version numbers of UUIDs</summary>
public enum Version {
    V1 = 0b0001_0000,
    V2 = 0b0010_0000,
    /// <summary>Hashed froms given names</summary>
    V3 = 0b0011_0000,
    /// <summary>Random bits</summary>
    V4 = 0b0100_0000,
    /// <summary>Hashed froms given names</summary>
    V5 = 0b0101_0000,
}
