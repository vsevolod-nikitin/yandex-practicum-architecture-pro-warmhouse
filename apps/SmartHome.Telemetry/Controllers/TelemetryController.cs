using Microsoft.AspNetCore.Mvc;
using SmartHome.Telemetry.Services;

namespace SmartHome.Telemetry.Controllers
{
    /// <summary>
    /// Контроллер для получения телеметрических данных устройств.
    /// </summary>
    /// <param name="service"></param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class TelemetryController(ITelemetryService service) : ControllerBase
    {
        /// <summary>
        /// Получить телеметрические данные для указанного устройства за заданный период времени.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <param name="from">Начальная дата и время периода.</param>
        /// <param name="to">Конечная дата и время периода.</param>
        /// <returns>Коллекция телеметрических данных.</returns>
        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetTelemetryData([FromRoute] int deviceId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var telemetryData = await service.GetTelemetryDataAsync(deviceId, from, to);
            return Ok(telemetryData);
        }
    }
}
