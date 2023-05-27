using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DaanV2.UUID;
using Version = DaanV2.UUID.Version;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, id: "Version masking, as vector or just bytes?", iterationCount: 50, invocationCount: 5000000)]
public partial class VersionMask {
    [IterationSetup]
    public void Setup() {
        this.Data = new Byte[16];
        Array.Fill(this.Data, (Byte)0xff);

        this.Ver = Version.V4;
        this.Var = Variant.V1;
    }

    public static Vector128<Byte> versionMask = Format.VersionVariantMaskNot(Version.V4, Variant.V1);
    public static Vector128<Byte> versionOverlay = Format.VersionVariantOverlayer(Version.V4, Variant.V1);

    public required Byte[] Data { get; set; }
    public Version Ver { get; set; }
    public Variant Var { get; set; }


    [Benchmark(Description = "Using Vector128 and constants values")]
    public UUID Vector128Const() {
        const Version version = Version.V4;
        const Variant variant = Variant.V1;

        Vector128<Byte> mask = Format.VersionVariantMaskNot(version, variant);
        Vector128<Byte> overlay = Format.VersionVariantOverlayer(version, variant);

        var data = Vector128.Create(this.Data);
        Vector128<Byte> result = Format.StampVersion(mask, overlay, data);
        return new UUID(result);
    }

    [Benchmark(Description = "Using Vector128 and using dynamic values")]
    public UUID Vector128Dyn() {
        Version version = this.Ver;
        Variant variant = this.Var;

        Vector128<Byte> mask = Format.VersionVariantMaskNot(version, variant);
        Vector128<Byte> overlay = Format.VersionVariantOverlayer(version, variant);

        var data = Vector128.Create(this.Data);
        Vector128<Byte> result = Format.StampVersion(mask, overlay, data);
        return new UUID(result);
    }

    [Benchmark(Description = "Using Vector128 and using static masks & overlay")]
    public UUID Vector128Static() {
        var data = Vector128.Create(this.Data);
        Vector128<Byte> result = Format.StampVersion(versionMask, versionOverlay, data);
        return new UUID(result);
    }

    [Benchmark(Description = "Using bytes and constant values", Baseline =true)]
    public UUID Bytes() {
        Span<Byte> data = this.Data.AsSpan();

        UInt32 maskVer = Version.V4.GetMask();
        Byte b = data[Format.VERSION_BYTE_INDEX];
        b = (Byte)((b & maskVer) | (UInt32)Version.V4);
        data[Format.VERSION_BYTE_INDEX] = b;

        UInt32 maskVar = Variant.V1.GetMask();
        b = data[Format.VARIANT_BYTE_INDEX];
        b = (Byte)((b & maskVar) | (UInt32)Variant.V1);
        data[Format.VARIANT_BYTE_INDEX] = b;

        return new UUID(data);
    }
}
