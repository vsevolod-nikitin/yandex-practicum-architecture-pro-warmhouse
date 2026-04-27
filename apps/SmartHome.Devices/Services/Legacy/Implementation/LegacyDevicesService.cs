namespace SmartHome.Devices.Services.Legacy.Implementation
{
    /// <summary>
    /// Реализация функционала для взаимодействия с монолитом.
    /// </summary>
    /// <param name="client">Http клиент.</param>
    internal sealed class LegacyDevicesService(HttpClient client) : ILegacyDevicesService
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<LegacyDevice>> GetAllDevicesAsync()
        {
            var url = @$"api/v1/sensors";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LegacyDevice[]>() ?? [];
            }

            return [];
        }
    }
}
