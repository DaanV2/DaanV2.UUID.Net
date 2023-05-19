``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating batches v4 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating batches v4  IterationCount=5  RunStrategy=Throughput  

```
| Method                                                                   | Amount      |                Mean |             Error |            StdDev |    Ratio |
| ------------------------------------------------------------------------ | ----------- | ------------------: | ----------------: | ----------------: | -------: |
| **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** | **10**      |        **162.0 ns** |      **14.09 ns** |       **3.66 ns** | **0.22** |
| &#39;Generating a batch of UUID V4, Using a local randomizer&#39;        | 10          |            242.9 ns |          23.21 ns |           6.03 ns |     0.33 |
| &#39;Generating a batch of UUID V4&#39;                                  | 10          |            732.3 ns |          76.86 ns |          19.96 ns |     1.00 |
|                                                                          |             |                     |                   |                   |          |
| **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** | **100**     |      **1,351.2 ns** |     **105.22 ns** |      **16.28 ns** | **0.19** |
| &#39;Generating a batch of UUID V4, Using a local randomizer&#39;        | 100         |          1,153.3 ns |          37.75 ns |           9.80 ns |     0.16 |
| &#39;Generating a batch of UUID V4&#39;                                  | 100         |          7,149.0 ns |         495.34 ns |         128.64 ns |     1.00 |
|                                                                          |             |                     |                   |                   |          |
| **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** | **500**     |      **7,142.9 ns** |     **330.71 ns** |      **51.18 ns** | **0.20** |
| &#39;Generating a batch of UUID V4, Using a local randomizer&#39;        | 500         |          5,231.2 ns |         395.42 ns |         102.69 ns |     0.15 |
| &#39;Generating a batch of UUID V4&#39;                                  | 500         |         35,989.0 ns |       1,636.86 ns |         253.31 ns |     1.00 |
|                                                                          |             |                     |                   |                   |          |
| **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** | **1000**    |     **14,960.5 ns** |   **3,758.20 ns** |     **975.99 ns** | **0.21** |
| &#39;Generating a batch of UUID V4, Using a local randomizer&#39;        | 1000        |         10,643.5 ns |       1,752.52 ns |         271.20 ns |     0.15 |
| &#39;Generating a batch of UUID V4&#39;                                  | 1000        |         70,339.6 ns |       1,340.01 ns |         348.00 ns |     1.00 |
|                                                                          |             |                     |                   |                   |          |
| **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** | **10000**   |    **197,927.8 ns** |   **3,733.97 ns** |     **969.70 ns** | **0.26** |
| &#39;Generating a batch of UUID V4, Using a local randomizer&#39;        | 10000       |        155,353.4 ns |       1,489.79 ns |         386.89 ns |     0.20 |
| &#39;Generating a batch of UUID V4&#39;                                  | 10000       |        758,209.7 ns |      14,116.06 ns |       3,665.90 ns |     1.00 |
|                                                                          |             |                     |                   |                   |          |
| **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** | **1000000** | **14,821,013.7 ns** | **669,641.38 ns** | **103,627.75 ns** | **0.20** |
| &#39;Generating a batch of UUID V4, Using a local randomizer&#39;        | 1000000     |     11,434,924.7 ns |     571,384.09 ns |     148,386.63 ns |     0.16 |
| &#39;Generating a batch of UUID V4&#39;                                  | 1000000     |     73,277,164.3 ns |   1,366,691.03 ns |     211,496.95 ns |     1.00 |
