using System.ComponentModel.DataAnnotations;

namespace SmartHome.Devices.Model
{
    /// <summary>
    /// Тип устройства в рамках умного дома.
    /// </summary>
    public sealed class DeviceType
    {
        /// <summary>
        /// Идентификатор типа устройства.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Наименование типа.
        /// </summary>
        public required string Name { get; set; }
    }
}
