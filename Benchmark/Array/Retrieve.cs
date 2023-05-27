using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark;

[SimpleJob(RunStrategy.Throughput, id: "Retrieving from Array", warmupCount: 10)]
public class RetrieveTest {

    [Params(10, 100, 1000, 2000, 5000)]
    public Int32 Amount { get; set; }

    public UUID[] UUIDs { get; set; } = Array.Empty<UUID>();
    public UUID[] UUIDs2 { get; set; } = Array.Empty<UUID>();
    public Guid[] Guids { get; set; } = Array.Empty<Guid>();
    public Guid[] Guids2 { get; set; } = Array.Empty<Guid>();
    public String[] Strings { get; set; } = Array.Empty<String>();
    public String[] Strings2 { get; set; } = Array.Empty<String>();

    [IterationSetup]
    public void Setup() {
        UUID[] uuids = V4.GenerateBatch(this.Amount);
        this.UUIDs = uuids;
        this.Guids = uuids.Select((u) => u.ToGuid()).ToArray();
        this.Strings = uuids.Select((u) => u.ToString()).ToArray();
        var R = new Random(987654321);

        this.UUIDs2 = this.UUIDs.OrderBy((u) => R.Next()).ToArray();
        this.Guids2 = uuids.Select((u) => u.ToGuid()).ToArray();
        this.Strings2 = uuids.Select((u) => u.ToString()).ToArray();
    }

    [Benchmark(Description = "Guid")]
    public Int32 Guid() {
        Int32 Count = 0;

        Guid[] guids = this.Guids;
        Guid[] indata = this.Guids2;
        foreach (Guid U in guids) {
            Int32 index = Array.IndexOf(indata, U);
            if (index >= 0) {
                Count++;
            }
        }

        return Count;
    }

    [Benchmark(Description = "UUID")]
    public Int32 UUID() {
        Int32 Count = 0;

        UUID[] uuids = this.UUIDs;
        UUID[] indata = this.UUIDs2;
        foreach (UUID U in uuids) {
            Int32 index = Array.IndexOf(indata, U);
            if (index >= 0) {
                Count++;
            }
        }

        return Count;
    }

    [Benchmark(Description = "String UUID", Baseline = true)]
    public Int32 StringUUID() {
        Int32 Count = 0;

        String[] uuids = this.Strings;
        String[] indata = this.Strings2;
        foreach (String U in uuids) {
            Int32 index = Array.IndexOf(indata, U);
            if (index >= 0) {
                Count++;
            }
        }

        return Count;
    }
}