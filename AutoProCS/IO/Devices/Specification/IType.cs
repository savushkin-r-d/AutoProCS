using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

/// <summary>
/// Спецификация типа <see cref="Device">устройства</see>
/// </summary>
public interface IType
{
    /// <summary>
    /// Название типа
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Идентификатор типа
    /// </summary>
    int ID { get; }

    /// <summary>
    /// Описание типа
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Список подтипов устройства
    /// </summary>
    public ReadOnlyCollection<ISubtype> SubtypeList { get; }
}
