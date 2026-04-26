using System.Text.Json.Serialization;

namespace SmartHome.Telemetry.Services
{
    /// <summary>
    /// Ответ от монолита с данными телеметрии устройств.
    /// </summary>
    internal sealed class LegacyResponse
    {
        /// <summary>
        /// Значение температуры.
        /// </summary>
        [JsonPropertyName("value")]
        public double Value { get; set; }

        /// <summary>
        /// Единица измерения температуры.
        /// </summary>
        [JsonPropertyName("unit")]
        public required string Unit { get; set; }

        /// <summary>
        /// Текущий статус устройства.
        /// </summary>
        [JsonPropertyName("status")]
        public required string Status { get; set; }

        /// <summary>
        /// Время последнего обновления данных.
        /// </summary>
        [JsonPropertyName("last_updated")]
        public required DateTime LastUpdated { get; set; }
    }
}
