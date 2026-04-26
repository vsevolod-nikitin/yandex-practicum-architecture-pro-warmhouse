using Microsoft.AspNetCore.Mvc;
using SmartHome.Devices.Services;

namespace SmartHome.Devices.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DevicesController(IDevicesService service) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await service.GetDevicesAsync();
            return Ok(devices);
        }
    }
}
