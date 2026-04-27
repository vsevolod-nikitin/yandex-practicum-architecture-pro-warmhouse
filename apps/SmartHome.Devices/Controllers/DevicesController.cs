using Microsoft.AspNetCore.Mvc;
using SmartHome.Devices.Services;
using static System.Net.Mime.MediaTypeNames;

namespace SmartHome.Devices.Controllers
{
    /// <summary>
    /// Контроллер для работы с устройствами в рамках умного дома.
    /// </summary>
    /// <param name="service">Сервис для работы с устройствами.</param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DevicesController(IDevicesService service) : ControllerBase
    {
        /// <summary>
        /// Получить список устройств для указанного дома.
        /// </summary>
        /// <param name="houseId">Идентификатор дома.</param>
        /// <returns>Список устройств.</returns>
        /// <response code="200">Устройства успешно получены.</response>
        /// <response code="400">Некорректный запрос.</response>
        [HttpGet("house/{houseId}")]
        [ProducesResponseType<DeviceDto[]>(StatusCodes.Status200OK, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, Application.Json)]
        public async Task<IActionResult> GetDevicesForHouse([FromRoute] long houseId)
        {
            var devices = await service.GetDevicesForHouseAsync(houseId);
            return Ok(devices);
        }

        /// <summary>
        /// Получить информацию об устройстве по его идентификатору.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Информация об устройстве.</returns>
        /// <response code="200">Устройство успешно получено.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Устройство не найдено.</response>
        [HttpGet("{deviceId}")]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status200OK, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound, Application.Json)]
        public async Task<IActionResult> GetDeviceById([FromRoute] long deviceId)
        {
            var device = await service.GetDeviceByIdAsync(deviceId);
            if (device is null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        /// <summary>
        /// Создать новое устройство.
        /// </summary>
        /// <param name="device">Информация об устройстве для создания.</param>
        /// <returns>Результат создания.</returns>
        /// <response code="201">Устройство успешно создано.</response>
        /// <response code="400">Некорректный запрос.</response>
        [HttpPost("")]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status201Created, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, Application.Json)]
        public async Task<IActionResult> CreateDevice([FromBody] DeviceDto device)
        {
            try
            {
                var deviceId = await service.CreateDeviceAsync(device);
                device.Id = deviceId;

                return CreatedAtAction(nameof(GetDeviceById), new { deviceId }, device);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Обновить информацию об устройстве.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <param name="device">Информация об устройстве для обновления.</param>
        /// <returns>Результат обновления.</returns>
        /// <response code="200">Устройство успешно обновлено.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Устройство не найдено.</response>
        [HttpPut("{deviceId}")]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status200OK, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound, Application.Json)]
        public async Task<IActionResult> UpdateDevice([FromRoute] long deviceId, [FromBody] DeviceDto device)
        {
            try
            {
                var updatedDevice = await service.UpdateDeviceAsync(deviceId, device);
                if (updatedDevice is null)
                {
                    return NotFound();
                }

                return Ok(updatedDevice);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удалить устройство по его идентификатору.
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства.</param>
        /// <returns>Результат удаления.</returns>
        /// <response code="204">Устройство успешно удалено.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Устройство не найдено.</response>
        [HttpDelete("{deviceId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, Application.Json)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound, Application.Json)]
        public async Task<IActionResult> DeleteDevice([FromRoute] long deviceId)
        {
            var deleted = await service.DeleteDeviceAsync(deviceId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
