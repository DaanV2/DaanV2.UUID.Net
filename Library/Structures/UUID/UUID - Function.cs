using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>Returns a copy contents of the UUID as a <see cref="Byte[]"/></summary>
    /// <returns>A copy of the contents as a <see cref="Byte[]"/></returns>
    public Byte[] AsByte() {
        Byte[] data = new Byte[Vector128<Byte>.Count];
        this._Data.CopyTo(data);
        return data;
    }

    /// <summary>Returns a copy contents of the UUID as a <see cref="Span{Byte}"/></summary>
    /// <returns>A copy of the contents as a <see cref="Span{Byte}"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<Byte> AsSpan() {
        Byte[] data = this.AsByte();
        return new Span<Byte>(data);
    }

    /// <summary>Returns a copy contents of the UUID as a <see cref="Vector128{Byte}"/></summary>
    /// <returns>A copy of the contents as a <see cref="Vector128{Byte}"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector128<Byte> AsVector() {
        return this._Data;
    }
}
