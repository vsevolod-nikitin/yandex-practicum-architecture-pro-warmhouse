using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Model;

namespace SmartHome.Devices.Repositories
{
    /// <summary>
    /// Контекст данных устройств в рамках умного дома.
    /// </summary>
    /// <param name="options">Опции контекста данных.</param>
    internal sealed class DevicesContext(DbContextOptions<DevicesContext> options) : DbContext(options)
    {
        /// <summary>
        /// Набор устройств в рамках умного дома.
        /// </summary>
        public DbSet<Device> Devices { get; set; } = null!;

        /// <summary>
        /// Типы устройств.
        /// </summary>
        public DbSet<DeviceType> DeviceTypes { get; set; } = null!;
    }
}
