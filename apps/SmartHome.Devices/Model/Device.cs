namespace SmartHome.Devices.Model
{
    public sealed class Device
    {
        public long Id { get; set; }
        public long HouseId { get; set; }
        public long TypeId { get; set; }
        public required string SerialId { get; set; }
        public string? Name { get; set; }

        public DeviceType Type { get; set; } = null!;
    }
}
