# DaanV2.UUID.Net

[![.NET Unit test](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/dotnet-test.yml/badge.svg)](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/dotnet-test.yml)
[![📦 Nuget Release](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/publish.yml/badge.svg)](https://github.com/DaanV2/DaanV2.UUID.Net/actions/workflows/publish.yml)  
![Nuget Version](https://img.shields.io/nuget/v/DaanV2.UUID.Net)
![Nuget Downloads](https://img.shields.io/nuget/dt/DaanV2.UUID.Net)

A library that provides a way to handle and generate UUIDs. Convert them to and from strings, GUIDs, and the like. 
The library is written to be fast and efficient when comparing, generating, or handling operations. Provides ways to generate UUIDs from different data, like a string, a byte array, or cutting up a byte array into UUIDs.
Complies with the RFC 4122 / RFC 9562 standard. And has version 1-8 UUIDs implemented.

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

## Supported Version

| Version | Variant | Description                                                                                                         |
| ------- | ------- | ------------------------------------------------------------------------------------------------------------------- |
| 1       | 1       | A UUID generated from a timestamp and the mac address                                                               |
| 3       | 1       | A UUID generated from a string using MD5 hashing bits, 122 bits                                                     |
| 4       | 1       | A randomly generated UUID of 122 bits                                                                               |
| 5       | 1       | A UUID generated from a string using SHA1 hashing bits, 122 bits                                                    |
| 6       | 1       | A UUID that is reordered Gregorian time-based UUID specified in this document. Its an upgrade from V1 for databases |
| 7       | 1       | A UUID version that exposes Unix Epoch time-based UUID specified in this document. Same like V1, V6 but on UTC      |
| 8       | 1       | A UUID version that allows for custom data of 122 bits of data                                                      |

## Benchmarks
See [Benchmark reports](./Benchmark/Reports/results/README.md)

