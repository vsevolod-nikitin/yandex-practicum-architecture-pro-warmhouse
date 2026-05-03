namespace SmartHome.Telemetry.Services.Legacy
{
    /// <summary>
    /// Сервис для получения телеметрии с монолита.
    /// </summary>
    internal interface ILegacyTelemetryService
    {
        /// <summary>
        /// Получает данные телеметрии с монолита для указанного устройства.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Данные телеметрии или null, если данные недоступны.</returns>
        Task<LegacyTelemetryData?> GetTelemetryAsync(int deviceId);
    }
}
