``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                           : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating batches v4 as strings : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating batches v4 as strings  InvocationCount=5000  IterationCount=5  
RunStrategy=Throughput  UnrollFactor=1  

```
|                                Method | Amount |       Mean |      Error |     StdDev | Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
|-------------------------------------- |------- |-----------:|-----------:|-----------:|------:|--------:|--------:|-------:|----------:|------------:|
| **&#39;Generating UUID v4, standard method&#39;** |     **10** |   **2.708 μs** |  **0.6811 μs** |  **0.1054 μs** |  **1.23** |    **0.11** |  **0.2000** |      **-** |   **1.04 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |     10 |   2.185 μs |  0.5037 μs |  0.1308 μs |  1.00 |    0.00 |  0.2000 |      - |   1.04 KB |        1.00 |
|                                       |        |            |            |            |       |         |         |        |           |             |
| **&#39;Generating UUID v4, standard method&#39;** |    **100** |  **21.510 μs** |  **1.8605 μs** |  **0.4832 μs** |  **1.07** |    **0.05** |  **2.4000** |      **-** |  **10.18 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |    100 |  20.210 μs |  3.4304 μs |  0.8909 μs |  1.00 |    0.00 |  2.4000 |      - |  10.18 KB |        1.00 |
|                                       |        |            |            |            |       |         |         |        |           |             |
| **&#39;Generating UUID v4, standard method&#39;** |    **500** | **107.099 μs** |  **2.9948 μs** |  **0.7777 μs** |  **1.08** |    **0.01** | **12.4000** |      **-** |   **50.8 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |    500 |  99.247 μs |  1.8678 μs |  0.4851 μs |  1.00 |    0.00 | 12.4000 |      - |   50.8 KB |        1.00 |
|                                       |        |            |            |            |       |         |         |        |           |             |
| **&#39;Generating UUID v4, standard method&#39;** |   **1000** | **212.879 μs** |  **6.0271 μs** |  **1.5652 μs** |  **1.02** |    **0.06** | **24.8000** | **0.8000** | **101.59 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |   1000 | 209.441 μs | 54.4910 μs | 14.1511 μs |  1.00 |    0.00 | 24.8000 | 0.8000 | 101.59 KB |        1.00 |
