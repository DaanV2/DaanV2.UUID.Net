``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]               : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Json Deserialization : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Json Deserialization  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
| Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
|  UUIDs | 5.580 ms | 0.3546 ms | 0.9648 ms | 5.138 ms |  1.76 |    0.32 |   2.05 MB |        1.00 |
|  Guids | 3.161 ms | 0.2566 ms | 0.7526 ms | 3.045 ms |  1.00 |    0.00 |   2.05 MB |        1.00 |
