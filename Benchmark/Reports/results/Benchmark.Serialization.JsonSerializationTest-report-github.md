``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]             : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Json Serialization : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Json Serialization  InvocationCount=1  RunStrategy=Throughput  
UnrollFactor=1  

```
|              Method |      Mean |    Error |   StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |----------:|---------:|---------:|------:|--------:|----------:|------------:|
| &#39;Serializing UUIDs&#39; | 104.36 ms | 2.083 ms | 5.031 ms |  1.92 |    0.13 |  74.39 MB |        1.00 |
| &#39;Serializing Guids&#39; |  54.59 ms | 1.077 ms | 2.075 ms |  1.00 |    0.00 |  74.39 MB |        1.00 |
