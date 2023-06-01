# UUID.Net

[![.NET Unit test](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/dotnet-test.yml/badge.svg)](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/dotnet-test.yml)
[![📦 Nuget Release](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/publish.yml/badge.svg)](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/publish.yml)  
![Nuget Version](https://img.shields.io/nuget/v/DaanV2.UUID.Net)
![Nuget Downloads](https://img.shields.io/nuget/dt/DaanV2.UUID.Net)

A library that provides a way to handle, and generate UUIDs. Convert them to and from strings, GUIDs, and the like. 
The library is written to be fast and efficient when comparing, generating or other handling operations. But still, comply with the RFC 4122 standard.
As well as providing a way to generate UUIDs from different data, like a string, or a byte array. Or cutting up a byte array into UUIDs.

Also has support for JSON serialization.

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

//Chunk an byte array into UUIDs
Byte[] data = ...
var uuids = DaanV2.UUID.V4.Batch(data);
```

### Creating UUIDs
In case you want to provide your own data to generate a UUID, you can use the `DaanV2.UUID.UUID` class.
This will stamp the UUID with the provided data, and use the provided data to generate the UUID.

```csharp
using DaanV2.UUID;

Byte[] data = ...
var uuid = UUID.Create(Version.V4, Variant.V1, data)
```

## UUIDs Version

| Version | Variant | Description                                                      |
| ------- | ------- | ---------------------------------------------------------------- |
| 1       | 1       | A UUID generated from a timestamp and the macaddresss            |
| 3       | 1       | A UUID generated from a string using MD5 hashing bits, 122 bits  |
| 4       | 1       | A random generated UUID of 122 bits                              |
| 5       | 1       | A UUID generated from a string using SHA1 hashing bits, 122 bits |


## Benchmarks
See [Benchmark reports](./Benchmark/Reports/results/README.md)

