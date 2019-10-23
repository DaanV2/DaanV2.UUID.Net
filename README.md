# UUID.Net

Provides a base class that can handle UUIDs as an object but also the generators to generate any version.

## Usage Example

Below are two examples of generating UUIDs and usage

### Implicit Casting

This API contains pre-made casting methods that convert UUID to strings, char arrays or vice versa.

### Generating UUIDs

#### Generate a UUID

```csharp
UUID Temp = UUIDFactory.CreateUUID(4, 1); //Version 4, Variant 1
String UUID = UUIDFactory.CreateUUID(4, 2); //Version 4, Variant 2. auto cast to string
```

#### Generate a batch of UUIDs

```csharp
UUID[] UUIDs = UUIDFactory.CreateUUIDs(100000, 4, 1); //Version 4, Variant 1
```

#### Generating through a Generator

```csharp
IUUIDGenerator Generator = UUIDFactory.CreateGenerator(4, 1); //Get the version 4, variant 1 generator
Generator = new DaanV2.UUID.Generators.Version4.GeneratorVariant1(); //Get the version 4, variant 1 generator

UUID Out = Generator.Generate();
```

## UUIDs Version

|Version    |Variant    |Description    |
|-----------|-----------|---------------|
|4  |1  |A random generated UUID of 122 bits    |
|4  |2  |A random generated UUID of 121 bits    |
