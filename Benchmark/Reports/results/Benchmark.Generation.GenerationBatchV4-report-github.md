``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating batches v4 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating batches v4  IterationCount=5  RunStrategy=Throughput  

```
|                                                                Method |  Amount |            Mean |           Error |        StdDev | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 |  Allocated | Alloc Ratio |
|---------------------------------------------------------------------- |-------- |----------------:|----------------:|--------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
|          **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** |      **10** |        **154.2 ns** |         **1.05 ns** |       **0.16 ns** |  **0.21** |    **0.00** |   **0.0439** |        **-** |        **-** |      **184 B** |        **1.00** |
|             &#39;Generating a batch of UUID V4, Using a local randomizer&#39; |      10 |        238.0 ns |         9.49 ns |       2.46 ns |  0.33 |    0.00 |   0.0610 |        - |        - |      256 B |        1.39 |
| &#39;Generating a batch of GUID using UUIDS V4, Using a local randomizer&#39; |      10 |        484.6 ns |        13.83 ns |       2.14 ns |  0.66 |    0.00 |   0.1183 |        - |        - |      496 B |        2.70 |
|                                       &#39;Generating a batch of UUID V4&#39; |      10 |        731.9 ns |        16.07 ns |       4.17 ns |  1.00 |    0.00 |   0.0439 |        - |        - |      184 B |        1.00 |
|                                                                       |         |                 |                 |               |       |         |          |          |          |            |             |
|          **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** |     **100** |      **1,439.8 ns** |        **75.03 ns** |      **19.49 ns** |  **0.19** |    **0.00** |   **0.3872** |        **-** |        **-** |     **1624 B** |        **1.00** |
|             &#39;Generating a batch of UUID V4, Using a local randomizer&#39; |     100 |      1,231.0 ns |        19.51 ns |       3.02 ns |  0.17 |    0.00 |   0.4044 |        - |        - |     1696 B |        1.04 |
| &#39;Generating a batch of GUID using UUIDS V4, Using a local randomizer&#39; |     100 |      3,271.5 ns |       225.08 ns |      34.83 ns |  0.44 |    0.01 |   0.8049 |        - |        - |     3376 B |        2.08 |
|                                       &#39;Generating a batch of UUID V4&#39; |     100 |      7,461.8 ns |       370.38 ns |      96.19 ns |  1.00 |    0.00 |   0.3815 |        - |        - |     1624 B |        1.00 |
|                                                                       |         |                 |                 |               |       |         |          |          |          |            |             |
|          **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** |     **500** |      **7,170.3 ns** |       **258.60 ns** |      **67.16 ns** |  **0.20** |    **0.00** |   **1.9150** |        **-** |        **-** |     **8024 B** |        **1.00** |
|             &#39;Generating a batch of UUID V4, Using a local randomizer&#39; |     500 |      5,581.6 ns |       131.85 ns |      20.40 ns |  0.15 |    0.00 |   1.9302 |        - |        - |     8096 B |        1.01 |
| &#39;Generating a batch of GUID using UUIDS V4, Using a local randomizer&#39; |     500 |     15,818.2 ns |       734.36 ns |     190.71 ns |  0.43 |    0.01 |   3.8452 |        - |        - |    16176 B |        2.02 |
|                                       &#39;Generating a batch of UUID V4&#39; |     500 |     36,646.6 ns |     1,071.86 ns |     278.36 ns |  1.00 |    0.00 |   1.8921 |        - |        - |     8024 B |        1.00 |
|                                                                       |         |                 |                 |               |       |         |          |          |          |            |             |
|          **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** |    **1000** |     **14,236.6 ns** |       **166.63 ns** |      **25.79 ns** |  **0.19** |    **0.00** |   **3.8147** |        **-** |        **-** |    **16024 B** |        **1.00** |
|             &#39;Generating a batch of UUID V4, Using a local randomizer&#39; |    1000 |     11,122.0 ns |     1,680.44 ns |     436.40 ns |  0.15 |    0.01 |   3.8452 |        - |        - |    16096 B |        1.00 |
| &#39;Generating a batch of GUID using UUIDS V4, Using a local randomizer&#39; |    1000 |     31,083.9 ns |     1,964.09 ns |     303.94 ns |  0.42 |    0.00 |   7.6904 |        - |        - |    32176 B |        2.01 |
|                                       &#39;Generating a batch of UUID V4&#39; |    1000 |     73,747.7 ns |     1,481.30 ns |     229.23 ns |  1.00 |    0.00 |   3.7842 |        - |        - |    16024 B |        1.00 |
|                                                                       |         |                 |                 |               |       |         |          |          |          |            |             |
|          **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** |   **10000** |    **202,076.5 ns** |     **5,755.42 ns** |     **890.66 ns** |  **0.21** |    **0.01** |  **49.8047** |  **49.8047** |  **49.8047** |   **160041 B** |        **1.00** |
|             &#39;Generating a batch of UUID V4, Using a local randomizer&#39; |   10000 |    170,266.0 ns |     6,853.80 ns |   1,060.63 ns |  0.18 |    0.01 |  49.8047 |  49.8047 |  49.8047 |   160113 B |        1.00 |
| &#39;Generating a batch of GUID using UUIDS V4, Using a local randomizer&#39; |   10000 |    424,344.2 ns |     4,532.18 ns |     701.36 ns |  0.44 |    0.03 |  99.6094 |  99.6094 |  99.6094 |   320210 B |        2.00 |
|                                       &#39;Generating a batch of UUID V4&#39; |   10000 |    965,034.3 ns |   212,603.49 ns |  55,212.45 ns |  1.00 |    0.00 |  49.8047 |  49.8047 |  49.8047 |   160041 B |        1.00 |
|                                                                       |         |                 |                 |               |       |         |          |          |          |            |             |
|          **&#39;Generating a batch of UUID V4, Using the global randomizer&#39;** | **1000000** | **17,156,812.5 ns** | **2,090,903.59 ns** | **543,001.02 ns** |  **0.22** |    **0.01** | **375.0000** | **375.0000** | **375.0000** | **16000158 B** |        **1.00** |
|             &#39;Generating a batch of UUID V4, Using a local randomizer&#39; | 1000000 | 13,293,457.4 ns | 4,068,142.01 ns | 629,549.48 ns |  0.17 |    0.01 | 312.5000 | 312.5000 | 312.5000 | 16000202 B |        1.00 |
| &#39;Generating a batch of GUID using UUIDS V4, Using a local randomizer&#39; | 1000000 | 31,094,015.7 ns |   800,058.26 ns | 207,772.59 ns |  0.40 |    0.01 | 357.1429 | 357.1429 | 357.1429 | 32000327 B |        2.00 |
|                                       &#39;Generating a batch of UUID V4&#39; | 1000000 | 76,869,378.6 ns | 6,141,610.19 ns | 950,420.98 ns |  1.00 |    0.00 | 428.5714 | 428.5714 | 428.5714 | 16000230 B |        1.00 |
