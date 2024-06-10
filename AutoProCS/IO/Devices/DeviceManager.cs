using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices;


/// <summary>
/// Менеджер <see cref="IDevice">устройств</see> проекта
/// </summary>
public interface IDeviceManager
{
    /// <summary>
    /// Список <see cref="IDevice">устройств</see> проекта
    /// </summary>
    List<IDevice> Devices { get; }
}

public class DeviceManager : IDeviceManager
{
    public List<IDevice> Devices => throw new NotImplementedException();
}
