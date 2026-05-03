namespace SmartHome.Devices.Services.Legacy
{
    /// <summary>
    /// Функционал для взаимодействия с монолитом.
    /// </summary>
    internal interface ILegacyDevicesService
    {
        /// <summary>
        /// Получить все устройства.
        /// </summary>
        /// <returns>Набор устройств.</returns>
        Task<IEnumerable<LegacyDevice>> GetAllDevicesAsync();

        // TODO Добавить остальные методы
    }
}
