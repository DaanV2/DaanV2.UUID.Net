``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                           : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating batches v4 as strings : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating batches v4 as strings  InvocationCount=5000  IterationCount=5  
RunStrategy=Throughput  UnrollFactor=1  

```
|                                Method | Amount |       Mean |     Error |    StdDev | Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
|-------------------------------------- |------- |-----------:|----------:|----------:|------:|--------:|--------:|-------:|----------:|------------:|
| **&#39;Generating UUID v4, standard method&#39;** |     **10** |   **1.204 μs** | **0.0366 μs** | **0.0057 μs** |  **0.52** |    **0.04** |  **0.2000** |      **-** |   **1.04 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |     10 |   2.313 μs | 0.7211 μs | 0.1873 μs |  1.00 |    0.00 |  0.2000 |      - |   1.04 KB |        1.00 |
|                                       |        |            |           |           |       |         |         |        |           |             |
| **&#39;Generating UUID v4, standard method&#39;** |    **100** |   **8.264 μs** | **0.3136 μs** | **0.0485 μs** |  **0.42** |    **0.00** |  **2.4000** |      **-** |  **10.18 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |    100 |  19.856 μs | 0.8884 μs | 0.1375 μs |  1.00 |    0.00 |  2.4000 |      - |  10.18 KB |        1.00 |
|                                       |        |            |           |           |       |         |         |        |           |             |
| **&#39;Generating UUID v4, standard method&#39;** |    **500** |  **42.534 μs** | **2.8200 μs** | **0.7324 μs** |  **0.42** |    **0.01** | **12.4000** |      **-** |  **50.81 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |    500 | 100.263 μs | 1.8994 μs | 0.4933 μs |  1.00 |    0.00 | 12.4000 |      - |   50.8 KB |        1.00 |
|                                       |        |            |           |           |       |         |         |        |           |             |
| **&#39;Generating UUID v4, standard method&#39;** |   **1000** |  **83.320 μs** | **0.3883 μs** | **0.0601 μs** |  **0.42** |    **0.00** | **24.8000** | **0.8000** | **101.59 KB** |        **1.00** |
|    &#39;Generating Guid, standard method&#39; |   1000 | 199.629 μs | 0.7830 μs | 0.2033 μs |  1.00 |    0.00 | 24.8000 | 0.8000 | 101.59 KB |        1.00 |
