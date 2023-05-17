using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    public const Int32 VERSION_BYTE_INDEX = 6;

    private const UInt32 _VERSION_MASK = 0b1111_0000;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Version GetVersion(ReadOnlySpan<Byte> data) {
        return GetVersion(data[VERSION_BYTE_INDEX]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Version GetVersion<T>(Vector128<T> data)
        where T : struct {
        return GetVersion(Vector128.AsByte(data)[VERSION_BYTE_INDEX]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Version GetVersion(Byte data) {
        return (Version)(data & 0b1111_0000);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void SetVersion<T>(Version version, ref Span<Byte> data)
        where T : struct {
        UInt32 carrier = data[VERSION_BYTE_INDEX];
        carrier &= ~_VERSION_MASK;
        carrier |= (UInt32)version;
        data[VERSION_BYTE_INDEX] = (Byte)carrier;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 GetMask(this Version version) {
        //Always 4 bits
        return _VERSION_MASK;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    public static Version ToVersion(Int32 version) {
        switch (version) {
            case 1:
                return Version.V1;
            case 2:
                return Version.V2;
            case 3:
                return Version.V3;
            case 4:
                return Version.V4;
            case 5:
                return Version.V5;
        }

        throw new ArgumentException($"Invalid version {version}", nameof(version));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public static Int32 ToInt32(this Version version) {
        return (Int32)version >> 4;
    }
}