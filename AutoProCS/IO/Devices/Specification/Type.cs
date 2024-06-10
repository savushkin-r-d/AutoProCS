using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

/// <summary>
/// <inheritdoc cref="IType"/>
/// </summary>
public class Type : IType
{
    public required string Name { get; init; }

    public int ID { get; init; }

    public required string Description { get; init; }

    public required ReadOnlyCollection<ISubtype> SubtypeList { get; init; }
}
