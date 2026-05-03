using SmartHome.Devices.Model;

namespace SmartHome.Devices.Services
{
    /// <summary>
    /// Сервис для работы с типами устройств в рамках умного дома.
    /// </summary>
    public interface IDeviceTypesService
    {
        /// <summary>
        /// Получить список доступных типов устройств.
        /// </summary>
        /// <returns>Набор типов.</returns>
        Task<IEnumerable<DeviceType>> GetDeviceTypesAsync();
    }
}
