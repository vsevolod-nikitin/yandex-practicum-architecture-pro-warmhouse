namespace SmartHome.Devices.Services
{
    /// <summary>
    /// Сервис для работы с устройствами.
    /// </summary>
    public interface IDevicesService
    {
        /// <summary>
        /// Получить устройства по идентификатору дома.
        /// </summary>
        /// <param name="houseId">Идентификатор дома.</param>
        /// <returns>Список устройств.</returns>
        Task<IEnumerable<DeviceDto>> GetDevicesAsync(long houseId);

        /// <summary>
        /// Получить устройство по его идентификатору.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Устройство или null, если не найдено.</returns>
        Task<DeviceDto?> GetDeviceByIdAsync(long deviceId);

        /// <summary>
        /// Создать новое устройство и вернуть его идентификатор.
        /// </summary>
        /// <param name="device">Устройство для создания.</param>
        /// <returns>Идентификатор созданного устройства.</returns>
        /// <exception cref="InvalidOperationException">Ошибка при создании устройства.</exception>
        Task<long> CreateDeviceAsync(DeviceDto device);

        /// <summary>
        /// Обновить информацию об устройстве.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <param name="device">Устройство.</param>
        /// <returns>Обновленное устройство или null, если устройство не найдено.</returns>
        /// <exception cref="InvalidOperationException">Ошибка при обновлении устройства.</exception>
        Task<DeviceDto?> UpdateDeviceAsync(long deviceId, DeviceDto device);

        /// <summary>
        /// Удалить устройство по его идентификатору.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>True, если устройство успешно удалено, иначе false.</returns>
        Task<bool> DeleteDeviceAsync(long deviceId);
    }
}
