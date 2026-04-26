using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Model;

namespace SmartHome.Devices.Repositories
{
    internal sealed class DevicesContext(DbContextOptions<DevicesContext> options) : DbContext(options)
    {
        public DbSet<Device> Devices { get; set; } = null!;
        public DbSet<DeviceType> DeviceTypes { get; set; } = null!;
    }
}
