``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                           : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating batches v4 as strings : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating batches v4 as strings  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
|    Method | Amount |       Mean |     Error |     StdDev |     Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------- |------- |-----------:|----------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **&#39;UUID v4&#39;** |     **10** |   **3.187 μs** | **0.0690 μs** |  **0.1189 μs** |   **3.200 μs** |  **0.77** |    **0.04** |   **1.53 KB** |        **1.00** |
|      Guid |     10 |   4.159 μs | 0.0876 μs |  0.1365 μs |   4.100 μs |  1.00 |    0.00 |   1.53 KB |        1.00 |
|           |        |            |           |            |            |       |         |           |             |
| **&#39;UUID v4&#39;** |    **100** |  **14.249 μs** | **0.4660 μs** |  **1.2912 μs** |  **14.000 μs** |  **0.60** |    **0.06** |  **10.67 KB** |        **1.00** |
|      Guid |    100 |  23.815 μs | 0.5954 μs |  1.6199 μs |  23.000 μs |  1.00 |    0.00 |  10.67 KB |        1.00 |
|           |        |            |           |            |            |       |         |           |             |
| **&#39;UUID v4&#39;** |    **500** |  **60.815 μs** | **1.2095 μs** |  **2.4978 μs** |  **60.400 μs** |  **0.59** |    **0.03** |   **51.3 KB** |        **1.00** |
|      Guid |    500 | 103.192 μs | 1.8086 μs |  1.5102 μs | 103.400 μs |  1.00 |    0.00 |   51.3 KB |        1.00 |
|           |        |            |           |            |            |       |         |           |             |
| **&#39;UUID v4&#39;** |   **1000** | **120.942 μs** | **2.3130 μs** |  **5.1255 μs** | **121.200 μs** |  **0.56** |    **0.04** | **101.75 KB** |        **1.00** |
|      Guid |   1000 | 213.789 μs | 4.2785 μs | 11.1203 μs | 209.700 μs |  1.00 |    0.00 | 102.08 KB |        1.00 |
