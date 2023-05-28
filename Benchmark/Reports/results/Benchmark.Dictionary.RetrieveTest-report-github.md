``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                   : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Retrieve from dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Retrieve from dictionary  RunStrategy=Throughput  WarmupCount=10  

```
|        Method |     Mean |   Error |  StdDev | Ratio | RatioSD |
|-------------- |---------:|--------:|--------:|------:|--------:|
|          Guid | 160.3 μs | 1.93 μs | 1.71 μs |  0.54 |    0.01 |
|          UUID | 162.8 μs | 3.21 μs | 4.39 μs |  0.55 |    0.02 |
| &#39;String UUID&#39; | 296.6 μs | 5.63 μs | 6.03 μs |  1.00 |    0.00 |
