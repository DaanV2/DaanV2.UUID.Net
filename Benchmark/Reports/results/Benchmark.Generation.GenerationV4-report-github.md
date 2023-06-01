``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]        : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating v4 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating v4  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
|                            Method |     Mean |    Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |---------:|---------:|----------:|---------:|------:|--------:|----------:|------------:|
|        &#39;UUID v4, standard method&#39; | 757.1 ns | 21.06 ns |  56.58 ns | 800.0 ns |  1.13 |    0.13 |     504 B |        1.00 |
| &#39;UUID v4, with a supplied random&#39; | 513.4 ns | 19.30 ns |  54.74 ns | 550.0 ns |  0.77 |    0.09 |     504 B |        1.00 |
|                &#39;GUID with a UUID&#39; | 958.0 ns | 43.94 ns | 120.29 ns | 950.0 ns |  1.43 |    0.20 |     504 B |        1.00 |
|           &#39;Guid, standard method&#39; | 677.8 ns | 22.16 ns |  57.59 ns | 650.0 ns |  1.00 |    0.00 |     504 B |        1.00 |
