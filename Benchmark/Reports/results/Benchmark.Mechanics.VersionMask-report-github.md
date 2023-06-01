``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                                    : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Version masking, as vector or just bytes? : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Version masking, as vector or just bytes?  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
|                                             Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
|             &#39;Using Vector128 and constants values&#39; | 267.9 ns |  18.20 ns |  46.97 ns | 300.0 ns |  0.65 |    0.13 |     504 B |        1.00 |
|         &#39;Using Vector128 and using dynamic values&#39; | 300.0 ns |   0.00 ns |   0.00 ns | 300.0 ns |  0.70 |    0.10 |     504 B |        1.00 |
| &#39;Using Vector128 and using static masks &amp; overlay&#39; | 722.2 ns | 101.66 ns | 298.14 ns | 800.0 ns |  1.76 |    0.73 |     504 B |        1.00 |
|                  &#39;Using bytes and constant values&#39; | 417.2 ns |  16.90 ns |  46.27 ns | 400.0 ns |  1.00 |    0.00 |     504 B |        1.00 |
