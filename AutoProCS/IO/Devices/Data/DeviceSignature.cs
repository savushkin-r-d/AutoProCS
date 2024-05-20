using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices;

/// <summary>
/// Сигнатура устройства
/// </summary>
public partial class DeviceSignature
{
    /// <summary>
    /// Регулярное выражение для разбора названия устройства
    /// </summary>
    [GeneratedRegex(@"(?<object>[A-z]+)(?<object_id>\d+)(?<type>[A-z]+)(?<dev_id>\d+)")]
    private static partial Regex DeviceNameRegex();

    /// <summary>
    /// Создание сигнатуры устройства на основе названия (OBJ2DEV1)
    /// </summary>
    /// <param name="name">Название устройства</param>
    public DeviceSignature(string name) 
    {
        Match match = DeviceNameRegex().Match(name);
        if (match.Success is false)
            return;

        Object = match.Groups["object"].Value;
        ObjectId = int.Parse(match.Groups["object_id"].Value);
        Type = match.Groups["type"].Value;
        DeviceId = int.Parse(match.Groups["dev_id"].Value);
    }

    /// <summary>
    /// Название <see cref="IDevice">устройства</see>. <br/>
    /// пример: "OBJ1V2"
    /// </summary>
    public string Name => $"{Object}{ObjectId}{Type}{DeviceId}";

    /// <summary>
    /// Обозначение <see cref="IDevice">устройства</see> на схеме. <br/>
    /// пример: "+OBJ1-V2"
    /// </summary>
    public string CADName => $"+{Object}{ObjectId}-{Type}{DeviceId}";


    /// <summary>
    /// Название объекта. <br/>
    /// Пример: OBJ в OBJ1V2
    /// </summary>
    public string Object { get; set; }

    /// <summary>
    /// Номер объекта. <br/>
    /// Пример: 1 в OBJ1V2
    /// </summary>
    public int ObjectId { get; set; }

    /// <summary>
    /// Название типа устройства. <br/>
    /// Пример: V в OBJ1V2
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Номер устройства. <br/>
    /// Пример: 2 в OBJ1V2
    /// </summary>
    public int DeviceId { get; set; }
}
