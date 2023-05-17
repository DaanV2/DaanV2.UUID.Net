using System.Runtime.Intrinsics;

namespace DaanV2.UUID {
    public partial class Generator : IEquatable<Generator?> {
        /// <inheritdoc/>
        public override Boolean Equals(Object? obj) {
            return this.Equals(obj as Generator);
        }

        /// <inheritdoc/>
        public Boolean Equals(Generator? other) {
            return other is not null &&
                   this._Mask.Equals(other._Mask) &&
                   this._Overlay.Equals(other._Overlay);
        }

        /// <inheritdoc/>
        public override Int32 GetHashCode() {
            return HashCode.Combine(this._Mask, this._Overlay);
        }

        /// <inheritdoc/>
        public static Boolean operator ==(Generator? left, Generator? right) {
            return EqualityComparer<Generator>.Default.Equals(left, right);
        }

        /// <inheritdoc/>
        public static Boolean operator !=(Generator? left, Generator? right) {
            return !(left == right);
        }
    }
}
