using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Model;
using SmartHome.Devices.Repositories;
using SmartHome.Devices.Services;
using SmartHome.Devices.Services.Implementation;
using SmartHome.Devices.Services.Legacy;
using SmartHome.Devices.Services.Legacy.Implementation;
using System.Reflection;

namespace SmartHome.Devices
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DbConnection");

            builder.Services.AddDbContext<DevicesContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });

            builder.Services.AddTransient<IDevicesService, DevicesService>();
            builder.Services.AddTransient<IDeviceTypesService, DeviceTypesService>();
            builder.Services.AddHttpClient<ILegacyDevicesService, LegacyDevicesService>(client =>
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
                // Создание БД при первом запуске приложения
                var context = scope.ServiceProvider.GetRequiredService<DevicesContext>();
                if (context.Database.EnsureCreated())
                {
                    SeedData(context);
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHome.Devices v1");
                options.RoutePrefix = "swagger";
            });

            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// Добавление тестовых типов данных.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        private static void SeedData(DevicesContext context)
        {
            context.DeviceTypes.AddRange(
                new DeviceType { Name = "LegacySensor" },
                new DeviceType { Name = "Light" },
                new DeviceType { Name = "Thermostat" },
                new DeviceType { Name = "Gates" }
            );

            context.SaveChanges();

            // Установка начального значения для генерации идентификаторов устройств, чтобы не пересекаться с данными из монолита
            context.Database.ExecuteSqlInterpolated($"ALTER SEQUENCE devices_id_seq RESTART 2000");
        }
    }
}
