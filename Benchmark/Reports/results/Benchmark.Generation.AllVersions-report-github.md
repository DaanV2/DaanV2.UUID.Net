``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22000.1936/21H2/SunValley)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.302
  [Host]                  : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  Generating all versions : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=Generating all versions  RunStrategy=Throughput  

```
| Method |      Mean |     Error |   StdDev |    Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------- |----------:|----------:|---------:|----------:|------:|--------:|-------:|----------:|------------:|
|     V1 |  94.53 ns |  1.803 ns | 2.345 ns |  95.05 ns |  1.39 |    0.04 |      - |         - |          NA |
|     V3 | 640.78 ns |  5.655 ns | 5.289 ns | 639.37 ns |  9.39 |    0.13 | 0.0267 |     112 B |          NA |
|     V4 |  13.41 ns |  0.791 ns | 2.283 ns |  12.34 ns |  0.17 |    0.03 |      - |         - |          NA |
|     V5 | 648.00 ns | 10.327 ns | 9.660 ns | 649.45 ns |  9.50 |    0.16 | 0.0267 |     112 B |          NA |
|   GUID |  68.26 ns |  0.614 ns | 0.544 ns |  68.28 ns |  1.00 |    0.00 |      - |         - |          NA |
