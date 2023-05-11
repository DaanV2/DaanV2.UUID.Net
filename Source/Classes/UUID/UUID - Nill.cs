
using System;

namespace DaanV2.UUID {
    public partial class UUID {
        /// <summary>Returns a 'nill' or empty UUID</summary>
        public static readonly UUID Nill = new UUID(new Char[] {
            '0', '0', '0', '0', '0', '0', '0', '0', '-',
            '0', '0', '0', '0', '-',
            '0', '0', '0', '0', '-',
            '0', '0', '0', '0', '-',
            '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' });
    }
}
