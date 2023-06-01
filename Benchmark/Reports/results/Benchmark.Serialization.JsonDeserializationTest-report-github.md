``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]               : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Json Deserialization : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Json Deserialization  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
| Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|  UUIDs | 4.963 ms | 0.0884 ms | 0.2298 ms |  1.46 |    0.40 |   2.05 MB |        1.00 |
|  Guids | 3.439 ms | 0.3400 ms | 1.0026 ms |  1.00 |    0.00 |   2.05 MB |        1.00 |
