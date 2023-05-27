``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host] : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  List   : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=List  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  WarmupCount=10  

```
|                                  Method | Amount |          Mean |         Error |        StdDev |        Median | Ratio | RatioSD |
|---------------------------------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|
|        **&#39;Retrieving Guid from the array&#39;** |     **10** |      **2.000 μs** |     **0.2829 μs** |     **0.8341 μs** |      **1.850 μs** |  **0.76** |    **0.42** |
|        &#39;Retrieving UUID from the array&#39; |     10 |      3.409 μs |     0.4612 μs |     1.3234 μs |      3.000 μs |  1.26 |    0.65 |
| &#39;Retrieving String UUID from the array&#39; |     10 |      3.045 μs |     0.4210 μs |     1.2079 μs |      2.850 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |    **100** |     **13.040 μs** |     **0.2686 μs** |     **0.4414 μs** |     **12.800 μs** |  **0.49** |    **0.02** |
|        &#39;Retrieving UUID from the array&#39; |    100 |     51.484 μs |     4.1756 μs |    11.9805 μs |     45.200 μs |  1.83 |    0.40 |
| &#39;Retrieving String UUID from the array&#39; |    100 |     26.838 μs |     0.5301 μs |     0.9825 μs |     26.450 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **1000** |  **1,023.386 μs** |     **9.9108 μs** |     **8.7857 μs** |  **1,020.600 μs** |  **0.41** |    **0.04** |
|        &#39;Retrieving UUID from the array&#39; |   1000 |    430.687 μs |    28.7356 μs |    76.2027 μs |    407.950 μs |  0.19 |    0.04 |
| &#39;Retrieving String UUID from the array&#39; |   1000 |  2,315.675 μs |   100.9343 μs |   283.0307 μs |  2,295.300 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **2000** |  **3,456.698 μs** |   **185.1713 μs** |   **540.1535 μs** |  **3,236.100 μs** |  **0.40** |    **0.06** |
|        &#39;Retrieving UUID from the array&#39; |   2000 |  1,310.448 μs |    44.9607 μs |   128.2753 μs |  1,273.900 μs |  0.15 |    0.02 |
| &#39;Retrieving String UUID from the array&#39; |   2000 |  8,568.739 μs |   269.8785 μs |   778.6612 μs |  8,249.450 μs |  1.00 |    0.00 |
|                                         |        |               |               |               |               |       |         |
|        **&#39;Retrieving Guid from the array&#39;** |   **5000** | **20,152.800 μs** |   **545.0309 μs** | **1,546.1620 μs** | **19,572.500 μs** |  **0.36** |    **0.04** |
|        &#39;Retrieving UUID from the array&#39; |   5000 |  9,935.936 μs |   402.2948 μs | 1,147.7698 μs |  9,605.000 μs |  0.18 |    0.02 |
| &#39;Retrieving String UUID from the array&#39; |   5000 | 56,147.220 μs | 1,677.5540 μs | 4,758.9415 μs | 55,481.600 μs |  1.00 |    0.00 |
