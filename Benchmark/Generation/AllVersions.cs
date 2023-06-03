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

    [Benchmark(Description = "V3")]
    public UUID V3() {
        return DaanV2.UUID.V3.Generate();
    }

    [Benchmark(Description = "V4")]
    public UUID V4() {
        return DaanV2.UUID.V4.Generate();
    }

    [Benchmark(Description = "V5")]
    public UUID V5() {
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
    private Int32 _Amount;
    private String _Data = String.Empty;

    [Params(10, 100, 500, 1000, 2500, 5000, 10_000, 100_000)]
    public Int32 Amount {
        get => this._Amount;
        set {
            this._Amount = value;
            this._Data = Utility.HexString(this._Amount);
        }
    }

    public String Data => this._Data;

    [Benchmark(Description = "V1")]
    public UUID[] V1() {
        return DaanV2.UUID.V1.Batch(this.Amount);
    }

    [Benchmark(Description = "V3")]
    public UUID[] V3() {
        return DaanV2.UUID.V3.Batch(this.Amount, this._Data);
    }

    [Benchmark(Description = "V4")]
    public UUID[] V4() {
        return DaanV2.UUID.V4.Batch(this.Amount);
    }

    [Benchmark(Description = "V5")]
    public UUID[] V5() {
        return DaanV2.UUID.V5.Batch(this.Amount, this._Data);
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