using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <summary>The index of where the variant in located in a byte array</summary>
    public const Int32 VARIANT_BYTE_INDEX = 8;

    /// <inheritdoc cref="GetVariant(Byte)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Variant GetVariant(ReadOnlySpan<Byte> data) {
        return GetVariant(data[VARIANT_BYTE_INDEX]);
    }

    /// <inheritdoc cref="GetVariant(Byte)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Variant GetVariant<T>(Vector128<T> data)
        where T : struct {
        return GetVariant(Vector128.AsByte(data)[VARIANT_BYTE_INDEX]);
    }

    /// <summary>Retrieves the variant from the given data</summary>
    /// <param name="data">The data to retrieve the variant from</param>
    /// <returns>The <see cref="Variant"/></returns>
    /// <exception cref="ArgumentException">Thrown if the value has an invalid variant value</exception>
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

        throw new ArgumentException($"Value is not a valid Variant value {data}", nameof(data));
    }

    /// <summary>Returns a mask that allows to set/get this specific <see cref="Variant"/></summary>
    /// <param name="variant">The variant to get the mask for</param>
    /// <returns>A <see cref="UInt32"/> containing the mask</returns>
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

        //Shift a mask to the right and then & it with another to get the mask
        return ((UInt32)0b1111_0000_0000 >> r) & 0b1110_0000;
    }

    /// <summary>Retrieves the <see cref="Variant"/> that fits the specific <see cref="Variant"/></summary>
    /// <param name="variant">The value to convert</param>
    /// <returns>A <see cref="Variant"/></returns>
    /// <exception cref="ArgumentException">Throw if out of range</exception>
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

    /// <summary>Converts this variant to its <see cref="Int32"/> representation</summary>
    /// <param name="variant">The variant to convert</param>
    /// <returns>A <see cref="Int32"/></returns>
    public static Int32 ToInt32(this Variant variant) {
        switch (variant) {
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