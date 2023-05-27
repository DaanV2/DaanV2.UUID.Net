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
|          Guid | 386.1 μs | 3.29 μs |  2.75 μs |  0.78 |    0.02 |
|          UUID | 412.9 μs | 8.20 μs | 13.25 μs |  0.84 |    0.03 |
| &#39;String UUID&#39; | 494.2 μs | 9.81 μs | 14.07 μs |  1.00 |    0.00 |
