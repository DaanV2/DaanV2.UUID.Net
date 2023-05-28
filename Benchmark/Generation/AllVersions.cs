using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.Generation;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Generating all versions")]
public partial class AllVersions {
    [Benchmark(Description = "V1")]
    public UUID V1() {
        return DaanV2.UUID.V1.Generate();
    }

    [Benchmark(Description = "V4")]
    public UUID V4() {
        return DaanV2.UUID.V5.Generate();
    }

    [Benchmark(Baseline = true, Description = "GUID")]
    public Guid Guid() {
        return System.Guid.NewGuid();
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.ColdStart, id: "Generating in batch all versions")]
public partial class BatchAllVersions {
    [Params(10, 100, 500, 1000, 2500, 5000, 10_000, 100_000)]
    public Int32 Amount { get; set; }

    [Benchmark(Description = "V1")]
    public UUID[] V1() {
        return DaanV2.UUID.V1.GenerateBatch(this.Amount);
    }

    [Benchmark(Description = "V4")]
    public UUID[] V4() {
        return DaanV2.UUID.V5.GenerateBatch(this.Amount);
    }

    [Benchmark(Baseline = true, Description = "GUID")]
    public Guid[] Guid() {
        var guids = new Guid[this.Amount];

        for (Int32 i = 0; i < this.Amount; i++) {
            guids[i] = System.Guid.NewGuid();
        }

        return guids;
    }
}