using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

public class Subtype : ISubtype
{
    public required string Name { get; init; }

    public int ID { get; init; }

    public required string Description { get; init; }

    public required ReadOnlyCollection<ParameterSpec> Parameters { get; init; }

    public required ReadOnlyCollection<PropertySpec> Properties { get; init; }

    public required ReadOnlyCollection<ChannelSpec> Channels { get; init; }
}
