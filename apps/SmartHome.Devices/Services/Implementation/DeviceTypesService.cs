using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Model;
using SmartHome.Devices.Repositories;

namespace SmartHome.Devices.Services.Implementation
{
    /// <summary>
    /// Реализация сервиса для работы с типами устройств.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    internal sealed class DeviceTypesService(DevicesContext context) : IDeviceTypesService
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<DeviceType>> GetDeviceTypesAsync()
        {
            var deviceTypes = await context.DeviceTypes.AsNoTracking().ToArrayAsync();
            return deviceTypes;
        }
    }
}
