using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <inheritdoc cref="ToString(Vector128{Byte})"/>
    public static String ToString(ReadOnlySpan<Byte> uuid) {
        return ToString(Vector128.Create(uuid));
    }

    /// <summary>Converts the given byte data and outputs a UUID formatted string</summary>
    /// <param name="uuid">The uuid as a byte collection to output as UUID</param>
    /// <returns>A <see cref="String"/> formatted as UUID</returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static String ToString(Vector128<Byte> uuid) {
        var _Lower4BitsMask = Vector128.Create((Byte)0b0000_1111);
        var _AddOverlay = Vector128.Create((Byte)'0');

        //Upper 4 bits goes second in the string and lower 4 bits goes first in the string
        var upper = Vector128.ShiftRightLogical(uuid, 4);
        var lower = Vector128.BitwiseAnd(uuid, _Lower4BitsMask);

        upper = Vector128.Add(upper, _AddOverlay);
        lower = Vector128.Add(lower, _AddOverlay);

        // UUID format: 00000000-0000-0000-0000-000000000000
        Span<Char> characters = stackalloc Char[UUID_STRING_LENGTH];

        static Char FromByte(Byte data) {
            if (data > '9') {
                return (Char)(data + ('a' - '9' - 1));
            }
            return (Char)(data);
        }

        Int32 J = 0;
        for (Int32 I = 0; I < characters.Length;) {
            if (I is 8 or 13 or 18 or 23) {
                characters[I] = '-';
                I++;
                continue;
            }

            characters[I] = FromByte(upper[J]);
            characters[I + 1] = FromByte(lower[J]);
            I += 2;
            J++;
        }

        return new String(characters);
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

        static Byte FromChar(Char data) {
            if (data > '9') {
                return (Byte)(data - ('a' - '9' - 1));
            }
            return (Byte)(data);
        }

        Int32 J = 0;
        for (Int32 I = 0; I < UUID_STRING_LENGTH;) {
            if (I is 8 or 13 or 18 or 23) {
                I++;
                continue;
            }
            upper = Vector128.WithElement(upper, J, FromChar(chars[I]));
            lower = Vector128.WithElement(lower, J, FromChar(chars[I + 1]));
            J++;
            I += 2;
        }

        var _AddOverlay = Vector128.Create((Byte)'0');
        upper = Vector128.Subtract(upper, _AddOverlay);
        lower = Vector128.Subtract(lower, _AddOverlay);

        upper = Vector128.ShiftLeft(upper, 4);

        return Vector128.BitwiseOr(upper, lower);
    }
}