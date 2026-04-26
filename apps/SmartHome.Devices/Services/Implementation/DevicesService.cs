using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Model;
using SmartHome.Devices.Repositories;

namespace SmartHome.Devices.Services.Implementation
{
    public sealed class DevicesService(DevicesContext context) : IDevicesService
    {
        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            var result = await context.Devices.AsNoTracking().ToListAsync();
            return result;
        }
    }
}
