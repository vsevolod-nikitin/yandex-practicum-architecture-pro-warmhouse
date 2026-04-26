using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Model;

namespace SmartHome.Devices.Repositories
{
    public sealed class DevicesContext : DbContext
    {
        public DevicesContext(DbContextOptions<DevicesContext> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                SeedData();
            }
        }

        public DbSet<Device> Devices { get; set; } = null!;
        public DbSet<DeviceType> DeviceTypes { get; set; } = null!;

        private void SeedData()
        {
            if (!DeviceTypes.Any())
            {
                DeviceTypes.AddRange(
                    new DeviceType { Name = "Light" },
                    new DeviceType { Name = "Thermostat" },
                    new DeviceType { Name = "Gates" }
                );

                SaveChanges();
            }
        }
    }
}
