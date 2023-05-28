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
|             &#39;Using Vector128 and constants values&#39; | 1.9934 ns | 0.2511 ns | 0.5014 ns | 1.8641 ns |  0.43 |    0.11 |         - |          NA |
|         &#39;Using Vector128 and using dynamic values&#39; | 1.5831 ns | 0.2567 ns | 0.5066 ns | 1.4554 ns |  0.34 |    0.11 |         - |          NA |
| &#39;Using Vector128 and using static masks &amp; overlay&#39; | 0.5082 ns | 0.1100 ns | 0.2120 ns | 0.4227 ns |  0.11 |    0.05 |         - |          NA |
|                  &#39;Using bytes and constant values&#39; | 4.6790 ns | 0.0825 ns | 0.1666 ns | 4.6145 ns |  1.00 |    0.00 |         - |          NA |
