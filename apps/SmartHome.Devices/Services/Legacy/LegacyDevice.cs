using System.Text.Json.Serialization;

namespace SmartHome.Devices.Services.Legacy
{
    /// <summary>
    /// Информация об устройстве старого формата.
    /// </summary>
    internal sealed record LegacyDevice
    {
        /// <summary>
        /// Идентификатор устройства.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; init; }

        /// <summary>
        /// Название устройства.
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        /// <summary>
        /// Тип устройства.
        /// </summary>
        [JsonPropertyName("type")]
        public required string Type { get; init; }

        /// <summary>
        /// Расположение устройства.
        /// </summary>
        [JsonPropertyName("location")]
        public required string Location { get; init; }

        /// <summary>
        /// Значение показателя устройства.
        /// </summary>
        [JsonPropertyName("value")]
        public double Value { get; init; }

        /// <summary>
        /// Единица измерения значения.
        /// </summary>
        [JsonPropertyName("unit")]
        public required string Unit { get; init; }

        /// <summary>
        /// Текущий статус устройства.
        /// </summary>
        [JsonPropertyName("status")]
        public required string Status { get; init; }

        /// <summary>
        /// Время последнего обновления.
        /// </summary>
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; init; }

        /// <summary>
        /// Время создания записи.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }
    }
}
