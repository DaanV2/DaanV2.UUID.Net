using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.Mechanics;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Version comparing", invocationCount: 10_000)]
public partial class VectorComparing {
    [Params(100, 1000, 2000, 5000, 10_000)]
    public Int32 Amount { get; set; }

    public Guid[] Guids { get; set; } = Array.Empty<Guid>();
    public UUID[] UUIDs { get; set; } = Array.Empty<UUID>();
    public Vector128<Byte>[] ByteVectors { get; set; } = Array.Empty<Vector128<Byte>>();
    public Vector128<UInt64>[] UInt64Vectors { get; set; } = Array.Empty<Vector128<UInt64>>();

    [IterationSetup]
    public void Setup() {
        var random = new Random();
        this.Guids = new Guid[this.Amount];
        this.UUIDs = new UUID[this.Amount];
        this.ByteVectors = new Vector128<Byte>[this.Amount];
        this.UInt64Vectors = new Vector128<UInt64>[this.Amount];

        for (Int32 i = 0; i < this.Amount; i++) {
            Byte[] data = new Byte[16];
            random.NextBytes(data);

            var item = Vector128.Create<Byte>(data);
            this.ByteVectors[i] = item;
            this.UInt64Vectors[i] = item.AsUInt64();
            this.Guids[i] = new Guid(data);
            this.UUIDs[i] = new UUID(data);
        }
    }

    [Benchmark(Baseline = true, Description = "Guid")]
    public Int32 GuidsTests() {
        Int32 count = 0;
        Guid item = this.Guids[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item.Equals(this.Guids[i])) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "UUID Equals")]
    public Int32 UUIDsEqualTests() {
        Int32 count = 0;
        UUID item = this.UUIDs[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item.Equals(this.UUIDs[i])) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "UUID ==")]
    public Int32 UUIDsOp() {
        Int32 count = 0;
        UUID item = this.UUIDs[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item == this.UUIDs[i]) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "Vector128 Equals")]
    public Int32 Vector128Equals() {
        Int32 count = 0;
        Vector128<Byte> item = this.ByteVectors[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (Vector128.EqualsAll(item, this.ByteVectors[i])) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "Byte Equals")]
    public Int32 Vector128ByteEquals() {
        Int32 count = 0;
        Vector128<Byte> item = this.ByteVectors[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item.Equals(this.ByteVectors[i])) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "Byte ==")]
    public Int32 Vector128ByteOp() {
        Int32 count = 0;
        Vector128<Byte> item = this.ByteVectors[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item == this.ByteVectors[i]) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "Byte -> UInt64 Equals")]
    public Int32 Vector128ByteToUInt64() {
        Int32 count = 0;
        Vector128<Byte> item = this.ByteVectors[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item.AsUInt64().Equals(this.ByteVectors[i].AsUInt64())) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "UInt64 Equals")]
    public Int32 Vector128UInt64Equals() {
        Int32 count = 0;
        Vector128<UInt64> item = this.UInt64Vectors[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item.Equals(this.UInt64Vectors[i])) {
                count++;
            }
        }

        return count;
    }

    [Benchmark(Description = "UInt64 ==")]
    public Int32 Vector128UInt64Op() {
        Int32 count = 0;
        Vector128<UInt64> item = this.UInt64Vectors[0];

        for (Int32 i = 0; i < this.Amount; i++) {
            if (item == this.UInt64Vectors[i]) {
                count++;
            }
        }

        return count;
    }
}
