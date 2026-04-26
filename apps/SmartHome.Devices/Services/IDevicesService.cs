using SmartHome.Devices.Model;

namespace SmartHome.Devices.Services
{
    public interface IDevicesService
    {
        Task<IEnumerable<Device>> GetDevicesAsync();
    }
}
