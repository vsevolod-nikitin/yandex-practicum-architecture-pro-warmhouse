namespace SmartHome.Telemetry.Services.Legacy.Implementation
{
    /// <summary>
    /// Реализация сервиса для получения телеметрии с монолита.
    /// </summary>
    /// <param name="client">Http клиент.</param>
    internal sealed class LegacyTelemetryService(HttpClient client) : ILegacyTelemetryService
    {
        /// <inheritdoc/>
        public async Task<LegacyTelemetryData?> GetTelemetryAsync(int deviceId)
        {
            var url = @$"api/v1/sensors/{deviceId}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LegacyTelemetryData>();
            }

            return null;
        }
    }
}
