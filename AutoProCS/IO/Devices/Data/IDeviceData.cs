using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Data;

/// <summary>
/// Данные устройства, зависящие от типа и подтипа
/// </summary>
public interface IDeviceData
{
    List<Channel> Channels { get; }

    List<Parameter> Parameters { get; }

    // Properties

    // rtParameters

    // tags
}
