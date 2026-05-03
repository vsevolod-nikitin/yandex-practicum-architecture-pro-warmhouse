using System.Text.Json.Serialization;

namespace TemperatureApi.Model
{
    /// <summary>
    /// Модель ответа датчика температуры.
    /// Содержит текущее измерение, метаданные датчика и служебную информацию.
    /// </summary>
    public sealed record TemperatureResponseDto
    {
        /// <summary>Измеренное значение температуры.</summary>
        [JsonPropertyName("value")]
        public required double Value { get; init; }

        /// <summary>Единица измерения температуры.</summary>
        [JsonPropertyName("unit")]
        public required string Unit { get; init; }

        /// <summary>Время получения показания датчика.</summary>
        [JsonPropertyName("timestamp")]
        public required DateTime Timestamp { get; init; }

        /// <summary>Местоположение датчика или точки измерения.</summary>
        [JsonPropertyName("location")]
        public required string Location { get; init; }

        /// <summary>Текущий статус показания или датчика.</summary>
        [JsonPropertyName("status")]
        public required string Status { get; init; }

        /// <summary>Идентификатор датчика.</summary>
        [JsonPropertyName("sensor_id")]
        public required string SensorID { get; init; }

        /// <summary>Тип датчика.</summary>
        [JsonPropertyName("sensor_type")]
        public required string SensorType { get; init; }

        /// <summary>Текстовое описание показания.</summary>
        [JsonPropertyName("description")]
        public required string Description { get; init; }
    }
}
