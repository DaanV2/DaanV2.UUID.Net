``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                                    : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Version masking, as vector or just bytes? : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Version masking, as vector or just bytes?  InvocationCount=5000000  IterationCount=50  
RunStrategy=Throughput  

```
|                                             Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
|             &#39;Using Vector128 and constants values&#39; | 1.5045 ns | 0.0635 ns | 0.1238 ns | 1.5246 ns |  0.34 |    0.03 |         - |          NA |
|         &#39;Using Vector128 and using dynamic values&#39; | 1.3325 ns | 0.0620 ns | 0.1252 ns | 1.3774 ns |  0.30 |    0.03 |         - |          NA |
| &#39;Using Vector128 and using static masks &amp; overlay&#39; | 0.9754 ns | 0.0625 ns | 0.1247 ns | 0.9232 ns |  0.22 |    0.03 |         - |          NA |
|                  &#39;Using bytes and constant values&#39; | 4.4093 ns | 0.1013 ns | 0.1976 ns | 4.5136 ns |  1.00 |    0.00 |         - |          NA |
