``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Dictionary  RunStrategy=Throughput  WarmupCount=10  

```
|                                       Method |     Mean |   Error |  StdDev | Ratio | RatioSD |
|--------------------------------------------- |---------:|--------:|--------:|------:|--------:|
|        &#39;Retrieving Guid from the dictionary&#39; | 159.6 μs | 3.12 μs | 2.92 μs |  0.53 |    0.01 |
|        &#39;Retrieving UUID from the dictionary&#39; | 160.3 μs | 3.05 μs | 3.13 μs |  0.53 |    0.02 |
| &#39;Retrieving String UUID from the dictionary&#39; | 299.7 μs | 5.83 μs | 6.48 μs |  1.00 |    0.00 |
