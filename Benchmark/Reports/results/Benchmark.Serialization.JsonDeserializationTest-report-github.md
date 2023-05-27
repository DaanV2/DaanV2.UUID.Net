``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]               : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Json Deserialization : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Json Deserialization  InvocationCount=500  RunStrategy=Throughput  
UnrollFactor=1  WarmupCount=10  

```
|                Method |     Mean |     Error |    StdDev | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|---------------------- |---------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| &#39;Deserializing UUIDs&#39; | 5.531 ms | 0.1093 ms | 0.1999 ms |  1.73 |    0.16 | 522.0000 | 492.0000 | 490.0000 |   2.05 MB |        1.00 |
| &#39;Deserializing Guids&#39; | 3.177 ms | 0.0999 ms | 0.2915 ms |  1.00 |    0.00 | 528.0000 | 502.0000 | 496.0000 |   2.05 MB |        1.00 |
