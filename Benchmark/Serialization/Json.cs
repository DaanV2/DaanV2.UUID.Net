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

    [Benchmark(Description = "Serializing UUIDs")]
    public String UUID() {
        return JsonSerializer.Serialize(this.UUIDs);
    }

    [Benchmark(Description = "Serializing Guids", Baseline = true)]
    public String GUIDs() {
        return JsonSerializer.Serialize(this.Guids);
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

    [Benchmark(Description = "Deserializing UUIDs")]
    public UUID[] UUID() {
        return JsonSerializer.Deserialize<UUID[]>(this.Serialized);
    }

    [Benchmark(Description = "Deserializing Guids", Baseline = true)]
    public Guid[] GUIDs() {
        return JsonSerializer.Deserialize<Guid[]>(this.Serialized);
    }
}