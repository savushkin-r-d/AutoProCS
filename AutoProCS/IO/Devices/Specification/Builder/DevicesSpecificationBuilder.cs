using NLua;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoProCS.IO.Devices.Specification.Builder;

/// <summary>
/// Конструктор <see cref="IDevicesSpecification">спецификации</see> 
/// </summary>
public class DevicesSpecificationBuilder
{
    private List<TypeBuilder> TypeBuildersList = [];
    private List<ParameterSpec> sharedParameters = [];
    private List<PropertySpec> sharedProperties = [];


    private DevicesSpecificationBuilder() { }

    /// <summary>
    /// Создать спецификацию устройств на основе Lua-описания
    /// </summary>
    /// <returns>Спецификация устройств</returns>
    [ExcludeFromCodeCoverage]
    public static IDevicesSpecification Create()
    {
        return Create(File.ReadAllText(Properties.Resources.LuaDeviceInitPath));
    }

    /// <summary>
    /// Создать спецификацию устройств на основе Lua-описания
    /// </summary>
    /// <param name="script">Lua</param>
    /// <returns>Спецификация устройств</returns>
    public static IDevicesSpecification Create(string script)
    {
        var lua = new Lua();
        lua.State.Encoding = Encoding.UTF8;
        lua.DoString(script);

        var specs = new DevicesSpecificationBuilder();
        lua.GetFunction(LuaMembers.Init).Call(specs);
        return specs.Build();
    }

    /// <summary>
    /// Добавить определение типа устройства
    /// </summary>
    /// <param name="name">Название типа</param>
    /// <param name="description">Описание типа</param>
    /// <returns>Конструктор типа</returns>
    [LuaMember(Name = LuaMembers.AddType)]
    public TypeBuilder AddType(string name, int id, string description)
    {
        var typeBuilder = new TypeBuilder(name, id, description);
        TypeBuildersList.Add(typeBuilder);

        return typeBuilder;
    }

    /// <summary>
    /// Собрать спецификацию устройств
    /// </summary>
    /// <returns>Спецификация устройств</returns>
    [LuaHide]
    public IDevicesSpecification Build()
    {
        return new DevicesSpecification
        {
            TypeList = TypeBuildersList.Select(b => b.Build()).ToList().AsReadOnly(),
            SharedParameters = sharedParameters.AsReadOnly(),
            SharedProperties = sharedProperties.AsReadOnly(),
        };
    }


    /// <summary>
    /// Найти Спецификация параметра из общего пула по данным параметра.<br/>
    /// Если Спецификация не найдено, то добавляется новый параметр.
    /// </summary>
    /// <param name="name">Lua-название параметра</param>
    /// <param name="description">Описание параметра</param>
    /// <param name="unitFormat">Формат единиц измерения параметра</param>
    /// <returns>Спецификация параметра</returns>
    public ParameterSpec FindOrAddParameter(string name, string description, string unitFormat)
    {
        var parameterDefinition = sharedParameters
            .Find(p => p.Name == name &&
               p.Description == description &&
               p.UnitFormat == unitFormat);

        if (parameterDefinition is null)
        {
            parameterDefinition = new ParameterSpec(name, description, unitFormat);
            sharedParameters.Add(parameterDefinition);
        }

        return parameterDefinition;
    }

    /// <summary>
    /// Найти Спецификация подтипа из общего пула по данным подтипа.<br/>
    /// Если Спецификация не найдено, то добавляется новое свойство.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <returns>Спецификация свойства</returns>
    public PropertySpec FindOrAddProperty(string name, string description)
    {
        var propertyDefinition = sharedProperties
            .Find(p => p.Name == name &&
               p.Description == description);

        if (propertyDefinition is null)
        {
            propertyDefinition = new PropertySpec(name, description);
            sharedProperties.Add(propertyDefinition);
        }

        return propertyDefinition;
    }
}
