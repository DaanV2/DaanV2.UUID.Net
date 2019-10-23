using System;
using System.Diagnostics;
using DaanV2.UUID;

namespace Debugger.Net_Core {
    internal class Program {
        private static void Main(String[] args) {
            IUUIDGenerator Generator = new DaanV2.UUID.Generators.Version4.GeneratorVariant2();

            Int32 Count = 1000000;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();



            stopwatch.Stop();
            Output(stopwatch, Count);

            Console.WriteLine(Generator.Generate().ToString());
            Console.ReadLine();
        }

        public static void Output(Stopwatch sw, Int32 ItemCount = -1) {
            Console.WriteLine("x---\tTotals\t---x");
            Console.WriteLine($"Elapsed ticks:\t\t{sw.ElapsedTicks}");
            Console.WriteLine($"Elapsed milli seconds:\t{sw.ElapsedMilliseconds}");

            if (ItemCount < 0) {
                return;
            }

            Console.WriteLine("x---\tPer Item\t---x");
            Console.WriteLine($"Elapsed ticks:\t\t{(Double)sw.ElapsedTicks / (Double)ItemCount}");
            Console.WriteLine($"Elapsed milli seconds:\t{(Double)sw.ElapsedMilliseconds / (Double)ItemCount}");
        }
    }
}
