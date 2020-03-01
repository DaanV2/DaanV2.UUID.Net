using System;
using System.IO;

namespace Debugger.Net_Core {
    public partial class Logger {
        /// <summary>Creates a new instance of <see cref="Logger"/></summary>
        public Logger(String Filepath) {
            this._Writer = new StreamWriter(Filepath, false);
            this._Writer.WriteLine("Version|Variant|Milliseconds|Ticks|ItemCount");
        }

        /// <summary></summary>
        ~Logger() {
            this._Writer.Flush();
            this._Writer.Close();
        }
    }
}
