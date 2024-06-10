using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

/// <summary>
/// Спецификация подтипа <see cref="Device">устройства</see>
/// </summary>
public interface ISubtype
{
    /// <summary>
    /// Название подтипа
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Идентификатор подтипа
    /// </summary>
    int ID { get; }

    /// <summary>
    /// Описание подтипа
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Список параметров
    /// </summary>
    ReadOnlyCollection<ParameterSpec> Parameters { get; }

    /// <summary>
    /// Список свойств
    /// </summary>
    ReadOnlyCollection<PropertySpec> Properties { get; }

    /// <summary>
    /// Список каналов ввода-вывода
    /// </summary>
    ReadOnlyCollection<ChannelSpec> Channels { get; }
}