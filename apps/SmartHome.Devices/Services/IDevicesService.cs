using SmartHome.Devices.Model;

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
        Task<IEnumerable<Device>> GetDevicesAsync(long houseId);

        /// <summary>
        /// Получить устройство по его идентификатору.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Устройство или null, если не найдено.</returns>
        Task<Device?> GetDeviceByIdAsync(long deviceId);

        /// <summary>
        /// Создать новое устройство и вернуть его идентификатор.
        /// </summary>
        /// <param name="device">Устройство для создания.</param>
        /// <returns>Идентификатор созданного устройства.</returns>
        Task<long> CreateDeviceAsync(Device device);

        /// <summary>
        /// Обновить информацию об устройстве.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <param name="device">Устройство.</param>
        /// <returns>Обновленная структура или null, если устройство не найдено.</returns>
        Task<Device?> UpdateDeviceAsync(long deviceId, Device device);

        /// <summary>
        /// Удалить устройство по его идентификатору.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>True, если устройство успешно удалено, иначе false.</returns>
        Task<bool> DeleteDeviceAsync(long deviceId);
    }
}
