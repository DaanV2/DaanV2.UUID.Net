``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                  : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating all versions : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating all versions  RunStrategy=Throughput  

```
| Method |      Mean |    Error |   StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
|     V1 |  91.92 ns | 1.840 ns | 2.392 ns |  1.39 |    0.04 |      - |         - |          NA |
|     V3 | 614.60 ns | 5.981 ns | 5.302 ns |  9.27 |    0.10 | 0.0267 |     112 B |          NA |
|     V4 |  11.53 ns | 0.259 ns | 0.337 ns |  0.17 |    0.01 |      - |         - |          NA |
|     V5 | 631.36 ns | 2.659 ns | 2.487 ns |  9.53 |    0.08 | 0.0267 |     112 B |          NA |
|   GUID |  66.28 ns | 0.534 ns | 0.499 ns |  1.00 |    0.00 |      - |         - |          NA |
