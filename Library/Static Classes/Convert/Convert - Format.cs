namespace DaanV2.UUID;

public static partial class Convert {
    public static void ToBigEndianFormat(Span<Byte> bytes) {
        //2a7e85ce-e301-4cef-9c47-8b1a6e2805bf
        //ce857e2a-01e3-ef4c-9c47-8b1a6e2805bf

        //Swap the bytes
        SwapBytes(bytes[0..4]);
        SwapBytes(bytes[4..6]);
        SwapBytes(bytes[6..8]);
    }

    public static void ToLittleEndianFormat(Span<Byte> bytes) {
        //2a7e85ce-e301-4cef-9c47-8b1a6e2805bf
        //ce857e2a-01e3-ef4c-9c47-8b1a6e2805bf

        //Swap the bytes
        SwapBytes(bytes[0..4]);
        SwapBytes(bytes[4..6]);
        SwapBytes(bytes[6..8]);
    }

    internal static void SwapBytes(Span<Byte> bytes) {
        Int32 max = bytes.Length / 2;
        for (Int32 I = 0; I < max; I += 1) {
            Int32 J = bytes.Length - I - 1;
            (bytes[J], bytes[I]) = (bytes[I], bytes[J]);
        }
    }
}
