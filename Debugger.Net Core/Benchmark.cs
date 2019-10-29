using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DaanV2.UUID;

namespace Debugger.Net_Core {
    public class Benchmark {
        /// <summary>
        /// 
        /// </summary>
        public void Test() {
            IUUIDGenerator Generator = new DaanV2.UUID.Generators.Version4.GeneratorVariant2();

            Int32 Count = 1000000;
            Int32 TestCount = 100;

            Stopwatch stopwatch = new Stopwatch();

            for (Int32 I = 0; I < TestCount; I++) {
                stopwatch.Start();

                UUID[] Temp = UUIDFactory.CreateUUIDs(Count, 4, 2);

                stopwatch.Stop();

                Temp = null;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, true);
                Console.WriteLine(I);
            }
            Output(stopwatch, TestCount, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="TestCount"></param>
        /// <param name="ItemCount"></param>
        public static void Output(Stopwatch sw, Int32 TestCount, Int32 ItemCount = -1) {
            Console.WriteLine("x---\tTotals\t---x");
            Console.WriteLine($"Elapsed ticks:\t\t{(Double)sw.ElapsedTicks / (Double)TestCount}");
            Console.WriteLine($"Elapsed milli seconds:\t{(Double)sw.ElapsedMilliseconds / (Double)TestCount}");

            if (ItemCount < 0) {
                return;
            }

            Console.WriteLine("x---\tPer Item\t---x");
            Console.WriteLine($"Elapsed ticks:\t\t{(Double)sw.ElapsedTicks / (Double)(ItemCount * TestCount)}");
            Console.WriteLine($"Elapsed milli seconds:\t{(Double)sw.ElapsedMilliseconds / (Double)(ItemCount * TestCount)}");
        }
    }
}
