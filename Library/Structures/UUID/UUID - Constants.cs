using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>The amount of bytes in a UUID</summary>
    public const Int32 BYTE_LENGTH = Format.UUID_BYTE_LENGTH;
    /// <summary>The length of a string UUID</summary>
    public const Int32 STRING_LENGTH = Format.UUID_STRING_LENGTH;
    /// <summary>The amount of bits in a UUID</summary>
    public const Int32 BITS_AMOUNT = Format.UUID_BITS;

    /// <summary>00000000-0000-0000-0000-000000000000</summary>
    public static readonly UUID Zero = new(Vector128<Byte>.Zero);
}
