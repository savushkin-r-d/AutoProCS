using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Data;

public class Channel
{
    public required IOType Type { get; init; }

    public string Comment { get; init; } = string.Empty;
}
