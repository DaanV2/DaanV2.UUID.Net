``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]             : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Json Serialization : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Json Serialization  InvocationCount=500  RunStrategy=Throughput  
UnrollFactor=1  WarmupCount=10  

```
|              Method |     Mean |    Error |   StdDev | Ratio |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|-------------------- |---------:|---------:|---------:|------:|---------:|---------:|---------:|----------:|------------:|
| &#39;Serializing UUIDs&#39; | 96.93 ms | 0.312 ms | 0.243 ms |  1.92 | 152.0000 | 152.0000 | 152.0000 |  74.39 MB |        1.00 |
| &#39;Serializing Guids&#39; | 50.39 ms | 0.123 ms | 0.115 ms |  1.00 | 152.0000 | 152.0000 | 152.0000 |  74.39 MB |        1.00 |
