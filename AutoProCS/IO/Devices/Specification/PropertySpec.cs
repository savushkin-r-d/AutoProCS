using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

/// <summary>
/// Спецификация <see cref="">свойства</see>
/// </summary>
public class PropertySpec
{
    public PropertySpec() { }
    
    [SetsRequiredMembers]
    public PropertySpec(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Название <see cref="">свойства</see>
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Описание <see cref="">свойства</see>
    /// </summary>
    public required string Description { get; init; }
}
