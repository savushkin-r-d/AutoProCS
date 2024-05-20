using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification.Builder;

public static class LuaMembers
{
    /// <summary>
    /// <see cref="DevicesSpecificationBuilder.Create()"/>
    /// </summary>
    public const string Init = nameof(Init);

    /// <summary>
    /// <see cref="DevicesSpecificationBuilder.AddType(string, int, string)"/>
    /// </summary>
    public const string AddType = nameof(AddType);

    /// <summary>
    /// <see cref="TypeBuilder.AddSubtype(string, int, string)"/>
    /// </summary>
    public const string AddSubtype = nameof(AddSubtype);

    /// <summary>
    /// <see cref="SubtypeBuilder.AddParameter(ParameterSpec)"/>
    /// </summary>
    public const string AddParameter = nameof(AddParameter);

    /// <summary>
    /// <see cref="SubtypeBuilder.AddProperty(PropertySpec)"/>
    /// </summary>
    public const string AddProperty = nameof(AddProperty);

    /// <summary>
    /// <see cref="SubtypeBuilder.AddChannel(string, string)"/>
    /// </summary>
    public const string AddChannel = nameof(AddChannel);
}
