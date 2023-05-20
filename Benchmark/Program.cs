using Benchmark;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

public partial class Program {
    private static void Main(String[] args) {
        String reportFolder = Utillity.FindFolder(Environment.CurrentDirectory, "Reports") ?? throw new DirectoryNotFoundException("Could not find the report folder");
        ManualConfig config = DefaultConfig.Instance.WithArtifactsPath(reportFolder);

        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}

