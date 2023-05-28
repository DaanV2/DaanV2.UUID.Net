``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]        : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating v4 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating v4  InvocationCount=50000000  IterationCount=5  
RunStrategy=Throughput  

```
|                            Method |      Mean |    Error |    StdDev | Ratio | Allocated | Alloc Ratio |
|---------------------------------- |----------:|---------:|----------:|------:|----------:|------------:|
|        &#39;UUID v4, standard method&#39; | 11.512 ns | 2.052 ns | 0.5329 ns |  0.17 |         - |          NA |
| &#39;UUID v4, with a supplied random&#39; |  8.222 ns | 1.086 ns | 0.2821 ns |  0.12 |         - |          NA |
|                &#39;GUID with a UUID&#39; | 23.805 ns | 2.510 ns | 0.3884 ns |  0.36 |         - |          NA |
|           &#39;Guid, standard method&#39; | 66.057 ns | 1.307 ns | 0.3395 ns |  1.00 |         - |          NA |
