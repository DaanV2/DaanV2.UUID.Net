using System;
using System.Diagnostics;
using DaanV2.UUID;

namespace Debugger.Net_Core {
    public partial class Logger {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Version"></param>
        /// <param name="Variant"></param>
        /// <param name="Millisseconds"></param>
        /// <param name=""></param>
        public void Add(Int32 Version, Int32 Variant, Int64 Millisseconds, Int64 Ticks, Int32 ItemCount) {
            this._Writer.WriteLine($"{Version}|{Variant}|{Millisseconds}|{Ticks}|{ItemCount}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Generator"></param>
        /// <param name="sw"></param>
        /// <param name="ItemCount"></param>
        public void Add(IUUIDGenerator Generator, Stopwatch sw, Int32 ItemCount) {
            this.Add(Generator.Version, Generator.Variant, sw.ElapsedMilliseconds, sw.ElapsedTicks, ItemCount);
        }

        public void Done() {
            this._Writer.Flush();
            this._Writer.Close();
        }

        public void Flush() {
            this._Writer.Flush();
        }
    }
}
