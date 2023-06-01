``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                  : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating v4 as string : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating v4 as string  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
|                                Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
| &#39;Generating UUID v4, standard method&#39; | 1.790 μs | 0.0406 μs | 0.0607 μs | 1.800 μs |  0.85 |    0.15 |     600 B |        1.00 |
|    &#39;Generating Guid, standard method&#39; | 2.036 μs | 0.1378 μs | 0.3748 μs | 1.900 μs |  1.00 |    0.00 |     600 B |        1.00 |
