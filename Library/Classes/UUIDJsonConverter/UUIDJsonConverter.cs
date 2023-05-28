using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DaanV2.UUID;

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
        Span<Byte> characters = stackalloc Byte[64];
        Span<Byte> receiver = characters[..Format.UUID_STRING_LENGTH];
        Format.IntoSpan(value._Data, receiver);

        writer.WriteStringValue(receiver);
    }
}
