using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

/// <summary>
/// Спецификация устройств
/// </summary>
public interface IDevicesSpecification
{
    /// <summary>
    /// Общий пул параметров устройств
    /// </summary>
    public ReadOnlyCollection<ParameterSpec> SharedParameters { get; }

    /// <summary>
    /// Общий пул свойств устройств
    /// </summary>
    public ReadOnlyCollection<PropertySpec> SharedProperties { get; }

    /// <summary>
    /// Список типов устройств
    /// </summary>
    public ReadOnlyCollection<IType> TypeList { get; }
}
