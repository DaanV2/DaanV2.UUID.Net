``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host] : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  List   : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=List  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  WarmupCount=10  

```
|                                  Method | Amount |          Mean |       Error |        StdDev |        Median | Ratio | RatioSD |
|---------------------------------------- |------- |--------------:|------------:|--------------:|--------------:|------:|--------:|
|        **&#39;Retrieving Guid from the array&#39;** |     **10** |      **1.655 μs** |   **0.2655 μs** |     **0.7827 μs** |      **1.400 μs** |  **0.72** |    **0.47** |
|        &#39;Retrieving UUID from the array&#39; |     10 |      3.546 μs |   0.4959 μs |     1.4544 μs |      2.900 μs |  1.50 |    0.93 |
| &#39;Retrieving String UUID from the array&#39; |     10 |      2.719 μs |   0.3714 μs |     1.0716 μs |      2.550 μs |  1.00 |    0.00 |
|                                         |        |               |             |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |    **100** |     **12.742 μs** |   **0.2632 μs** |     **0.4679 μs** |     **12.700 μs** |  **0.48** |    **0.02** |
|        &#39;Retrieving UUID from the array&#39; |    100 |     52.780 μs |   5.2647 μs |    15.3574 μs |     44.300 μs |  2.05 |    0.60 |
| &#39;Retrieving String UUID from the array&#39; |    100 |     26.503 μs |   0.5349 μs |     0.8936 μs |     26.100 μs |  1.00 |    0.00 |
|                                         |        |               |             |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **1000** |    **968.084 μs** |  **56.0240 μs** |   **163.4247 μs** |  **1,004.150 μs** |  **0.44** |    **0.07** |
|        &#39;Retrieving UUID from the array&#39; |   1000 |  1,930.623 μs | 710.1848 μs | 2,093.9958 μs |    403.550 μs |  0.92 |    0.94 |
| &#39;Retrieving String UUID from the array&#39; |   1000 |  2,231.088 μs |  76.0308 μs |   211.9434 μs |  2,217.400 μs |  1.00 |    0.00 |
|                                         |        |               |             |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **2000** |  **4,063.821 μs** |  **70.7895 μs** |    **62.7530 μs** |  **4,054.250 μs** |  **0.48** |    **0.04** |
|        &#39;Retrieving UUID from the array&#39; |   2000 |  1,223.558 μs |  26.4042 μs |    70.4783 μs |  1,195.250 μs |  0.16 |    0.01 |
| &#39;Retrieving String UUID from the array&#39; |   2000 |  7,894.216 μs | 168.5903 μs |   467.1630 μs |  7,694.700 μs |  1.00 |    0.00 |
|                                         |        |               |             |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **5000** | **18,502.093 μs** | **369.5512 μs** |   **553.1268 μs** | **18,652.500 μs** |  **0.37** |    **0.02** |
|        &#39;Retrieving UUID from the array&#39; |   5000 |  8,516.514 μs | 169.4056 μs |   248.3125 μs |  8,493.200 μs |  0.17 |    0.01 |
| &#39;Retrieving String UUID from the array&#39; |   5000 | 50,098.510 μs | 995.7368 μs | 2,056.3691 μs | 48,883.300 μs |  1.00 |    0.00 |
