``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                  : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating v4 as string : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating v4 as string  InvocationCount=5000000  IterationCount=5  
RunStrategy=Throughput  

```
|                                Method |     Mean |    Error |  StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|-------------------------------------- |---------:|---------:|--------:|------:|--------:|-------:|----------:|------------:|
| &#39;Generating UUID v4, standard method&#39; | 115.3 ns | 29.21 ns | 7.59 ns |  0.49 |    0.04 | 0.0228 |      96 B |        1.00 |
|    &#39;Generating Guid, standard method&#39; | 231.3 ns | 34.97 ns | 5.41 ns |  1.00 |    0.00 | 0.0228 |      96 B |        1.00 |
