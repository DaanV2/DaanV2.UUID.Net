``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]        : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating v4 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating v4  InvocationCount=50000000  IterationCount=5  
RunStrategy=Throughput  

```
|                                       Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|        &#39;Generating UUID v4, standard method&#39; | 11.750 ns | 1.0267 ns | 0.2666 ns |  0.17 |    0.00 |         - |          NA |
| &#39;Generating UUID v4, with a supplied random&#39; |  9.106 ns | 1.3929 ns | 0.3617 ns |  0.14 |    0.00 |         - |          NA |
|                &#39;Generating GUID with a UUID&#39; | 25.594 ns | 4.5708 ns | 1.1870 ns |  0.38 |    0.02 |         - |          NA |
|           &#39;Generating Guid, standard method&#39; | 67.123 ns | 0.5460 ns | 0.0845 ns |  1.00 |    0.00 |         - |          NA |
