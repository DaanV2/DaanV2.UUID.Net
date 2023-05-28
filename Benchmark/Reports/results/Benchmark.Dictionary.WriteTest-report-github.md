``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]              : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Write to dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Write to dictionary  RunStrategy=Throughput  

```
|        Method |     Mean |   Error |   StdDev | Ratio | RatioSD |
|-------------- |---------:|--------:|---------:|------:|--------:|
|          Guid | 391.9 μs | 7.79 μs |  9.86 μs |  0.85 |    0.03 |
|          UUID | 393.7 μs | 4.90 μs |  4.35 μs |  0.84 |    0.02 |
| &#39;String UUID&#39; | 464.4 μs | 9.00 μs | 11.05 μs |  1.00 |    0.00 |
