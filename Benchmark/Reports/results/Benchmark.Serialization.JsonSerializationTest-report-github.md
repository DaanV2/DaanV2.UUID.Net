``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]             : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Json Serialization : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Json Serialization  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
| Method |      Mean |    Error |   StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |----------:|---------:|---------:|------:|--------:|----------:|------------:|
|  UUIDs | 100.61 ms | 1.969 ms | 3.746 ms |  1.98 |    0.10 |  74.39 MB |        1.00 |
|  Guids |  50.71 ms | 0.979 ms | 1.740 ms |  1.00 |    0.00 |  74.39 MB |        1.00 |
