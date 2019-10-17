﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DaanV2.UUID.Generators.Version4 {
    ///DOLATER <summary> add description for class: GeneratorVariant1</summary>
	[Serializable, DataContract]
    public partial class GeneratorVariant1 {

        /// <summary>Creates a new instance of <see cref="GeneratorVariant1"/></summary>
        public GeneratorVariant1() : base() {
            
        }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="Seed"></param>
        public GeneratorVariant1(Int32 Seed) : base(Seed) { }

        /// <summary>Creates a new instance of <see cref="GeneratorBase"/></summary>
        /// <param name="NumberGenerator"></param>
        public GeneratorVariant1(Random NumberGenerator) : base(NumberGenerator) { }
    }
}
