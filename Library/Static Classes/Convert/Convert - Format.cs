namespace DaanV2.UUID;

public static partial class Convert {
    /// <summary>Converts the given binary data to big endian format, assuming the data is in little endian</summary>
    /// <param name="bytes">The bytes to process</param>
    public static void ToBigEndianFormat(Span<Byte> bytes) {
        //2a7e85ce-e301-4cef-9c47-8b1a6e2805bf
        //ce857e2a-01e3-ef4c-9c47-8b1a6e2805bf

        //Swap the bytes
        ReverseBytes(bytes[0..4]);
        ReverseBytes(bytes[4..6]);
        ReverseBytes(bytes[6..8]);
    }

    /// <summary>Converts the given binary data to little endian format, assuming the data is in big endian</summary>
    /// <param name="bytes">The bytes to process</param>
    public static void ToLittleEndianFormat(Span<Byte> bytes) {
        //2a7e85ce-e301-4cef-9c47-8b1a6e2805bf
        //ce857e2a-01e3-ef4c-9c47-8b1a6e2805bf

        //Swap the bytes
        ReverseBytes(bytes[0..4]);
        ReverseBytes(bytes[4..6]);
        ReverseBytes(bytes[6..8]);
    }

    /// <summary>A helper function to reverses the bytes in a span</summary>
    /// <param name="bytes">The bytes to process</param>
    internal static void ReverseBytes(Span<Byte> bytes) {
        Int32 max = bytes.Length / 2;
        for (Int32 I = 0; I < max; I += 1) {
            Int32 J = bytes.Length - I - 1;
            (bytes[J], bytes[I]) = (bytes[I], bytes[J]);
        }
    }
}
