``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                   : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Retrieve from dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Retrieve from dictionary  RunStrategy=Throughput  WarmupCount=10  

```
|        Method |     Mean |   Error |  StdDev |   Median | Ratio | RatioSD |
|-------------- |---------:|--------:|--------:|---------:|------:|--------:|
|          Guid | 153.9 μs | 3.00 μs | 4.30 μs | 155.6 μs |  0.55 |    0.02 |
|          UUID | 153.2 μs | 3.02 μs | 4.33 μs | 156.0 μs |  0.55 |    0.02 |
| &#39;String UUID&#39; | 280.7 μs | 5.50 μs | 8.40 μs | 282.6 μs |  1.00 |    0.00 |
