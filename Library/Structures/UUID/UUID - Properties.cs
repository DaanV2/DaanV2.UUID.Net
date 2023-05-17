namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <summary>Gets the version of this UUID</summary>
    public Version Version => Format.GetVersion(this._Data);

    /// <summary>Gets the variant of this UUID</summary>
    public Variant Variant => Format.GetVariant(this._Data);
}