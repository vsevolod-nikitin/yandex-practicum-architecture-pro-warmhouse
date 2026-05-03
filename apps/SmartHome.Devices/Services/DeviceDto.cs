namespace SmartHome.Devices.Services
{
    /// <summary>
    /// Информация об устройстве в рамках умного дома.
    /// </summary>
    public sealed class DeviceDto
    {
        /// <summary>
        /// Идентификатор устройства.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор дома, к которому принадлежит устройство.
        /// </summary>
        public required long HouseId { get; set; }

        /// <summary>
        /// Наименование типа устройства.
        /// </summary>
        public required string TypeName { get; set; }

        /// <summary>
        /// Наименование устройства.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Местоположение устройства.
        /// </summary>
        public string? Location { get; set; }
    }
}
