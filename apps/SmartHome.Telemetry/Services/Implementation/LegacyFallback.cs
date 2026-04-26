namespace SmartHome.Telemetry.Services.Implementation
{
    /// <summary>
    /// Реализация сервиса для получения телеметрии с монолита.
    /// </summary>
    /// <param name="client">Http клиент.</param>
    internal sealed class LegacyFallback(HttpClient client) : ILegacyFallback
    {
        /// <inheritdoc/>
        public async Task<LegacyResponse?> GetTelemetryAsync(int deviceId)
        {
            var url = @$"api/v1/sensors/{deviceId}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LegacyResponse>();
            }

            return null;
        }
    }
}
