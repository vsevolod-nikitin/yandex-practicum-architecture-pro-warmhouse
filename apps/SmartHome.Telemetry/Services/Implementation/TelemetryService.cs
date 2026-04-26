using Microsoft.EntityFrameworkCore;
using SmartHome.Telemetry.Model;
using SmartHome.Telemetry.Repositories;

namespace SmartHome.Telemetry.Services.Implementation
{
    public sealed class TelemetryService(TelemetryContext context) : ITelemetryService
    {
        public async Task<IEnumerable<TelemetryData>?> GetTelemetryDataAsync(int deviceId, DateTime? from, DateTime? to)
        {
            var result = context.TelemetryData.Where(t => t.DeviceId == deviceId);

            if (from.HasValue)
            {
                result = result.Where(t => t.Timestamp >= from.Value);
            }

            if (to.HasValue)
            {
                result = result.Where(t => t.Timestamp <= to.Value);
            }

            return await result.OrderBy(t => t.Timestamp).AsNoTracking().ToArrayAsync();
        }
    }
}
