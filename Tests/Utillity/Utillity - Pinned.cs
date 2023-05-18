using System.Runtime.Intrinsics;
using DaanV2.UUID;

namespace Tests;


public partial class Utillity {
    /// <summary>Value has been determined after testing and now here pinned.</summary>
    public const String PinnedUUID = "01234567-89ab-cdef-1133-557799bbddff";

    public static Byte[] PinnedUUIDBytes() {
        Byte[] data = new Byte[16];
        //Store 1 in the upper 4, bits and 2 in the lower 4 bits
        //And so on
        Int32 J = 0;
        for (Int32 I = 0; I < data.Length; I++) {
            Int32 upper = J;
            Int32 lower = J + 1;
            data[I] = (Byte)((upper << 4) | lower); //Store first value in the upper 4 bits and second value in the lower 4 bits
            J += 2;
        }

        return data;
    }

    public static UUID PinnedUUIDData() {
        return new UUID(PinnedUUIDBytes());
    }

    public static Vector128<Byte> PinnedUUIDVector() {
        return Vector128.Create(PinnedUUIDBytes());
    }
}
