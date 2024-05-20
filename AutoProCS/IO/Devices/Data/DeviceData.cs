using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Data;

/// <summary>
/// <inheritdoc cref="IDeviceData"/>
/// </summary>
public class DeviceData : IDeviceData
{
    public List<Channel> Channels => throw new NotImplementedException();

    public List<Parameter> Parameters => throw new NotImplementedException();
}
