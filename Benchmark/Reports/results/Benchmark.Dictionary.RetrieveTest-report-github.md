``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                   : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Retrieve from dictionary : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Retrieve from dictionary  RunStrategy=Throughput  WarmupCount=10  

```
|        Method |     Mean |   Error |  StdDev | Ratio |
|-------------- |---------:|--------:|--------:|------:|
|          Guid | 154.5 μs | 3.04 μs | 3.13 μs |  0.54 |
|          UUID | 157.1 μs | 2.67 μs | 2.50 μs |  0.55 |
| &#39;String UUID&#39; | 285.9 μs | 5.31 μs | 4.97 μs |  1.00 |
