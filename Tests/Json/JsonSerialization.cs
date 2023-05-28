using System.Text.Json;
using DaanV2.UUID;

namespace Tests.Json;
public sealed partial class JsonSerializationTest {
    public class TestClass {
        public UUID ID { get; set; }
    }

    [Fact(DisplayName = "Can json serializer")]
    public void JsonSerialization() {
        UUID uuid = Utility.PinnedUUIDData();
        String jsonString = JsonSerializer.Serialize(uuid);

        Assert.Contains(Utility.PinnedUUID, jsonString);

        var data = new TestClass {
            ID = uuid
        };

        jsonString = JsonSerializer.Serialize(data);

        Assert.Contains(Utility.PinnedUUID, jsonString);
    }

    [Fact(DisplayName = "Can json serialize and deserialize")]
    public void JsonSerializationAndDeserialization() {
        UUID uuid = Utility.PinnedUUIDData();
        var data = new TestClass {
            ID = uuid
        };
        String jsonString = JsonSerializer.Serialize(data);
        Assert.Contains(Utility.PinnedUUID, jsonString);

        TestClass? data2 = JsonSerializer.Deserialize<TestClass>(jsonString);

        Assert.Equal(data.ID, data2?.ID);
    }

}
