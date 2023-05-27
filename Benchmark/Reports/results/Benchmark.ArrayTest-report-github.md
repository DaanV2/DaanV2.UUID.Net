``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host] : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Array  : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Array  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  WarmupCount=10  

```
|                                  Method | Amount |          Mean |         Error |        StdDev |        Median | Ratio | RatioSD |
|---------------------------------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|
|        **&#39;Retrieving Guid from the array&#39;** |     **10** |      **1.666 μs** |     **0.2250 μs** |     **0.6491 μs** |      **1.700 μs** |  **0.61** |    **0.34** |
|        &#39;Retrieving UUID from the array&#39; |     10 |      4.241 μs |     0.4142 μs |     1.1614 μs |      3.900 μs |  1.53 |    0.68 |
| &#39;Retrieving String UUID from the array&#39; |     10 |      3.068 μs |     0.3360 μs |     0.9587 μs |      3.000 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |    **100** |     **12.464 μs** |     **0.2565 μs** |     **0.2274 μs** |     **12.450 μs** |  **0.41** |    **0.08** |
|        &#39;Retrieving UUID from the array&#39; |    100 |     61.139 μs |     6.1330 μs |    17.2983 μs |     50.800 μs |  1.93 |    0.68 |
| &#39;Retrieving String UUID from the array&#39; |    100 |     33.754 μs |     3.4334 μs |     9.6276 μs |     28.100 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **1000** |  **1,091.453 μs** |    **79.1456 μs** |   **227.0836 μs** |  **1,033.900 μs** |  **0.45** |    **0.10** |
|        &#39;Retrieving UUID from the array&#39; |   1000 |  2,279.456 μs |   802.1044 μs | 2,365.0228 μs |    554.900 μs |  0.95 |    0.92 |
| &#39;Retrieving String UUID from the array&#39; |   1000 |  2,504.540 μs |   130.4204 μs |   365.7127 μs |  2,471.900 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **2000** |  **3,795.468 μs** |   **217.4190 μs** |   **627.3034 μs** |  **3,776.550 μs** |  **0.45** |    **0.08** |
|        &#39;Retrieving UUID from the array&#39; |   2000 |  1,448.761 μs |    34.9584 μs |    99.7382 μs |  1,436.650 μs |  0.17 |    0.02 |
| &#39;Retrieving String UUID from the array&#39; |   2000 |  8,448.911 μs |   232.2243 μs |   647.3485 μs |  8,197.000 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **5000** | **19,250.638 μs** |   **383.6290 μs** |   **671.8953 μs** | **19,296.700 μs** |  **0.37** |    **0.02** |
|        &#39;Retrieving UUID from the array&#39; |   5000 |  9,199.618 μs |   233.1234 μs |   657.5286 μs |  9,023.350 μs |  0.17 |    0.02 |
| &#39;Retrieving String UUID from the array&#39; |   5000 | 52,569.738 μs | 1,047.7621 μs | 2,723.2730 μs | 51,124.600 μs |  1.00 |    0.00 |
