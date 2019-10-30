/*ISC License

Copyright (c) 2019, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;
using System.Diagnostics;
using DaanV2.UUID;

namespace Debugger.Net_Core {
    public class Benchmark {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Version"></param>
        /// <param name="Variant"></param>
        /// <param name="TestCount"></param>
        /// <param name="Count"></param>
        public static void Test(Int32 Version, Int32 Variant, Int32 TestCount = 100, Int32 Count = 1000000) {
            Stopwatch stopwatch = new Stopwatch();

            for (Int32 I = 0; I < TestCount; I++) {
                stopwatch.Start();

                UUID[] Temp = UUIDFactory.CreateUUIDs(Count, Version, Variant);

                stopwatch.Stop();

                Temp = null;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, true);
                Console.Title = $"V{Version}.{Variant}\t-\t{I}/{TestCount}";
            }

            Output(stopwatch, Version, Variant, TestCount, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void TestAll() {
            Int32[] Versions = UUIDFactory.GetAvailableVersion();

            for (Int32 VersionIndex = 0; VersionIndex < Versions.Length; VersionIndex++) {
                Int32[] Variants = UUIDFactory.GetAvailableVariants(Versions[VersionIndex]);

                for (Int32 VariantIndex = 0; VariantIndex < Variants.Length; VariantIndex++) {
                    Test(Versions[VersionIndex], Variants[VariantIndex]);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="TestCount"></param>
        /// <param name="ItemCount"></param>
        public static void Output(Stopwatch sw, Int32 Version, Int32 Variant, Int32 TestCount, Int32 ItemCount = -1) {
            Double MSPerTest = (double)sw.ElapsedMilliseconds / (double)TestCount;
            Double TicksPerTest = (double)sw.ElapsedTicks / (double)TestCount;
            Double MSPerTestPerItem = MSPerTest / ItemCount;
            Double TicksPerTestPerItem = TicksPerTest / ItemCount;

            Console.WriteLine($"|{Version:G2} |{Variant:G2} |{MSPerTest:G2} |{TicksPerTest:G2} |{MSPerTestPerItem:G2} |{TicksPerTestPerItem:G2} |");
        }
    }
}
