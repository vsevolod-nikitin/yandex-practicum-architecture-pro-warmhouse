using SmartHome.Telemetry.Model;

namespace SmartHome.Telemetry.Services
{
    public interface ITelemetryService
    {
        Task<IEnumerable<TelemetryData>> GetTelemetryDataAsync(int deviceId, DateTime? from, DateTime? to);
    }
}
