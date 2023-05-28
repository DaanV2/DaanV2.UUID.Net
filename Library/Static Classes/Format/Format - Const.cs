namespace DaanV2.UUID;

public static partial class Format {
    /// <summary>The amount of bits that are stored inside a <see cref="UUID"/></summary>
    public const Int32 UUID_BITS = 128;
    /// <summary>The amount of bytes fit inside a <see cref="UUID"/></summary>
    public const Int32 UUID_BYTE_LENGTH = UUID_BITS / (sizeof(Byte)*8);
    /// <summary>The amount of character in a UUID string</summary>
    public const Int32 UUID_STRING_LENGTH = 36;
}