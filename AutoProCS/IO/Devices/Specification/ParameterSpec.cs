using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

/// <summary>
/// Спецификация <see cref="Data.Parameter">параметра</see>
/// </summary>
public class ParameterSpec
{
    public ParameterSpec() { }

    [SetsRequiredMembers]
    public ParameterSpec(string name, string description, string unitFormat)
    {
        Name = name;
        Description = description;
        UnitFormat = unitFormat;
    }

    /// <summary>
    /// Название <see cref="Data.Parameter">параметра</see>
    /// </summary>
    public required string Name { get; init; }


    /// <summary>
    /// Описание <see cref="Data.Parameter">параметра</see>
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// Формат единиц измерения <see cref="Data.Parameter">параметра</see>
    /// </summary>
    public required string UnitFormat { get; init; }
}
