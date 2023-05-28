using Benchmark;
using Benchmark.Generation;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using DaanV2.UUID;

public partial class Program {
    private static void Main(String[] args) {
        String reportFolder = Utility.FindFolder(Environment.CurrentDirectory, "Reports") ?? throw new DirectoryNotFoundException("Could not find the report folder");
        ManualConfig config = DefaultConfig.Instance.WithArtifactsPath(reportFolder);

        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}

//Console.ReadLine();
//Console.WriteLine("Start");
//var Test = new AllVersions();
//var uuids = new UUID[50_000_000];

//for (Int32 i = 0; i < uuids.Length; i++) {
//    uuids[i] = Test.V1();
//}
//Console.WriteLine("Done");