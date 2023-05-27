using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.List;

[SimpleJob(RunStrategy.Throughput, id: "Retrieving from List")]
public class RetrieveTest {

    [Params(10, 100, 1000, 2000, 5000)]
    public Int32 Amount { get; set; }

    public List<UUID> UUIDs { get; set; } = new();
    public List<UUID> UUIDs2 { get; set; } = new();
    public List<Guid> Guids { get; set; } = new();
    public List<Guid> Guids2 { get; set; } = new();
    public List<String> Strings { get; set; } = new();
    public List<String> Strings2 { get; set; } = new();

    [IterationSetup]
    public void Setup() {
        UUID[] uuids = V4.GenerateBatch(this.Amount);
        this.UUIDs = uuids.ToList();
        this.Guids = uuids.Select((u) => u.ToGuid()).ToList();
        this.Strings = uuids.Select((u) => u.ToString()).ToList();
        var R = new Random(987654321);

        this.UUIDs2 = this.UUIDs.OrderBy((u) => R.Next()).ToList();
        this.Guids2 = uuids.Select((u) => u.ToGuid()).ToList();
        this.Strings2 = uuids.Select((u) => u.ToString()).ToList();
    }

    [Benchmark(Description = "GUID")]
    public Int32 Guid() {
        Int32 Count = 0;

        List<Guid> guids = this.Guids;
        List<Guid> indata = this.Guids2;
        foreach (Guid U in guids) {
            Int32 index = indata.IndexOf(U);
            if (index >= 0) {
                Count++;
            }
        }

        return Count;
    }

    [Benchmark(Description = "UUID")]
    public Int32 UUID() {
        Int32 Count = 0;

        List<UUID> uuids = this.UUIDs;
        List<UUID> indata = this.UUIDs2;
        foreach (UUID U in uuids) {
            Int32 index = indata.IndexOf(U);
            if (index >= 0) {
                Count++;
            }
        }

        return Count;
    }

    [Benchmark(Description = "UUID", Baseline = true)]
    public Int32 StringUUID() {
        Int32 Count = 0;

        List<String> uuids = this.Strings;
        List<String> indata = this.Strings2;
        foreach (String U in uuids) {
            Int32 index = indata.IndexOf(U);
            if (index >= 0) {
                Count++;
            }
        }

        return Count;
    }
}
