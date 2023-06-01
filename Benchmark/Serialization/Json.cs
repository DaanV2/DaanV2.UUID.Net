using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.Serialization;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Json Serialization")]
public partial class JsonSerializationTest {
    public const Int32 Amount = 1000_000;

    public UUID[] UUIDs { get; set; } = Array.Empty<UUID>();
    public Guid[] Guids { get; set; } = Array.Empty<Guid>();


    [IterationSetup]
    public void Setup() {
        this.UUIDs = V4.Batch(Amount);
        this.Guids = this.UUIDs.Select(x => x.ToGuid()).ToArray();
    }

    [Benchmark(Description = "UUIDs")]
    public String UUID() {
        return JsonSerializer.Serialize(this.UUIDs);
    }

    [Benchmark(Description = "Guids", Baseline = true)]
    public String GUIDs() {
        return JsonSerializer.Serialize(this.Guids);
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Json Serialization With Generation")]
public partial class JsonSerializationGenerationTest {
    [Params(10, 100, 1000, 2500, 5000, 100_000)]
    public Int32 Amount { get; set; }

    [Benchmark(Description = "UUIDs")]
    public String UUID() {
        UUID[] UUIDs = V4.Batch(this.Amount);

        return JsonSerializer.Serialize(UUIDs);
    }

    [Benchmark(Description = "Guids", Baseline = true)]
    public String GUIDs() {
        var guids = new Guid[this.Amount];
        for (Int32 I = 0; I < this.Amount; I++) {
            guids[I] = Guid.NewGuid();
        }

        return JsonSerializer.Serialize(guids);
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Json Deserialization")]
public partial class JsonDeserializationTest {
    public const Int32 Amount = 20_000;

    public String Serialized { get; set; } = String.Empty;

    [IterationSetup]
    public void Setup() {
        UUID[] uuids = V4.Batch(Amount);
        this.Serialized = JsonSerializer.Serialize(uuids);
    }

    [Benchmark(Description = "UUIDs")]
    public UUID[] UUID() {
        return JsonSerializer.Deserialize<UUID[]>(this.Serialized);
    }

    [Benchmark(Description = "Guids", Baseline = true)]
    public Guid[] GUIDs() {
        return JsonSerializer.Deserialize<Guid[]>(this.Serialized);
    }
}