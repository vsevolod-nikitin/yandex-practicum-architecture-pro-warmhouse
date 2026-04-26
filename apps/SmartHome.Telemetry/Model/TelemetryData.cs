namespace SmartHome.Telemetry.Model
{
    public sealed class TelemetryData
    {
        public long Id { get; set; }
        public int DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Data { get; set; }
    }
}
