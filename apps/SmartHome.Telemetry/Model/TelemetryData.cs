using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SmartHome.Telemetry.Model
{
    /// <summary>
    /// Телеметрические данные устройства.
    /// </summary>
    [Index(nameof(DeviceId))]
    [Index(nameof(Timestamp))]
    public sealed class TelemetryData
    {
        /// <summary>
        /// Уникальный идентификатор записи.
        /// </summary>
        [Key]
        [JsonIgnore]
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор устройства-источника телеметрии.
        /// </summary>
        [JsonIgnore]
        public long DeviceId { get; set; }

        /// <summary>
        /// Время фиксации данных.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// JSON-данные телеметрии.
        /// </summary>
        [Column(TypeName = "jsonb")]
        public required string Data { get; set; }
    }
}
