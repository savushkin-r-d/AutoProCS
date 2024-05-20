using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Specification.Builder;

/// <summary>
/// Конструктор <see cref="ISubtype">подтипа</see>
/// </summary>
/// <param name="name">Название подтипа</param>
/// <param name="id">Идентификатор подтипа</param>
/// <param name="description">Описание подтипа</param>
public class SubtypeBuilder
    (
        string name,
        int id,
        string description
    )
{

    private List<ChannelSpec> channels = [];
    private List<ParameterSpec> parameters = [];
    private List<PropertySpec> properties = [];


    /// <summary>
    /// Добавить спецификацию канала ввода-вывода
    /// </summary>
    /// <param name="name">Тип канала</param>
    /// <param name="comment">комментарий канала</param>
    [LuaMember(Name = LuaMembers.AddChannel)]
    public void AddChannel(string name, string comment)
    {
        channels.Add(new ChannelSpec(name, comment));
    }

    /// <summary>
    /// Добавить спецификацию параметра
    /// </summary>
    /// <param name="parameter">Спецификация параметра</param>
    [LuaMember(Name = LuaMembers.AddParameter)]
    public void AddParameter(ParameterSpec parameter)
    {
        parameters.Add(parameter);
    }

    /// <summary>
    /// Добавить спецификацию свойства
    /// </summary>
    /// <param name="property">Спецификация свойства</param>
    [LuaMember(Name = LuaMembers.AddProperty)]
    public void AddProperty(PropertySpec property)
    {
        properties.Add(property);
    }

    /// <summary>
    /// Собрать спецификацию подтипа устройства
    /// </summary>
    /// <returns>Спецификация подтипа</returns>
    [LuaHide]
    public ISubtype Build()
    {
        return new Subtype
        {
            Name = name,
            ID = id,
            Description = description,
            Channels = channels.AsReadOnly(),
            Parameters = parameters.AsReadOnly(),
            Properties = properties.AsReadOnly(),
        };
    }
}
