using SmartHome.Telemetry.Model;

namespace SmartHome.Telemetry.Services
{
    /// <summary>
    /// Сервис для получения телеметрических данных устройств.
    /// </summary>
    public interface ITelemetryService
    {
        /// <summary>
        /// Получить телеметрические данные для указанного устройства за заданный период времени.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <param name="from">Начальная дата и время периода.</param>
        /// <param name="to">Конечная дата и время периода.</param>
        /// <returns>Коллекция телеметрических данных.</returns>
        Task<IEnumerable<TelemetryData>?> GetTelemetryDataAsync(int deviceId, DateTime? from, DateTime? to);
    }
}
