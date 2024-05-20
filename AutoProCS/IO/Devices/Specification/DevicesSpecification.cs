using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace AutoProCS.IO.Devices.Specification;

public partial class DevicesSpecification : IDevicesSpecification
{
    public required ReadOnlyCollection<ParameterSpec> SharedParameters { get; init; }

    public required ReadOnlyCollection<PropertySpec> SharedProperties { get; init; }

    public required ReadOnlyCollection<IType> TypeList { get; init; }
}
