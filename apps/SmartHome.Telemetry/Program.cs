using Microsoft.EntityFrameworkCore;
using SmartHome.Telemetry.Repositories;
using SmartHome.Telemetry.Services;
using SmartHome.Telemetry.Services.Implementation;

namespace SmartHome.Telemetry
{
    public class Program
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

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                // Создание БД при первом запуске приложения
                scope.ServiceProvider.GetRequiredService<TelemetryContext>();
            }

            app.MapOpenApi();
            app.MapControllers();

            app.Run();
        }
    }
}
