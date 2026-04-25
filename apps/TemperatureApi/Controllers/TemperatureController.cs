using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Model;

namespace TemperatureApi.Controllers
{
    /// <summary>
    /// Контроллер для получения данных о температуре.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        /// <summary>
        /// Возвращает текущую температуру по названию местоположения.
        /// </summary>
        /// <param name="location">Название местоположения.</param>
        /// <returns>Объект с данными о температуре.</returns>
        [HttpGet("/temperature")]
        public IActionResult GetLocationTemperature([FromQuery] string location)
        {
            var sensorId = GetSensorID(location);
            var response = GetTemperature(location, sensorId);

            return Ok(response);
        }

        /// <summary>
        /// Возвращает текущую температуру по идентификатору датчика.
        /// </summary>
        /// <param name="sensorID">Идентификатор датчика.</param>
        /// <returns>Объект с данными о температуре.</returns>
        [HttpGet("/temperature/{sensorID}")]
        public IActionResult GetSensorTemperature([FromRoute] string sensorID)
        {
            var location = GetLocation(sensorID);
            var response = GetTemperature(location, sensorID);

            return Ok(response);
        }

        /// <summary>
        /// Формирует DTO с имитированными данными температуры.
        /// </summary>
        /// <param name="location">Название местоположения датчика.</param>
        /// <param name="sensorID">Идентификатор датчика.</param>
        /// <returns>Заполненный объект <see cref="TemperatureResponseDto"/>.</returns>
        private static TemperatureResponseDto GetTemperature(string location, string sensorID)
        {
            return new TemperatureResponseDto
            {
                // Имитируем температуру в диапазоне от 0 до 30 градусов.
                Value = Random.Shared.NextDouble() * 30d,
                Unit = "Celsius",
                Timestamp = DateTime.UtcNow,
                Location = location,
                Status = "OK",
                SensorID = sensorID,
                SensorType = "Thermometer",
                Description = $"Описание датчика, расположенного в '{location}' ({sensorID}).",
            };
        }

        /// <summary>
        /// Определяет местоположение по идентификатору датчика.
        /// </summary>
        /// <param name="sensorID">Идентификатор датчика.</param>
        /// <returns>Название местоположения или <c>Unknown</c>, если датчик не найден.</returns>
        private static string GetLocation(string sensorID)
        {
            return sensorID switch
            {
                "1" => "Living Room",
                "2" => "Bedroom",
                "3" => "Kitchen",
                _ => "Unknown",
            };
        }

        /// <summary>
        /// Определяет идентификатор датчика по названию местоположения.
        /// </summary>
        /// <param name="location">Название местоположения.</param>
        /// <returns>Идентификатор датчика или <c>0</c>, если местоположение неизвестно.</returns>
        private static string GetSensorID(string location)
        {
            return location switch
            {
                "Living Room" => "1",
                "Bedroom" => "2",
                "Kitchen" => "3",
                _ => "0",
            };
        }
    }
}
