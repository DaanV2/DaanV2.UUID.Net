``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]       : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Hashing Sha1 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Hashing Sha1  RunStrategy=Throughput  

```
|          Method |       Mean |    Error |   StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|---------------- |-----------:|---------:|---------:|-------:|-------:|-------:|----------:|
|            Sha1 |   528.7 ns | 10.59 ns |  9.91 ns |      - |      - |      - |         - |
|         TrySha1 |   525.0 ns | 10.50 ns | 14.72 ns |      - |      - |      - |         - |
| &#39;Sha1 Instance&#39; | 1,283.7 ns | 25.70 ns | 72.89 ns | 0.0305 | 0.0076 | 0.0038 |     128 B |
|   &#39;Sha1 Global&#39; |   369.7 ns |  7.37 ns | 11.26 ns |      - |      - |      - |         - |
