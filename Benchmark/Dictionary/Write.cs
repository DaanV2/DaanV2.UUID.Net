using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.Dictionary;

[SimpleJob(RunStrategy.Throughput, id: "Write to dictionary")]
public partial class WriteTest {
    private const Int32 _Amount = 10_000;

    public UUID[] UUIDs { get; set; } = Array.Empty<UUID>();
    public Guid[] Guids { get; set; } = Array.Empty<Guid>();
    public String[] Strings { get; set; } = Array.Empty<String>();

    public DictonaryTestClass Item { get; set; } = new();

    [GlobalSetup]
    public void Setup() {
        UUID[] uuids = V5.Batch(_Amount);

        this.UUIDs = uuids;
        this.Guids = uuids.Select((u) => u.ToGuid()).ToArray();
        this.Strings = uuids.Select((u) => u.ToString()).ToArray();

        this.Item = new DictonaryTestClass() {
            Data1 = "Data1",
            Data2 = "Data2",
            Data3 = "Data3"
        };
    }

    [Benchmark(Description = "Guid")]
    public Dictionary<Guid, DictonaryTestClass> Guid() {
        var Dict = new Dictionary<Guid, DictonaryTestClass>(_Amount, null);

        for (Int32 I = 0; I < this.Guids.Length; I++) {
            Guid key = this.Guids[I];
            Dict[key] = this.Item;
        }

        return Dict;
    }

    [Benchmark(Description = "UUID")]
    public Dictionary<UUID, DictonaryTestClass> UUID() {
        var Dict = new Dictionary<UUID, DictonaryTestClass>(_Amount, null);

        for (Int32 I = 0; I < this.UUIDs.Length; I++) {
            UUID key = this.UUIDs[I];
            Dict[key] = this.Item;
        }

        return Dict;
    }

    [Benchmark(Description = "String UUID", Baseline = true)]
    public Dictionary<String, DictonaryTestClass> StringUUID() {
        var Dict = new Dictionary<String, DictonaryTestClass>(_Amount, null);

        for (Int32 I = 0; I < this.Strings.Length; I++) {
            String key = this.Strings[I];
            Dict[key] = this.Item;
        }

        return Dict;
    }
}