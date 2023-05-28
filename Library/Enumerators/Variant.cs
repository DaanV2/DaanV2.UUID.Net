namespace DaanV2.UUID;

/// <summary>Possible Variants UUID can have</summary>
public enum Variant {
    /// <summary>Reserved</summary>
    V0 = 0b0000_0000,
    /// <summary>RFC41222</summary>
    V1 = 0b1000_0000,
    /// <summary>Reserved</summary>
    V2 = 0b1100_0000,
    /// <summary>Future</summary>
    V3 = 0b1110_0000,
}