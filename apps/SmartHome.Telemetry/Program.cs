using Microsoft.EntityFrameworkCore;
using SmartHome.Telemetry.Model;
using SmartHome.Telemetry.Repositories;
using SmartHome.Telemetry.Services;
using SmartHome.Telemetry.Services.Implementation;
using SmartHome.Telemetry.Services.Legacy;
using SmartHome.Telemetry.Services.Legacy.Implementation;
using System.Reflection;

namespace SmartHome.Telemetry
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DbConnection");

            builder.Services.AddDbContext<TelemetryContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });

            builder.Services.AddTransient<ITelemetryService, TelemetryService>();
            builder.Services.AddHttpClient<ILegacyTelemetryService, LegacyTelemetryService>(client =>
            {
                var legacyApiUrl = builder.Configuration["LEGACY_API_URL"];

                if (string.IsNullOrWhiteSpace(legacyApiUrl))
                {
                    throw new InvalidOperationException("Ключ конфигурации 'LEGACY_API_URL' отсутствует.");
                }

                client.BaseAddress = new Uri(legacyApiUrl);
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                // Создание тестовой БД при первом запуске приложения
                var context = scope.ServiceProvider.GetRequiredService<TelemetryContext>();
                if (context.Database.EnsureCreated())
                {
                    SeedData(context);
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHome.Telemetry v1");
                options.RoutePrefix = "swagger";
            });

            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// Заполнение базы данных тестовыми данными при первом запуске приложения.
        /// </summary>
        private static void SeedData(TelemetryContext context)
        {
            // 2000 - ворота
            // 2001 - выключатель
            context.TelemetryData.AddRange(
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

            context.SaveChanges();
        }
    }
}
