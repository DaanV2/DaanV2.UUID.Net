using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    private static readonly Vector128<Byte> _Lower4BitsMask = Vector128.Create((Byte)0b0000_1111);
    private static readonly Vector128<Byte> _AddOverlay = Vector128.Create((Byte)'0');
    private static readonly Vector128<Byte> _9Vector = Vector128.Create((Byte)'9');
    private static readonly Vector128<Byte> _9AOffsetVector = Vector128.Create((Byte)('a' - '9' - 1));


    /// <inheritdoc cref="ToString(Vector128{Byte})"/>
    public static String ToString(ReadOnlySpan<Byte> uuid) {
        return ToString(Vector128.Create(uuid));
    }

    /// <summary>Converts the given byte data and outputs a UUID formatted string</summary>
    /// <param name="uuid">The uuid as a byte collection to output as UUID</param>
    /// <returns>A <see cref="String"/> formatted as UUID</returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static String ToString(Vector128<Byte> uuid) {


        // UUID format: 00000000-0000-0000-0000-000000000000
        Span<Char> characters = stackalloc Char[UUID_STRING_LENGTH];
        IntoSpan(uuid, characters);


        return new String(characters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uuid"></param>
    /// <param name="receiver"></param>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static void IntoSpan(Vector128<Byte> uuid, Span<Char> receiver) {
        static Vector128<Byte> RaiseNine(Vector128<Byte> data) {
            //Each element becomes 0xff if it is greater than 9
            var elementsGreatherThan = Vector128.GreaterThan(data, _9Vector);
            var toAdd = Vector128.BitwiseAnd(elementsGreatherThan, _9AOffsetVector);
            return Vector128.Add(data, toAdd);
        }

        //Upper 4 bits goes second in the string and lower 4 bits goes first in the string
        var upper = Vector128.ShiftRightLogical(uuid, 4);
        upper = Vector128.Add(upper, _AddOverlay);
        upper = RaiseNine(upper);

        var lower = Vector128.BitwiseAnd(uuid, _Lower4BitsMask);
        lower = Vector128.Add(lower, _AddOverlay);
        lower = RaiseNine(lower);

        Int32 J = 0;
        for (Int32 I = 0; I < receiver.Length;) {
            if (I is 8 or 13 or 18 or 23) {
                receiver[I++] = '-';
                continue;
            }

            receiver[I++] = (Char)upper[J];
            receiver[I++] = (Char)lower[J];
            J++;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static void IntoSpan(Vector128<Byte> uuid, Span<Byte> receiver) {
        static Vector128<Byte> RaiseNine(Vector128<Byte> data) {
            //Each element becomes 0xff if it is greater than 9
            var elementsGreatherThan = Vector128.GreaterThan(data, _9Vector);
            var toAdd = Vector128.BitwiseAnd(elementsGreatherThan, _9AOffsetVector);
            return Vector128.Add(data, toAdd);
        }

        //Upper 4 bits goes second in the string and lower 4 bits goes first in the string
        var upper = Vector128.ShiftRightLogical(uuid, 4);
        upper = Vector128.Add(upper, _AddOverlay);
        upper = RaiseNine(upper);

        var lower = Vector128.BitwiseAnd(uuid, _Lower4BitsMask);
        lower = Vector128.Add(lower, _AddOverlay);
        lower = RaiseNine(lower);

        Int32 J = 0;
        for (Int32 I = 0; I < receiver.Length;) {
            if (I is 8 or 13 or 18 or 23) {
                receiver[I++] = (Byte)'-';
                continue;
            }

            receiver[I++] = upper[J];
            receiver[I++] = lower[J];
            J++;
        }
    }

    /// <summary>Tries to parse the given string to a <see cref="UUID"/> content</summary>
    /// <param name="str">The string to parse</param>
    /// <returns>A <see cref="Vector128{T}"/></returns>
    /// <exception cref="ArgumentException">Throw if the string is not the proper length</exception>
    public static Vector128<Byte> Parse(String str) {
        return Parse(str.AsSpan());
    }

    /// <summary>Tries to parse the given string to a <see cref="UUID"/> content</summary>
    /// <param name="chars">The string to parse</param>
    /// <returns>A <see cref="Vector128{T}"/></returns>
    /// <exception cref="ArgumentException">Throw if the string is not the proper length</exception>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static Vector128<Byte> Parse(ReadOnlySpan<Char> chars) {
        if (chars.Length < UUID_STRING_LENGTH) {
            throw new ArgumentException($"The length of the string is not {chars}", nameof(chars));
        }

        //Upper 4 bits goes first in the string and lower 4 bits goes second in the string
        //We create two vectors, one for the upper 4 bits and one for the lower 4 bits
        //
        //No need to init, all values will be overwritten
        Unsafe.SkipInit(out Vector128<Byte> upper);
        Unsafe.SkipInit(out Vector128<Byte> lower);

        static Vector128<Byte> LowerNine(Vector128<Byte> data) {
            //Each element becomes 0xff if it is greater than 9
            var elementsGreatherThan = Vector128.GreaterThan(data, _9Vector);
            var toAdd = Vector128.BitwiseAnd(elementsGreatherThan, _9AOffsetVector);
            return Vector128.Subtract(data, toAdd);
        }

        Int32 J = 0;
        for (Int32 I = 0; I < UUID_STRING_LENGTH;) {
            if (I is 8 or 13 or 18 or 23) {
                I++;
                continue;
            }
            upper = Vector128.WithElement(upper, J, (Byte)chars[I++]);
            lower = Vector128.WithElement(lower, J, (Byte)chars[I++]);
            J++;
        }

        upper = LowerNine(upper);
        upper = Vector128.Subtract(upper, _AddOverlay);

        lower = LowerNine(lower);
        lower = Vector128.Subtract(lower, _AddOverlay);

        upper = Vector128.ShiftLeft(upper, 4);

        return Vector128.BitwiseOr(upper, lower);
    }

    /// <summary>To read utf8</summary>
    internal static Vector128<Byte> Parse(ReadOnlySpan<Byte> chars) {
        if (chars.Length < UUID_STRING_LENGTH) {
            throw new ArgumentException($"The length of the string is not {chars.Length}", nameof(chars));
        }

        //Upper 4 bits goes first in the string and lower 4 bits goes second in the string
        //We create two vectors, one for the upper 4 bits and one for the lower 4 bits
        //
        //No need to init, all values will be overwritten
        Unsafe.SkipInit(out Vector128<Byte> upper);
        Unsafe.SkipInit(out Vector128<Byte> lower);

        static Vector128<Byte> LowerNine(Vector128<Byte> data) {
            //Each element becomes 0xff if it is greater than 9
            var elementsGreatherThan = Vector128.GreaterThan(data, _9Vector);
            var toAdd = Vector128.BitwiseAnd(elementsGreatherThan, _9AOffsetVector);
            return Vector128.Subtract(data, toAdd);
        }

        Int32 J = 0;
        for (Int32 I = 0; I < UUID_STRING_LENGTH;) {
            if (I is 8 or 13 or 18 or 23) {
                I++;
                continue;
            }
            upper = Vector128.WithElement(upper, J, chars[I++]);
            lower = Vector128.WithElement(lower, J, chars[I++]);
            J++;
        }

        upper = LowerNine(upper);
        upper = Vector128.Subtract(upper, _AddOverlay);

        lower = LowerNine(lower);
        lower = Vector128.Subtract(lower, _AddOverlay);

        upper = Vector128.ShiftLeft(upper, 4);

        return Vector128.BitwiseOr(upper, lower);
    }
}