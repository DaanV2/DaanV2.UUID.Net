``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host] : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Array  : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Array  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  WarmupCount=10  

```
|                                  Method | Amount |          Mean |         Error |        StdDev |         Median | Ratio | RatioSD |
|---------------------------------------- |------- |--------------:|--------------:|--------------:|---------------:|------:|--------:|
|        **&#39;Retrieving Guid from the array&#39;** |     **10** |      **1.178 μs** |     **0.1905 μs** |     **0.5436 μs** |      **0.9500 μs** |  **0.65** |    **0.45** |
|        &#39;Retrieving UUID from the array&#39; |     10 |      2.474 μs |     0.2733 μs |     0.7885 μs |      2.1000 μs |  1.29 |    0.57 |
| &#39;Retrieving String UUID from the array&#39; |     10 |      2.189 μs |     0.3172 μs |     0.9202 μs |      1.7000 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |                |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |    **100** |     **15.747 μs** |     **0.9117 μs** |     **2.4803 μs** |     **16.7000 μs** |  **0.50** |    **0.10** |
|        &#39;Retrieving UUID from the array&#39; |    100 |     47.485 μs |     3.7208 μs |    10.3104 μs |     43.0000 μs |  1.81 |    0.41 |
| &#39;Retrieving String UUID from the array&#39; |    100 |     27.307 μs |     0.5439 μs |     0.7973 μs |     27.0000 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |                |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **1000** |    **983.148 μs** |    **67.4943 μs** |   **194.7364 μs** |  **1,004.4000 μs** |  **0.39** |    **0.09** |
|        &#39;Retrieving UUID from the array&#39; |   1000 |    381.306 μs |    38.2527 μs |    99.4238 μs |    335.0000 μs |  0.15 |    0.04 |
| &#39;Retrieving String UUID from the array&#39; |   1000 |  2,554.692 μs |   122.3951 μs |   357.0323 μs |  2,481.2500 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |                |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **2000** |  **3,570.318 μs** |   **206.3272 μs** |   **601.8662 μs** |  **3,471.3000 μs** |  **0.43** |    **0.07** |
|        &#39;Retrieving UUID from the array&#39; |   2000 |  1,393.980 μs |    30.1494 μs |    81.5107 μs |  1,391.8000 μs |  0.17 |    0.02 |
| &#39;Retrieving String UUID from the array&#39; |   2000 |  8,246.294 μs |   304.4356 μs |   868.5719 μs |  7,827.7000 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |                |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **5000** | **18,671.208 μs** |   **355.0898 μs** |   **296.5160 μs** | **18,741.9000 μs** |  **0.36** |    **0.02** |
|        &#39;Retrieving UUID from the array&#39; |   5000 |  8,601.397 μs |   159.8428 μs |   395.0919 μs |  8,536.2000 μs |  0.17 |    0.01 |
| &#39;Retrieving String UUID from the array&#39; |   5000 | 51,958.152 μs | 1,049.5518 μs | 2,977.4037 μs | 50,878.9500 μs |  1.00 |    0.00 |
