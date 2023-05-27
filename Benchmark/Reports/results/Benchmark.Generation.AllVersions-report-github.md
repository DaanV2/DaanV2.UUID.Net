``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                  : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating all versions : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating all versions  RunStrategy=Throughput  

```
| Method |      Mean |    Error |   StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |----------:|---------:|---------:|------:|--------:|----------:|------------:|
|     V1 | 105.84 ns | 1.996 ns | 2.732 ns |  1.50 |    0.04 |         - |          NA |
|     V4 |  13.48 ns | 0.295 ns | 0.362 ns |  0.19 |    0.01 |         - |          NA |
|   GUID |  71.06 ns | 1.338 ns | 1.186 ns |  1.00 |    0.00 |         - |          NA |
