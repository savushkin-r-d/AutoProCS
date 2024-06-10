using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification;

/// <summary>
/// Спецификация канала ввода-вывода
/// </summary>
public class ChannelSpec
{
    public ChannelSpec() { }

    [SetsRequiredMembers]
    public ChannelSpec(string name, string comment)
    {
        Name = name;
        Comment = comment;
    }

    /// <summary>
    /// Тип канала (AO, AI, DO, DI)
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Комментарий канала
    /// </summary>
    public required string Comment { get; init; }
}
