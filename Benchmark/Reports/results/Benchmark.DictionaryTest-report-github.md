``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Dictionary  RunStrategy=Throughput  WarmupCount=10  

```
|                                       Method |     Mean |   Error |   StdDev | Ratio | RatioSD |
|--------------------------------------------- |---------:|--------:|---------:|------:|--------:|
|        &#39;Retrieving Guid from the dictionary&#39; | 172.5 μs | 3.39 μs |  5.17 μs |  0.55 |    0.02 |
|        &#39;Retrieving UUID from the dictionary&#39; | 173.7 μs | 3.46 μs |  7.73 μs |  0.55 |    0.03 |
| &#39;Retrieving String UUID from the dictionary&#39; | 316.6 μs | 6.27 μs | 10.48 μs |  1.00 |    0.00 |
