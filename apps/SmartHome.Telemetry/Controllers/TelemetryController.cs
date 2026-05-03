using Microsoft.AspNetCore.Mvc;
using SmartHome.Telemetry.Model;
using SmartHome.Telemetry.Services;
using static System.Net.Mime.MediaTypeNames;

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
        /// <response code="200">Успешный ответ с данными телеметрии.</response>
        /// <response code="400">Некорректные параметры запроса.</response>
        /// <response code="404">Устройство не найдено.</response>
        [HttpGet("{deviceId}")]
        [ProducesResponseType<TelemetryData[]>(StatusCodes.Status200OK, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound, Application.Json)]
        public async Task<IActionResult> GetTelemetryData([FromRoute] int deviceId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var telemetryData = await service.GetTelemetryDataAsync(deviceId, from, to);
            if (telemetryData is null)
            {
                return NotFound();
            }

            return Ok(telemetryData);
        }
    }
}
