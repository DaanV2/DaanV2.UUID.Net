using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.Dictionary;

[SimpleJob(RunStrategy.Throughput, id: "Retrieve from dictionary", warmupCount: 10)]
public class RetrieveTest {
    private const Int32 _Amount = 10_000;

    public Dictionary<UUID, DictonaryTestClass> DictUUID { get; set; } = new(_Amount, null);
    public Dictionary<Guid, DictonaryTestClass> DictGUID { get; set; } = new(_Amount, null);
    public Dictionary<String, DictonaryTestClass> DictString { get; set; } = new(_Amount, null);

    public UUID[] UUIDs { get; set; } = Array.Empty<UUID>();
    public Guid[] Guids { get; set; } = Array.Empty<Guid>();
    public String[] Strings { get; set; } = Array.Empty<String>();


    [GlobalSetup]
    public void Setup() {
        UUID[] uuids = V4.Batch(_Amount);

        this.UUIDs = uuids;
        this.Guids = uuids.Select((u) => u.ToGuid()).ToArray();
        this.Strings = uuids.Select((u) => u.ToString()).ToArray();

        var data = new DictonaryTestClass() {
            Data1 = "Data1",
            Data2 = "Data2",
            Data3 = "Data3"
        };

        foreach (UUID U in this.UUIDs) {
            this.DictUUID[U] = data;
        }

        foreach (Guid G in this.Guids) {
            this.DictGUID[G] = data;
        }

        foreach (String S in this.Strings) {
            this.DictString[S] = data;
        }
    }

    [Benchmark(Description = "Guid")]
    public Int32 Guid() {
        Int32 Count = 0;

        foreach (Guid U in this.Guids) {
            DictonaryTestClass? Data = this.DictGUID[U];
            if (Data is not null) {
                Count++;
            }
        }

        return Count;
    }

    [Benchmark(Description = "UUID")]
    public Int32 UUID() {
        Int32 Count = 0;

        foreach (UUID U in this.UUIDs) {
            DictonaryTestClass? Data = this.DictUUID[U];
            if (Data is not null) {
                Count++;
            }
        }

        return Count;
    }

    [Benchmark(Description = "String UUID", Baseline = true)]
    public Int32 StringUUID() {
        Int32 Count = 0;

        foreach (String U in this.Strings) {
            DictonaryTestClass? Data = this.DictString[U];
            if (Data is not null) {
                Count++;
            }
        }

        return Count;
    }
}