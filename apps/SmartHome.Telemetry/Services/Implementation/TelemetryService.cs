using Microsoft.EntityFrameworkCore;
using SmartHome.Telemetry.Model;
using SmartHome.Telemetry.Repositories;
using SmartHome.Telemetry.Services.Legacy;
using System.Text.Json;

namespace SmartHome.Telemetry.Services.Implementation
{
    /// <summary>
    /// Реализация сервиса для получения телеметрических данных устройств.
    /// </summary>
    /// <param name="context">Контекст данных телеметрии устройств.</param>
    /// <param name="legacyTelemetry">Функционал для взаимодействия с монолитом.</param>
    internal sealed class TelemetryService(
        TelemetryContext context,
        ILegacyTelemetryService legacyTelemetry) : ITelemetryService
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<TelemetryData>?> GetTelemetryDataAsync(int deviceId, DateTime? from, DateTime? to)
        {
            var query = context.TelemetryData.Where(t => t.DeviceId == deviceId);

            if (from.HasValue)
            {
                query = query.Where(t => t.Timestamp >= from.Value);
            }

            if (to.HasValue)
            {
                query = query.Where(t => t.Timestamp <= to.Value);
            }

            var result = await query.OrderBy(t => t.Timestamp).AsNoTracking().ToArrayAsync();
            if (result.Length > 0)
            {
                return result;
            }

            // Если данных нет, пробуем получить их с монолита
            var legacyData = await legacyTelemetry.GetTelemetryAsync(deviceId);
            if (legacyData is not null)
            {
                // Преобразовываем старый формат
                var data = new
                {
                    value = legacyData.Value,
                    unit = legacyData.Unit,
                    status = legacyData.Status,
                };

                var telemetryData = new TelemetryData
                {
                    DeviceId = deviceId,
                    Timestamp = legacyData.LastUpdated,
                    Data = JsonSerializer.Serialize(data)
                };

                return [telemetryData];
            }

            return null;
        }
    }
}
