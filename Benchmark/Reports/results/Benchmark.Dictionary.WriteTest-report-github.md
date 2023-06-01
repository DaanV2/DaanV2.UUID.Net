``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]              : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Write to dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Write to dictionary  RunStrategy=Throughput  

```
|        Method |     Mean |   Error |  StdDev | Ratio |
|-------------- |---------:|--------:|--------:|------:|
|          Guid | 370.6 μs | 2.72 μs | 2.54 μs |  0.80 |
|          UUID | 378.3 μs | 4.93 μs | 4.61 μs |  0.82 |
| &#39;String UUID&#39; | 460.4 μs | 2.60 μs | 2.44 μs |  1.00 |
