``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Retrieving from Array : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Retrieving from Array  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  WarmupCount=10  

```
|        Method | Amount |          Mean |         Error |        StdDev |        Median | Ratio | RatioSD |
|-------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|
|          **Guid** |     **10** |      **1.297 μs** |     **0.1530 μs** |     **0.4462 μs** |      **1.200 μs** |  **0.58** |    **0.32** |
|          UUID |     10 |            NA |            NA |            NA |            NA |     ? |       ? |
| &#39;String UUID&#39; |     10 |      2.705 μs |     0.4056 μs |     1.1832 μs |      2.300 μs |  1.00 |    0.00 |
|               |        |               |               |               |               |       |         |
|          **Guid** |    **100** |     **12.384 μs** |     **0.1921 μs** |     **0.3262 μs** |     **12.300 μs** |  **0.40** |    **0.08** |
|          UUID |    100 |            NA |            NA |            NA |            NA |     ? |       ? |
| &#39;String UUID&#39; |    100 |     30.387 μs |     2.3603 μs |     6.5403 μs |     27.400 μs |  1.00 |    0.00 |
|               |        |               |               |               |               |       |         |
|          **Guid** |   **1000** |  **1,034.017 μs** |    **20.2735 μs** |    **33.8725 μs** |  **1,016.250 μs** |  **0.37** |    **0.07** |
|          UUID |   1000 |            NA |            NA |            NA |            NA |     ? |       ? |
| &#39;String UUID&#39; |   1000 |  2,939.945 μs |   256.9036 μs |   749.3999 μs |  2,639.400 μs |  1.00 |    0.00 |
|               |        |               |               |               |               |       |         |
|          **Guid** |   **2000** |  **4,102.950 μs** |    **81.6541 μs** |    **80.1953 μs** |  **4,109.950 μs** |  **0.41** |    **0.05** |
|          UUID |   2000 |            NA |            NA |            NA |            NA |     ? |       ? |
| &#39;String UUID&#39; |   2000 |  9,420.599 μs |   609.9678 μs | 1,779.3046 μs |  8,614.450 μs |  1.00 |    0.00 |
|               |        |               |               |               |               |       |         |
|          **Guid** |   **5000** | **19,008.016 μs** |   **378.9075 μs** |   **653.5968 μs** | **18,849.100 μs** |  **0.38** |    **0.02** |
|          UUID |   5000 |            NA |            NA |            NA |            NA |     ? |       ? |
| &#39;String UUID&#39; |   5000 | 50,424.581 μs | 1,000.5270 μs | 1,527.9104 μs | 49,757.700 μs |  1.00 |    0.00 |

Benchmarks with issues:
  RetrieveTest.UUID: Retrieving from Array(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1, WarmupCount=10) [Amount=10]
  RetrieveTest.UUID: Retrieving from Array(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1, WarmupCount=10) [Amount=100]
  RetrieveTest.UUID: Retrieving from Array(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1, WarmupCount=10) [Amount=1000]
  RetrieveTest.UUID: Retrieving from Array(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1, WarmupCount=10) [Amount=2000]
  RetrieveTest.UUID: Retrieving from Array(InvocationCount=1, RunStrategy=Throughput, UnrollFactor=1, WarmupCount=10) [Amount=5000]
