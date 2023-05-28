// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Its part of the benchmark", Scope = "member", Target = "~M:Benchmark.Generation.AllVersions.Guid~System.Guid")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Its part of the benchmark", Scope = "member", Target = "~M:Benchmark.Generation.AllVersions.V1~DaanV2.UUID.UUID")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Its part of the benchmark", Scope = "member", Target = "~M:Benchmark.Generation.AllVersions.V4~DaanV2.UUID.UUID")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Its part of the benchmark", Scope = "member", Target = "~M:Benchmark.Generation.GenerationV4.GUIDs~System.Guid")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Its part of the benchmark", Scope = "member", Target = "~M:Benchmark.Generation.GenerationV4.UUID~DaanV2.UUID.UUID")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Its part of the benchmark", Scope = "member", Target = "~M:Benchmark.Generation.StringGenerationV4.GUIDs~System.String")]
[assembly: SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "Its part of the benchmark", Scope = "member", Target = "~F:Benchmark.Mechanics.VersionMask.versionMask")]
