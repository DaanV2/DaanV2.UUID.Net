namespace DaanV2.UUID;

/// <summary>The possible version numbers of UUIDs</summary>
public enum Version {
    /// <summary>The <see cref="UUID"/> version that is made from the timestamp and macaddress</summary>
    V1 = 0b0001_0000,
    /// <summary>Not Implemented</summary>
    V2 = 0b0010_0000,
    /// <summary>The <see cref="UUID"/> version that hashes (MD5) given data into <see cref="UUID"/></summary>
    V3 = 0b0011_0000,
    /// <summary>The <see cref="UUID"/> version that is made from random data</summary>
    V4 = 0b0100_0000,
    /// <summary>The <see cref="UUID"/> version that hashes (SHA1) given data into <see cref="UUID"/></summary>
    V5 = 0b0101_0000,
    /// <summary>The <see cref="UUID"/> version that is reordered Gregorian time-based UUID specified in this document.</summary></summary>
    V6 = 0b0110_0000,
    /// <summary>The <see cref="UUID"/> version that exposes Unix Epoch time-based UUID specified in this document.</summary>
    V7 = 0b0111_0000,
    /// <summary>The <see cref="UUID"/> version that allows for custom data of 122 bits of data</summary>
    V8 = 0b1000_0000,
}
