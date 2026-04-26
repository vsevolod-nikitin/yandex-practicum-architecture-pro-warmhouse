using Microsoft.EntityFrameworkCore;
using SmartHome.Devices.Repositories;
using SmartHome.Devices.Services;
using SmartHome.Devices.Services.Implementation;

namespace SmartHome.Devices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DbConnection");

            builder.Services.AddDbContext<DevicesContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            builder.Services.AddTransient<IDevicesService, DevicesService>();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                // Создание БД при первом запуске приложения
                scope.ServiceProvider.GetRequiredService<DevicesContext>();
            }

            app.MapOpenApi();
            app.MapControllers();

            app.Run();
        }
    }
}
