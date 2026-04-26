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
        public async Task<IEnumerable<DeviceDto>> GetDevicesAsync(long houseId)
        {
            var devices = await context.Devices
                .Where(x => x.HouseId == houseId)
                .Include(x => x.Type)
                .Select(x => new DeviceDto
                {
                    Id = x.Id,
                    HouseId = x.HouseId,
                    TypeName = x.Type.Name,
                    Name = x.Name,
                    Location = x.Location,
                })
                .AsNoTracking()
                .ToArrayAsync();

            return devices;
        }

        /// <inheritdoc/>
        public async Task<long> CreateDeviceAsync(DeviceDto device)
        {
            var deviceType = await context.DeviceTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Name == device.TypeName) 
                ?? throw new InvalidOperationException($"Тип устройства с наименованием '{device.TypeName}' отсутствует");

            var newDevice = new Device
            {
                HouseId = device.HouseId,
                TypeId = deviceType.Id,
                Name = device.Name,
                Location = device.Location,
            };

            context.Add(newDevice);
            await context.SaveChangesAsync();

            return newDevice.Id;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteDeviceAsync(long deviceId)
        {
            var device = await context.Devices.FirstOrDefaultAsync(x => x.Id == deviceId);
            if (device is null)
            {
                return false;
            }

            context.Remove(device);
            await context.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<DeviceDto?> GetDeviceByIdAsync(long deviceId)
        {
            var device = await context.Devices
                .Where(x => x.Id == deviceId)
                .Include(x => x.Type)
                .Select(x => new DeviceDto
                {
                    Id = x.Id,
                    HouseId = x.HouseId,
                    TypeName = x.Type.Name,
                    Name = x.Name,
                    Location = x.Location,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return device;
        }

        /// <inheritdoc/>
        public async Task<DeviceDto?> UpdateDeviceAsync(long deviceId, DeviceDto device)
        {   
            var current = await context.Devices
                .Where(x => x.Id == deviceId)
                .Include(x => x.Type)
                .FirstOrDefaultAsync();

            if (current is null)
            {
                return null;
            }

            if (current.Type.Name != device.TypeName)
            {
                var deviceType = await context.DeviceTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Name == device.TypeName) 
                    ?? throw new InvalidOperationException($"Тип устройства с наименованием '{device.TypeName}' отсутствует");

                current.TypeId = deviceType.Id;
            }

            current.HouseId = device.HouseId;
            current.Name = device.Name;
            current.Location = device.Location;

            await context.SaveChangesAsync();

            return new DeviceDto
            {
                Id = current.Id,
                HouseId = current.HouseId,
                TypeName = current.Type.Name,
                Name = current.Name,
                Location = current.Location,
            };
        }
    }
}
