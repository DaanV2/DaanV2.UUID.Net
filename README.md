# UUID.Net

[![.NET Unit test](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/dotnet-test.yml/badge.svg)](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/dotnet-test.yml)
[![📦 Nuget Release](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/publish.yml/badge.svg)](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/publish.yml)

A library that provides a way to handle, and generate UUIDs. Convert them to and from strings, GUIDs, and the like. 
The library is written to be fast and efficient when comparing, generating or other handling operations. But still, comply with the RFC 4122 standard.

Also has support for JSON serialization and deserialization.

**Table of Contents**
- [UUID.Net](#uuidnet)
  - [UUIDs Version](#uuids-version)
  - [Benchmarks](#benchmarks)
  - [Usage Example](#usage-example)
    - [Generating UUIDs](#generating-uuids)

## UUIDs Version

| Version | Variant | Description                                                      |
| ------- | ------- | ---------------------------------------------------------------- |
| 1       | 1       | A UUID generated from a timestamp and the macaddresss            |
| 3       | 1       | A UUID generated from a string using MD5 hashing bits, 122 bits  |
| 4       | 1       | A random generated UUID of 122 bits                              |
| 5       | 1       | A UUID generated from a string using SHA1 hashing bits, 122 bits |


## Benchmarks
See [Benchmark reports](./Benchmark/Reports/results/README.md)

## Usage Example
Below are two examples of generating UUIDs and usage

### Generating UUIDs
Most versions of UUIDs can be generated using the static methods in the `DaanV2.UUID.V4` or other respective classes.
Since most of the UUIDs are generated from different data, different overloads are available.

```csharp
//Single UUID
var uuid = DaanV2.UUID.V4.Generate();
uuid = DaanV2.UUID.V1.Generate();

//Batch of UUIDs
var uuids = DaanV2.UUID.V4.Batch(1000);
```
