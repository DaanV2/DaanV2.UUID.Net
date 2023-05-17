namespace DaanV2.UUID;

public readonly partial struct UUID {
    /// <inheritdoc/>
    public static Boolean operator ==(UUID left, UUID right) {
        return left.Equals(right);
    }

    /// <inheritdoc/>
    public static Boolean operator !=(UUID left, UUID right) {
        return !(left == right);
    }
}