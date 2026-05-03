using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHome.Devices.Model
{
    /// <summary>
    /// Данные устройства в рамках умного дома.
    /// </summary>
    [Index(nameof(HouseId))]
    internal sealed class Device
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор дома, к которому принадлежит устройство.
        /// </summary>
        public required long HouseId { get; set; }

        /// <summary>
        /// Идентификатор типа устройства.
        /// </summary>
        public required long TypeId { get; set; }

        /// <summary>
        /// Наименование устройства.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Местоположение устройства.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Тип устройства.
        /// </summary>
        [ForeignKey(nameof(TypeId))]
        public DeviceType Type { get; set; } = null!;
    }
}
