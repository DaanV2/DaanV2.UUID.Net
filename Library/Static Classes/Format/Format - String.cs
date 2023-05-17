using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    public const Int32 UUID_STRING_LENGTH = 36;

    public static String ToString(ReadOnlySpan<Byte> uuid) {
        return ToString(Vector128.Create(uuid));
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static String ToString(Vector128<Byte> uuid) {
        var _Lower4BitsMask = Vector128.Create((Byte)0b0000_1111);
        var _AddOverlay = Vector128.Create((Byte)'0');

        //Upper 4 bits goes first in the string and lower 4 bits goes second in the string
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


    public static Vector128<Byte> Parse(String chars) {
        return Parse(chars.AsSpan());
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static Vector128<Byte> Parse(ReadOnlySpan<Char> chars) {
        if (chars.Length < UUID_STRING_LENGTH) {
            throw new ArgumentException("The length of the string is not 36", nameof(chars));
        }

        //Upper 4 bits goes first in the string and lower 4 bits goes second in the string
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
            upper = Vector128.WithElement(upper, J,  FromChar(chars[I]));
            lower = Vector128.WithElement(lower, J,  FromChar(chars[I + 1]));
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