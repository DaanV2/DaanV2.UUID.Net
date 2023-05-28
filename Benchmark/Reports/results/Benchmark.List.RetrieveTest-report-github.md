``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]               : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Retrieving from List : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Retrieving from List  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
| Method | Amount |          Mean |         Error |        StdDev |        Median | Ratio | RatioSD |
|------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|
|   **GUID** |     **10** |      **1.631 μs** |     **0.2040 μs** |     **0.5984 μs** |      **1.700 μs** |  **0.63** |    **0.30** |
|   UUID |     10 |            NA |            NA |            NA |            NA |     ? |       ? |
|   UUID |     10 |      2.890 μs |     0.3475 μs |     1.0026 μs |      3.050 μs |  1.00 |    0.00 |
|        |        |               |               |               |               |       |         |
|   **GUID** |    **100** |     **13.474 μs** |     **0.5311 μs** |     **1.4540 μs** |     **13.100 μs** |  **0.37** |    **0.12** |
|   UUID |    100 |            NA |            NA |            NA |            NA |     ? |       ? |
|   UUID |    100 |     40.565 μs |     5.3946 μs |    15.3037 μs |     29.700 μs |  1.00 |    0.00 |
|        |        |               |               |               |               |       |         |
|   **GUID** |   **1000** |  **1,015.527 μs** |    **72.6576 μs** |   **203.7396 μs** |  **1,024.800 μs** |  **0.48** |    **0.07** |
|   UUID |   1000 |            NA |            NA |            NA |            NA |     ? |       ? |
|   UUID |   1000 |  2,302.912 μs |    45.6324 μs |    83.4414 μs |  2,281.200 μs |  1.00 |    0.00 |
|        |        |               |               |               |               |       |         |
|   **GUID** |   **2000** |  **3,540.290 μs** |   **208.5428 μs** |   **611.6198 μs** |  **3,230.300 μs** |  **0.38** |    **0.07** |
|   UUID |   2000 |            NA |            NA |            NA |            NA |     ? |       ? |
|   UUID |   2000 |  9,605.866 μs |   677.3937 μs | 1,965.2420 μs |  8,551.250 μs |  1.00 |    0.00 |
|        |        |               |               |               |               |       |         |
|   **GUID** |   **5000** | **23,570.103 μs** | **1,141.6111 μs** | **3,312.0207 μs** | **22,911.900 μs** |  **0.42** |    **0.06** |
|   UUID |   5000 |            NA |            NA |            NA |            NA |     ? |       ? |
|   UUID |   5000 | 56,351.762 μs | 1,468.3983 μs | 4,260.0898 μs | 55,993.600 μs |  1.00 |    0.00 |

Benchmarks with issues:
  RetrieveTest.UUID: Retrieving from List(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1) [Amount=10]
  RetrieveTest.UUID: Retrieving from List(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1) [Amount=100]
  RetrieveTest.UUID: Retrieving from List(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1) [Amount=1000]
  RetrieveTest.UUID: Retrieving from List(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1) [Amount=2000]
  RetrieveTest.UUID: Retrieving from List(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1) [Amount=5000]
