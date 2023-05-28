``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]               : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Json Deserialization : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Json Deserialization  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
|                Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
| &#39;Deserializing UUIDs&#39; | 5.263 ms | 0.1547 ms | 0.4156 ms | 5.146 ms |  1.78 |    0.47 |   2.05 MB |        1.00 |
| &#39;Deserializing Guids&#39; | 3.095 ms | 0.3319 ms | 0.9577 ms | 2.596 ms |  1.00 |    0.00 |   2.05 MB |        1.00 |
