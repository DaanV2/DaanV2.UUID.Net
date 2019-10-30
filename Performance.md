# Performance tests

## Setup

Tested on a PC with the following specs:

* Intel I7-7700K CPU @ 4.20 Ghz
* Ram 48.0 GB, Speed 2400 Mhz
* 100 Tests
* 1.000.000 UUID Amount

## Benchmark Code

Each test has been done with the following code:

```csharp
public static void Test(Int32 Version, Int32 Variant, Int32 TestCount = 100, Int32 Count = 1000000) {
    Stopwatch stopwatch = new Stopwatch();

    for (Int32 I = 0; I < TestCount; I++) {
        stopwatch.Start();

        UUID[] Temp = UUIDFactory.CreateUUIDs(Count, Version, Variant);

        stopwatch.Stop();

        Temp = null;
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, true);
        Console.Title = $"V{Version}.{Variant}\t-\t{I}/{TestCount}";
    }

    Console.WriteLine($"=== Version {Version}\tVariant {Variant} ===");
    Output(stopwatch, Version, Variant, TestCount, Count);
}
```

## Results

|Version |Variant |Total <br>milli seconds<br> per test |Total<br> ticks per<br> test |Per Item<br> milli seconds<br> per test |Per Item<br> ticks<br> per test |
|---|---|---|---|---|---|
|3 |1 |1.4E+03 |1.4E+07 |0.0014 |14 |
|4 |1 |5.1E+02 |5.1E+06 |0.00051 |5.1 |
|4 |2 |5.4E+02 |5.4E+06 |0.00054 |5.4 |
|5 |1 |1.5E+03 |1.5E+07 |0.0015 |15 |
