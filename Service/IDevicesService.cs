namespace GameZone.Service
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetDevices();
    }
}
