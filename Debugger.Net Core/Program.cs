using System;
using System.Diagnostics;
using DaanV2.UUID;
using DaanV2.UUID.Generators;

namespace Debugger.Net_Core {
    internal class Program {
        private static void Main(String[] args) {

            DaanV2.UUID.Generators.Version4.GeneratorVariant1 G = new DaanV2.UUID.Generators.Version4.GeneratorVariant1();
            Random R = new Random();

            Int32 TestAmount = 100;
            Int32 Batch = 1000000;
            Int32 TestIndex, I;

            Stopwatch sw = new Stopwatch();

            UUID uuid = G.Generate();

            sw.Start();

            Converter.Load();

            Byte[] Bytes = Converter.ToBytes(uuid.Chars);
            Char[] Chars = Converter.ToCharArray(Bytes);

            UUID Te = new UUID(Chars);
            
            if (uuid == Te) {
                Console.WriteLine("Good");
            }
            else {
                Console.WriteLine("NOPE");
            }

            sw.Stop();

            Benchmark.Output(sw, TestAmount, Batch);

            Console.ReadLine();
        }
    }
}
