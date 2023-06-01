using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;

namespace Benchmark.Mechanics;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Hashing Sha1")]
public partial class Hashing {

    [GlobalSetup]
    public void Setup() {
        this.Data = new Byte[SHA1.HashSizeInBytes * 8];
        Random.Shared.NextBytes(this.Data);
    }

    public Byte[] Data { get; set; } = Array.Empty<Byte>();

    [Benchmark(Description = "Sha1")]
    public Vector128<Byte> Sha1() {
        ReadOnlySpan<Byte> source = this.Data.AsSpan();
        Span<Byte> hash = stackalloc Byte[SHA1.HashSizeInBytes];
        _ = SHA1.HashData(source, hash);

        return Vector128.Create<Byte>(hash);
    }

    [Benchmark(Description = "TrySha1")]
    public Vector128<Byte> TrySha1() {
        ReadOnlySpan<Byte> source = this.Data.AsSpan();
        Span<Byte> hash = stackalloc Byte[SHA1.HashSizeInBytes];
        _ = SHA1.TryHashData(source, hash, out Int32 _);

        return Vector128.Create<Byte>(hash);
    }

    [Benchmark(Description = "Sha1 Instance")]
    public Vector128<Byte> Sha1Instance() {
        var hasher = SHA1.Create();
        ReadOnlySpan<Byte> source = this.Data.AsSpan();
        Span<Byte> hash = stackalloc Byte[SHA1.HashSizeInBytes];
        _ = hasher.TryComputeHash(source, hash, out Int32 _);

        return Vector128.Create<Byte>(hash);
    }

    static public readonly SHA1 GlobalHasher = SHA1.Create();

    [Benchmark(Description = "Sha1 Global")]
    public Vector128<Byte> Sha1Global() {
        ReadOnlySpan<Byte> source = this.Data.AsSpan();
        Span<Byte> hash = stackalloc Byte[SHA1.HashSizeInBytes];
        _ = GlobalHasher.TryComputeHash(source, hash, out Int32 _);

        return Vector128.Create<Byte>(hash);
    }
}
