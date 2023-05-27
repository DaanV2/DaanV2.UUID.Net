``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                                    : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Version masking, as vector or just bytes? : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Version masking, as vector or just bytes?  InvocationCount=5000000  IterationCount=50  
RunStrategy=Throughput  

```
|                                             Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|             &#39;Using Vector128 and constants values&#39; | 1.756 ns | 0.0806 ns | 0.1514 ns |  0.37 |    0.04 |         - |          NA |
|         &#39;Using Vector128 and using dynamic values&#39; | 1.527 ns | 0.1242 ns | 0.2451 ns |  0.32 |    0.06 |         - |          NA |
| &#39;Using Vector128 and using static masks &amp; overlay&#39; | 1.104 ns | 0.0669 ns | 0.1206 ns |  0.23 |    0.03 |         - |          NA |
|                  &#39;Using bytes and constant values&#39; | 4.785 ns | 0.1532 ns | 0.2988 ns |  1.00 |    0.00 |         - |          NA |
