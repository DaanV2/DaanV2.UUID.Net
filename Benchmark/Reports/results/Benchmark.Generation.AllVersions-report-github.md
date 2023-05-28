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
|     V1 |  98.16 ns | 1.935 ns | 2.836 ns |  1.50 |    0.04 |      - |         - |          NA |
|     V4 |  12.80 ns | 0.207 ns | 0.183 ns |  0.19 |    0.00 |      - |         - |          NA |
|     V5 | 639.67 ns | 5.649 ns | 4.410 ns |  9.67 |    0.13 | 0.0267 |     112 B |          NA |
|   GUID |  66.14 ns | 0.677 ns | 0.565 ns |  1.00 |    0.00 |      - |         - |          NA |
