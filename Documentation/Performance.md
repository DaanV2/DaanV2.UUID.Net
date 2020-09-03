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

|Platform|Version |Variant |milli seconds per test |ticks per test |
|--------|--------|--------|---|---|
|x64 |3 |1 |862.16|8621671.22|
|x86 |3 |1 |962.88|9628817.96|
|x64 |4 |1 |520.05|5200573.44|
|x86 |4 |1 |640.21|6402178.25|
|x64 |4 |2 |377.31|3773191.76|
|x86 |4 |2 |466.59|4665937.1|
|x64 |5 |1 |846.58|8465804.44|
|x86 |5 |1 |980.54|9805465.16|

### Distribution Graph

![Graph](Data/Graph.png)

