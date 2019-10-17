using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanV2.UUID.Generators {
    public abstract partial class GeneratorBase {
        /// <summary>
        /// 
        /// </summary>
        protected Random _NumberGenerator;

        /// <summary>
        /// 
        /// </summary>
        protected Char[,] _ToHexChars;
    }
}
