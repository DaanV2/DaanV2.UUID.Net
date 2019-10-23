# Performance tests

Tested on a PC with the following specs:

* Intel I7-7700K CPU @ 4.20 Ghz
* Ram 48.0 GB, Speed 2400 Mhz

Each test has been done with the following code:

```csharp
Stopwatch stopwatch = new Stopwatch();

for (Int32 I = 0; I < TestCount; I++) {
    stopwatch.Start(); //Start stopwatch

    UUID[] Temp = UUIDFactory.CreateUUIDs(Count, 4, 2); //Generate UUIDs

    stopwatch.Stop(); //Stopwatch

    Temp = null; //Remove UUID
    GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, true); //Have the GC collect the UUIDs
    Console.WriteLine(I); //Output current test index
}
Output(stopwatch, TestCount, Count); //Output result
```

|Version |Variant |Total <br>milli seconds<br> per test |Total<br> ticks per<br> test |Per Item<br> milli seconds<br> per test |Per Item<br> ticks<br> per test |
|--------|--------|--------------------|------------|-----------------------|---------------|
|4 |1 |585.02 |5850205.5 |0.00058 |5.85 |
|4 |2 |640.91 |6409123.96 |0.00064 |6.40 |
