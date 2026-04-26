using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Model;
using SmartHome.Devices.Repositories;

namespace SmartHome.Devices.Services.Implementation
{
    /// <summary>
    /// Реализация сервиса для работы с устройствами.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    internal sealed class DevicesService(DevicesContext context) : IDevicesService
    {
        /// <inheritdoc/>
        public Task<long> CreateDeviceAsync(Device device)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<bool> DeleteDeviceAsync(long deviceId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Device?> GetDeviceByIdAsync(long deviceId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            var result = await context.Devices.AsNoTracking().ToListAsync();
            return result;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Device>> GetDevicesAsync(long houseId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Device?> UpdateDeviceAsync(long deviceId, Device device)
        {
            throw new NotImplementedException();
        }
    }
}
