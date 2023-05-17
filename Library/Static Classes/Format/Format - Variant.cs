using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    public const Int32 VARIANT_BYTE_INDEX = 8;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Variant GetVariant(ReadOnlySpan<Byte> data) {
        return GetVariant(data[VARIANT_BYTE_INDEX]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Variant GetVariant<T>(Vector128<T> data)
        where T : struct {
        return GetVariant(Vector128.AsByte(data)[VARIANT_BYTE_INDEX]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Variant GetVariant(Byte data) {
        // 0 x x.
        // 1 0 x
        // 1 1 0
        // 1 1 1

        if ((data & GetMask(Variant.V0)) == (UInt32)Variant.V0) {
            return Variant.V0;
        }
        if ((data & GetMask(Variant.V1)) == (UInt32)Variant.V1) {
            return Variant.V1;
        }
        if ((data & GetMask(Variant.V2)) == (UInt32)Variant.V2) {
            return Variant.V2;
        }
        if ((data & GetMask(Variant.V3)) == (UInt32)Variant.V3) {
            return Variant.V3;
        }

        return Variant.V0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static UInt32 GetMask(this Variant variant) {
        // 0 x x. 0 bits => 0b1000_0000
        // 1 0 x. 1 bits => 0b1100_0000
        // 1 1 0. 2 bits => 0b1110_0000
        // 1 1 1. 3 bits => 0b1110_0000

        UInt32 bitsSet = System.Runtime.Intrinsics.X86.Popcnt.PopCount((UInt32)variant);
        Int32 r = (Int32)(bitsSet + 1);
        if (r > 3) {
            r = 3;
        }

        return ((UInt32)0b1111_0000_0000 >> r) & 0b1110_0000;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="variant"></param>
    public static Variant ToVariant(Int32 variant) {
        switch (variant) {
            case 0:
                return Variant.V0;
            case 1:
                return Variant.V1;
            case 2:
                return Variant.V2;
            case 3:
                return Variant.V3;
        }

        throw new ArgumentException($"Invalid variant {variant}", nameof(variant));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public static Int32 ToInt32(this Variant version) {
        switch (version) {
            default:
            case Variant.V0:
                return 0;
            case Variant.V1:
                return 1;
            case Variant.V2:
                return 2;
            case Variant.V3:
                return 3;
        }
    }
}