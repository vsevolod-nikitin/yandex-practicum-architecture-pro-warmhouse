using Microsoft.EntityFrameworkCore;
using SmartHome.Telemetry.Model;

namespace SmartHome.Telemetry.Repositories
{
    /// <summary>
    /// Контекст данных телеметрии устройств.
    /// </summary>
    public sealed class TelemetryContext : DbContext
    {
        public TelemetryContext(DbContextOptions<TelemetryContext> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                SeedData();
            }
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

        /// <summary>
        /// Заполнение базы данных тестовыми данными при первом запуске приложения.
        /// </summary>
        private void SeedData()
        {
            // 2000 - ворота
            // 2001 - выключатель
            TelemetryData.AddRange(
                new TelemetryData
                {
                    Id = 1,
                    DeviceId = 2000,
                    Timestamp = new DateTime(2026, 4, 26, 8, 0, 0, DateTimeKind.Utc),
                    Data = """{"state":"closed"}""",
                },
                new TelemetryData
                {
                    Id = 2,
                    DeviceId = 2000,
                    Timestamp = new DateTime(2026, 4, 26, 8, 5, 0, DateTimeKind.Utc),
                    Data = """{"state":"open"}"""
                },
                new TelemetryData
                {
                    Id = 3,
                    DeviceId = 2000,
                    Timestamp = new DateTime(2026, 4, 26, 8, 10, 0, DateTimeKind.Utc),
                    Data = """{"state":"closed"}"""
                },
                new TelemetryData
                {
                    Id = 4,
                    DeviceId = 2001,
                    Timestamp = new DateTime(2026, 4, 26, 8, 0, 0, DateTimeKind.Utc),
                    Data = """{"state":"off"}"""
                },
                new TelemetryData
                {
                    Id = 5,
                    DeviceId = 2001,
                    Timestamp = new DateTime(2026, 4, 26, 8, 5, 0, DateTimeKind.Utc),
                    Data = """{"state":"on"}"""
                },
                new TelemetryData
                {
                    Id = 6,
                    DeviceId = 2001,
                    Timestamp = new DateTime(2026, 4, 26, 8, 10, 0, DateTimeKind.Utc),
                    Data = """{"state":"off"}"""
                },
                new TelemetryData
                {
                    Id = 7,
                    DeviceId = 2000,
                    Timestamp = new DateTime(2026, 4, 26, 8, 15, 0, DateTimeKind.Utc),
                    Data = """{"state":"open"}"""
                },
                new TelemetryData
                {
                    Id = 8,
                    DeviceId = 2001,
                    Timestamp = new DateTime(2026, 4, 26, 8, 15, 0, DateTimeKind.Utc),
                    Data = """{"state":"on"}"""
                }
            );

            SaveChanges();
        }
    }
}
