using Microsoft.AspNetCore.Mvc;
using SmartHome.Telemetry.Services;

namespace SmartHome.Telemetry.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class TelemetryController(ITelemetryService service) : ControllerBase
    {
        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetTelemetryData([FromRoute] int deviceId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var telemetryData = await service.GetTelemetryDataAsync(deviceId, from, to);
            return Ok(telemetryData);
        }
    }
}
