``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]              : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Write to dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Write to dictionary  RunStrategy=Throughput  

```
|        Method |     Mean |   Error |   StdDev |   Median | Ratio | RatioSD |
|-------------- |---------:|--------:|---------:|---------:|------:|--------:|
|          Guid | 395.5 μs | 8.69 μs | 25.20 μs | 383.0 μs |  0.87 |    0.04 |
|          UUID | 400.0 μs | 7.29 μs | 11.78 μs | 396.3 μs |  0.82 |    0.04 |
| &#39;String UUID&#39; | 486.9 μs | 9.26 μs | 10.67 μs | 481.4 μs |  1.00 |    0.00 |
