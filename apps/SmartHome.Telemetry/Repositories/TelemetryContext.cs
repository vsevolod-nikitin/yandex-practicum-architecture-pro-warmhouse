using Microsoft.EntityFrameworkCore;
using SmartHome.Telemetry.Model;

namespace SmartHome.Telemetry.Repositories
{
    /// <summary>
    /// Контекст данных телеметрии устройств.
    /// </summary>
    internal sealed class TelemetryContext : DbContext
    {
        public TelemetryContext(DbContextOptions<TelemetryContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        /// <summary>
        /// Данные телеметрии устройств.
        /// </summary>
        public DbSet<TelemetryData> TelemetryData { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelemetryData>()
                .Property(x => x.Timestamp)
                .HasDefaultValueSql("timezone('utc', now())")
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
