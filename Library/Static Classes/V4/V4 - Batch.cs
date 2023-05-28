using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class V4 {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static UUID[] GenerateBatch(Int32 Amount) {
        return GenerateBatch(Amount, Random.Shared);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rnd"></param>
    /// <returns></returns>
    public static UUID[] GenerateBatch(Int32 Amount, Random rnd) {
        var uuids = new UUID[Amount];

        //Cant allocate more than 1024 bytes on the stack
        const Int32 MaxStackAlloc = 1024;
        Int32 toAllocate = Format.UUID_BYTE_LENGTH * Amount;

        Span<Byte> bytes = toAllocate <= MaxStackAlloc ?
            stackalloc Byte[Format.UUID_BYTE_LENGTH * Amount] :
            new Byte[Format.UUID_BYTE_LENGTH * Amount];

        rnd.NextBytes(bytes);

        return GenerateBatch(bytes);
    }

    /// <summary>Turns the entire bytes collection into UUIDs</summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static UUID[] GenerateBatch(ReadOnlySpan<Byte> bytes) {
        Int32 count = bytes.Length;
        Int32 amount = count / Format.UUID_BYTE_LENGTH;
        Int32 max = count - Format.UUID_BYTE_LENGTH;
        var uuids = new UUID[amount];

        Int32 J = 0;
        for (Int32 I = 0; I <= max; I += Format.UUID_BYTE_LENGTH) {
            var data = Vector128.Create(bytes.Slice(I, Format.UUID_BYTE_LENGTH));
            Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
            uuids[J++] = new UUID(uuid);
        }

        return uuids;
    }

    /// <summary>Turns </summary>
    /// <param name="rnd"></param>
    /// <returns></returns>
    public static UUID[] GenerateBatch(Int32 Amount, Func<Int32, Memory<Byte>> generateContents) {
        var uuids = new UUID[Amount];

        for (Int32 I = 0; I < uuids.Length; I++) {
            Memory<Byte> bytes = generateContents(I);
            var data = Vector128.Create<Byte>(bytes.Span);
            Vector128<Byte> uuid = Format.StampVersion(_VersionMask, _VersionOverlay, data);
            uuids[I] = new UUID(uuid);
        }

        return uuids;
    }
}
