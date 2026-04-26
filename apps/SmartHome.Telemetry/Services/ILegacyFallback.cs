namespace SmartHome.Telemetry.Services
{
    /// <summary>
    /// Сервис для получения телеметрии с монолита.
    /// </summary>
    internal interface ILegacyFallback
    {
        /// <summary>
        /// Получает данные телеметрии с монолита для указанного устройства.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Данные телеметрии или null, если данные недоступны.</returns>
        Task<LegacyResponse?> GetTelemetryAsync(int deviceId);
    }
}
