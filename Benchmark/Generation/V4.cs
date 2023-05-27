using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.Generation;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Generating v4", iterationCount: 5, invocationCount: 50_000_000)]
public partial class GenerationV4 {
    public Random R { get; set; } = new Random();

    [IterationSetup]
    public void Setup() {
        this.R = new Random();
    }

    [Benchmark(Description = "UUID v4, standard method")]
    public UUID UUID() {
        return V4.Generate();
    }

    [Benchmark(Description = "UUID v4, with a supplied random")]
    public UUID UUIDRandom() {
        return V4.Generate(this.R);
    }

    [Benchmark(Description = "GUID with a UUID")]
    public Guid UUIDToGuid() {
        return V4.Generate(this.R).ToGuid();
    }

    [Benchmark(Baseline = true, Description = "Guid, standard method")]
    public Guid GUIDs() {
        return Guid.NewGuid();
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Generating v4 as string", iterationCount: 5, invocationCount: 5000_000)]
public partial class StringGenerationV4 {
    public Random R { get; set; } = new Random();

    [IterationSetup]
    public void Setup() {
        this.R = new Random();
    }

    [Benchmark(Description = "Generating UUID v4, standard method")]
    public String UUID() {
        return V4.Generate(this.R).ToString();
    }

    [Benchmark(Baseline = true, Description = "Generating Guid, standard method")]
    public String GUIDs() {
        return Guid.NewGuid().ToString();
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, iterationCount: 5, id: "Generating batches v4")]
public partial class GenerationBatchV4 {

    [Params(10, 100, 500, 1000, 10000, 1000_000)]
    public Int32 Amount { get; set; }

    [Benchmark(Description = "UUID V4, Using the global randomizer")]
    public UUID[] UUIDs() {
        return V4.GenerateBatch(this.Amount);
    }

    [Benchmark(Description = "UUID V4, Using a local randomizer")]
    public UUID[] UUIDsRandom() {
        var R = new Random();
        return V4.GenerateBatch(this.Amount, R);
    }

    [Benchmark(Description = "UUID V4, Using a supplied byte array")]
    public UUID[] UUIDsMac() {
        var R = new Random();
        Byte[] bytes = new Byte[Format.UUID_BYTE_LENGTH * this.Amount];

        return V4.GenerateBatch(bytes);
    }

    [Benchmark(Description = "GUID using UUIDS V4, Using a local randomizer")]
    public Guid[] UUIDsToGuid() {
        var R = new Random();
        return V4.GenerateBatch(this.Amount, R).Select(m => m.ToGuid()).ToArray();
    }

    [Benchmark(Baseline = true, Description = "GUID")]
    public Guid[] GUIDs() {
        var result = new Guid[this.Amount];

        for (Int32 I = 0; I < this.Amount; I++) {
            result[I] = Guid.NewGuid();
        }

        return result;
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Generating batches v4 as strings", iterationCount: 5, invocationCount: 5000)]
public partial class StringBatchGenerationV4 {
    [Params(10, 100, 500, 1000)]
    public Int32 Amount { get; set; }
    public Random R { get; set; }

    [IterationSetup]
    public void Setup() {
        this.R = new Random();
    }

    [Benchmark(Description = "UUID v4")]
    public String[] UUID() {
        Random R = this.R;
        String[] result = new String[this.Amount];

        for (Int32 I = 0; I < this.Amount; I++) {
            result[I] = V4.Generate(R).ToString();
        }

        return result;
    }

    [Benchmark(Baseline = true, Description = "Guid")]
    public String[] GUIDs() {
        String[] result = new String[this.Amount];

        for (Int32 I = 0; I < this.Amount; I++) {
            result[I] = Guid.NewGuid().ToString();
        }

        return result;
    }
}