using System.Runtime.CompilerServices;
using DaanV2.UUID;

namespace Tests;
public sealed partial class UUIDtests {
    [Fact(DisplayName = "Check if compile time is all correct")]
    public void CompileChecks() {
        Int32 Size = Unsafe.SizeOf<UUID>();
        Assert.Equal(16, Size);
    }
}