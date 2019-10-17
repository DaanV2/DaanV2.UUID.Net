using System;

namespace DaanV2.UUID.Generators {
    public abstract partial class GeneratorBase : IUUIDGenerator {

        /// <summary>
        /// 
        /// </summary>
        public abstract Int32 Version { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract Int32 Variant { get; }

        /// <summary>
        /// 
        /// </summary>
        public Random NumberGenerator { get => this._NumberGenerator; set => this._NumberGenerator = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract UUID Generate();
    }
}
