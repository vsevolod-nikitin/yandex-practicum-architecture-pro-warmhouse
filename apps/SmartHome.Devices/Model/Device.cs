using System.Text.Json.Serialization;

namespace SmartHome.Devices.Model
{
    public sealed class Device
    {
        public long Id { get; set; }
        public long HouseId { get; set; }
        public long TypeId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        [JsonIgnore]
        public DeviceType Type { get; set; } = null!;
    }
}
