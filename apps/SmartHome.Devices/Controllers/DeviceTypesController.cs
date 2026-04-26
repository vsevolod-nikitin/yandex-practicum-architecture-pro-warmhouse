using Microsoft.AspNetCore.Mvc;
using SmartHome.Devices.Model;
using SmartHome.Devices.Services;
using static System.Net.Mime.MediaTypeNames;

namespace SmartHome.Devices.Controllers
{
    /// <summary>
    /// Контроллер для работы с типами устройств в рамках умного дома.
    /// </summary>
    /// <param name="service">Сервис для работы с типами устройств.</param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class DeviceTypesController(IDeviceTypesService service) : ControllerBase
    {
        /// <summary>
        /// Получить список доступных типов устройств.
        /// </summary>
        /// <returns>Список типов.</returns>
        /// <response code="200">Типы устройств успешно получены.</response>
        [HttpGet("")]
        [ProducesResponseType<DeviceType[]>(StatusCodes.Status200OK, Application.Json)]
        public async Task<IActionResult> GetDeviceTypes()
        {
            var deviceTypes = await service.GetDeviceTypesAsync();
            return Ok(deviceTypes);
        }
    }
}
