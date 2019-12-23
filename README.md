# UUID.Net

Provides a base class that can handle UUIDs as an object but also provides the generators to generate version 3, 4 and 5.

**Table of Contents**
- [UUID.Net](#uuidnet)
    - [Implicit Casting](#implicit-casting)
  - [Usage Example](#usage-example)
    - [Generating UUIDs](#generating-uuids)
      - [Generate a UUID](#generate-a-uuid)
      - [Generate a batch of UUIDs](#generate-a-batch-of-uuids)
      - [Generating through a Generator](#generating-through-a-generator)
  - [UUIDs Version](#uuids-version)

### Implicit Casting

This API contains pre-made casting methods that convert UUID to strings, char arrays or vice versa.

## Usage Example

Below are two examples of generating UUIDs and usage

### Generating UUIDs

#### Generate a UUID

```csharp
UUID Temp = UUIDFactory.CreateUUID(4, 2); //Version 4, Variant 2
String UUID = UUIDFactory.CreateUUID(3, 1); //Version 3, Variant 1. auto cast to string
```

#### Generate a batch of UUIDs

```csharp
UUID[] UUIDs = UUIDFactory.CreateUUIDs(100000, 4, 1); //Version 4, Variant 1, Amount of 100000
```

#### Generating through a Generator

```csharp
IUUIDGenerator Generator = UUIDFactory.CreateGenerator(4, 1); //Get the version 4, variant 1 generator
IUUIDGenerator<Int32> GeneratorV4 = new DaanV2.UUID.Generators.Version4.GeneratorVariant1(); //Get the version 4, variant 1 generator

UUID Out = GeneratorV4.Generate();
```

## UUIDs Version

|Version    |Variant    |Description    |Context Needed |Context Type   |
|-----------|-----------|---------------|---------------|---------------|
|3 |1 |A UUID generated from a string using MD5 hashing bits, 122 bits |Yes |String |
|4 |1 |A random generated UUID of 122 bits |No |Int32 |
|4 |2 |A random generated UUID of 121 bits |No |Int32 |
|5 |1 |A UUID generated from a string using SHA1 hashing bits, 122 bits |Yes |String |
