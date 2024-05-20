using AutoProCS.IO.Devices.Data;
using KeraLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices;

/// <summary>
/// Устройство
/// </summary>
public interface IDevice
{
    /// <summary>
    /// Сигнатура(идентификатор) устройства
    /// </summary>
    DeviceSignature Signature { get; }

    /// <summary>
    /// Данные (конфигурация устройства) зависящая от типа и подтипа
    /// </summary>
    IDeviceData Data { get; }
    

    string Name => Signature.Name;

    string Type => Signature.Type;
}


public class Device : IDevice
{
    public Device(string name, int subtype)
    {
        Signature = new DeviceSignature(name);
    }

    public DeviceSignature Signature { get; private set; }

    public IDeviceData Data { get; init; }
}
