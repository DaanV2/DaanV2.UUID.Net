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
    /// <summary>A class that bench marks all the generators</summary>
    public partial class Benchmark {
        /// <summary>Tests the version inside the <see cref="UUIDFactory"/> on amount</summary>
        /// <param name="Version">The version of the generator to test</param>
        /// <param name="Variant">The variant of the generator to test</param>
        /// <param name="TestCount">The amount of tests conducted</param>
        /// <param name="Count">The amount of items per test to generate</param>
        public static void Test(Int32 Version, Int32 Variant, Logger dataRecorder, Int32 TestCount = 100, Int32 Count = 1000000) {
            Stopwatch stopwatch = new Stopwatch();
            Int64 PreviousMS = 0;
            Int64 PreviousTicks = 0;


            for (Int32 I = 0; I < TestCount; I++) {
                stopwatch.Start();
                //Create Alot of UUIDs
                UUID[] Temp = UUIDFactory.CreateUUIDs(Count, Version, Variant);

                stopwatch.Stop();

                //Dispose
                Temp = null;
                dataRecorder.Add(Version, Variant, stopwatch.ElapsedMilliseconds - PreviousMS, stopwatch.ElapsedTicks - PreviousTicks, Count);
                PreviousMS = stopwatch.ElapsedMilliseconds;
                PreviousTicks = stopwatch.ElapsedTicks;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, true);
                Console.Title = $"V{Version}.{Variant}\t-\t{I}/{TestCount}";
            }

            dataRecorder.Flush();
            Benchmark.Output(stopwatch, Version, Variant, TestCount, Count);
        }

        /// <summary>Tests all possible generators and variants inside this library</summary>
        public static void TestAll(String Folder) {
            Int32[] Versions = UUIDFactory.GetAvailableVersion();

            String Platform = IntPtr.Size == 4 ? "x86" : "x64";
            Logger dataRecorder = new Logger(Folder + $"Data-{Platform}.csv");

            for (Int32 VersionIndex = 0; VersionIndex < Versions.Length; VersionIndex++) {
                Int32[] Variants = UUIDFactory.GetAvailableVariants(Versions[VersionIndex]);

                for (Int32 VariantIndex = 0; VariantIndex < Variants.Length; VariantIndex++) {
                    Test(Versions[VersionIndex], Variants[VariantIndex], dataRecorder);
                }
            }

            dataRecorder.Done();
        }

        /// <summary>Outputs the test result of a test onto the console</summary>
        /// <param name="sw">The stopwatch that has recorded the timing</param>
        /// <param name="TestCount">The amount of tests conducted</param>
        /// <param name="ItemCount">The amount of items used per tests</param>
        public static void Output(Stopwatch sw, Int32 Version, Int32 Variant, Int32 TestCount, Int32 ItemCount = -1) {
            Double MSPerTest = sw.ElapsedMilliseconds / (Double)TestCount;
            Double TicksPerTest = sw.ElapsedTicks / (Double)TestCount;
            Double MSPerTestPerItem = MSPerTest / ItemCount;
            Double TicksPerTestPerItem = TicksPerTest / ItemCount;

            Console.WriteLine($"|{Version:G2} |{Variant:G2} |{MSPerTest:G2} |{TicksPerTest:G2} |{MSPerTestPerItem:G2} |{TicksPerTestPerItem:G2} |");
        }
    }
}
