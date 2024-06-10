using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoProCS.IO.Devices.Specification.Builder;

/// <summary>
/// Конструктор <see cref="IType">типа</see>
/// </summary>
/// <param name="specificationBuilder">Конструктор спецификации</param>
/// <param name="name">Название типа</param>
/// <param name="id">Идентификатор типа</param>
/// <param name="description">Описание типа</param>
public class TypeBuilder
    (
        string name,
        int id,
        string description
    )
{
    private List<SubtypeBuilder> SubtypeBuilders = [];

    /// <summary>
    /// Добавить новый подтип устройства
    /// </summary>
    /// <param name="name">Название</param>
    /// <param name="id">Идентификатор</param>
    /// <param name="description">Описание</param>
    /// <returns>Конструктор подтипа</returns>
    [LuaMember(Name = "AddSubtype")]
    public SubtypeBuilder AddSubtype(string name, int id, string description)
    {
        var stbuilder = new SubtypeBuilder(name, id, description);
        SubtypeBuilders.Add(stbuilder);

        return stbuilder;
    }

    /// <summary>
    /// Собрать спецификацию типа
    /// </summary>
    /// <returns>Спецификация типа устройства</returns>
    public IType Build()
    {
        return new Type()
        {
            Name = name,
            ID = id,
            Description = description,
            SubtypeList = SubtypeBuilders.Select(b => b.Build()).ToList().AsReadOnly(),
        };
    }
}
