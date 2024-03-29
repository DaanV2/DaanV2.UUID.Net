﻿using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DaanV2.UUID;

/// <summary>The class that converts <see cref="UUID"/> to and from json data</summary>
public partial class UUIDJsonConverter : JsonConverter<UUID> {
    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public override UUID Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        ReadOnlySpan<Byte> data = reader.ValueSpan;

        if (data != null && data.Length == Format.UUID_STRING_LENGTH) {
            Vector128<Byte> d = Format.Parse(data);
            return new UUID(d);
        }

        throw new JsonException("Unknown UUID format");
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public override void Write(Utf8JsonWriter writer, UUID value, JsonSerializerOptions options) {
        //Converting first to string is faster, but the validation on the string is slower
        //So we convert to guid, which skips that
        var guid = value.ToGuid();
        writer.WriteStringValue(guid);
    }
}
