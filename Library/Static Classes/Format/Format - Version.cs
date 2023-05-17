using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public static partial class Format {
    /// <summary>The index of where the version in located in a byte array</summary>
    public const Int32 VERSION_BYTE_INDEX = 6;

    /// <summary>The version mask to read any version</summary>
    private const UInt32 _VERSION_MASK = 0b1111_0000;

    /// <inheritdoc cref="GetVersion(Byte)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Version GetVersion(ReadOnlySpan<Byte> data) {
        return GetVersion(data[VERSION_BYTE_INDEX]);
    }

    /// <inheritdoc cref="GetVersion(Byte)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Version GetVersion<T>(Vector128<T> data)
        where T : struct {
        return GetVersion(Vector128.AsByte(data)[VERSION_BYTE_INDEX]);
    }

    /// <summary>Retrieves the version from the given data</summary>
    /// <param name="data">The data to retrieve the version from</param>
    /// <returns>The <see cref="Version"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Version GetVersion(Byte data) {
        return (Version)(data & 0b1111_0000);
    }

    /// <summary>Returns a mask that allows to set/get this specific <see cref="Version"/></summary>
    /// <param name="version">The version to get the mask for</param>
    /// <returns>A <see cref="UInt32"/> containing the mask</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UInt32 GetMask(this Version version) {
        //Always 4 bits
        return _VERSION_MASK;
    }

    /// <summary>Converts the given <see cref="Int32"/> to a <see cref="Version"/></summary>
    /// <param name="version">The version that represents the variant</param>
    /// <returns>A <see cref="Version"/></returns>
    /// <exception cref="ArgumentException">Throw if the <paramref name="version"/> is out of bounds</exception>
    public static Version ToVersion(Int32 version) {
        //Lets the bits drops off
        Byte b = (Byte)(version << 4);

        return (Version)b;
    }

    /// <summary>Converts the given <see cref="Version"/> to an <see cref="Int32"/></summary>
    /// <param name="version">The <see cref="Version"/> to convert</param>
    /// <returns>A <see cref="Int32"/> that represents the version</returns>
    public static Int32 ToInt32(this Version version) {
        return (Int32)version >> 4;
    }
}