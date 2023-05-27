``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]        : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating v4 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating v4  InvocationCount=50000000  IterationCount=5  
RunStrategy=Throughput  

```
|                            Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|        &#39;UUID v4, standard method&#39; | 12.920 ns |  1.848 ns | 0.4800 ns |  0.16 |    0.02 |         - |          NA |
| &#39;UUID v4, with a supplied random&#39; |  9.216 ns |  1.908 ns | 0.2952 ns |  0.11 |    0.01 |         - |          NA |
|                &#39;GUID with a UUID&#39; | 31.582 ns | 18.131 ns | 4.7086 ns |  0.39 |    0.05 |         - |          NA |
|           &#39;Guid, standard method&#39; | 81.254 ns | 26.107 ns | 6.7798 ns |  1.00 |    0.00 |         - |          NA |
