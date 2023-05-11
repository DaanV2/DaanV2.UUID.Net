

namespace DaanV2.UUID.Generators {
    /// <summary>The class that holds the information of a generator</summary>
    public partial class GeneratorInfo {
        /// <summary>Creates a new instance of <see cref="GeneratorInfo"/></summary>
        public GeneratorInfo() {
            this.ContextType = null;
            this.NeedContext = false;
            this.Variant = 1;
            this.Version = 1;
        }

        /// <summary>Creates a new instance of <see cref="GeneratorInfo"/></summary>
        /// <param name="generator">The generator to copy the info from</param>
        public GeneratorInfo(IUUIDGenerator generator) {
            this.ContextType = generator.ContextType;
            this.NeedContext = generator.NeedContext;
            this.Variant = generator.Variant;
            this.Version = generator.Version;
            this.GeneratorType = generator.GetType();
        }
    }
}
