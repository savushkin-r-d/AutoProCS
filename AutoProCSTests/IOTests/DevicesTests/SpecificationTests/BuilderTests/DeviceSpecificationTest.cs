using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoProCS.IO.Devices.Specification.Builder;
using NLua;

namespace AutoProCSTests.IOTests.DevicesTests.SpecificationTests.BuilderTests;

public class DeviceSpecificationTest
{
    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void Create_FromScript()
    {
        const string EmptyUnitFormat = nameof(EmptyUnitFormat);

        const string T1 = nameof(T1);
        const int T1_ID = 1;
        const string T2 = nameof(T2);
        const int T2_ID = 3;
        const string T1Desc = nameof(T1Desc);
        const string T1S1 = nameof(T1S1);
        const int T1S1_ID = 1;
        const string T1S1Desc = nameof(T1S1Desc);
        const string T2S1 = nameof(T2S1);
        const int T2S1_ID = 5;

        // Параметры
        const string P1 = nameof(P1);
        const string P1Desc = nameof(P1Desc);
        const string P1Unit = nameof(P1Unit);
        const string T1S1P2 = nameof(T1S1P2);

        // Свойства
        const string Pr1 = nameof(Pr1);
        const string Pr1Desc = nameof(Pr1Desc);
        const string T1S1Pr2 = nameof(T1S1Pr2);

        // Каналы ввода-вывода
        const string T1S1Ch1 = nameof(T1S1Ch1);
        const string T1S1Ch2 = nameof(T1S1Ch2);

        var devicesSpecification = DevicesSpecificationBuilder.Create($$"""
            local UnitFormat = {
                Empty = '{{EmptyUnitFormat}}',
            }
            
            local Parameters = {
                {{P1}} = {
                    name = '{{P1}}',
                    description = '{{P1Desc}}',
                    unit = '{{P1Unit}}',
                },
            }

            local Properties = {
                {{Pr1}} = {
                    name = '{{Pr1}}',
                    description = '{{Pr1Desc}}',
                },
            }

            local devices = {
                [ {{T1_ID}} ] = {
                    name = '{{T1}}',
                    description = '{{T1Desc}}',
                    subtypes = {
                        [ {{T1S1_ID}} ] = { 
                            name = '{{T1S1}}',
                            description = '{{T1S1Desc}}',
                            parameters = {
                                Parameters.{{P1}},
                                {
                                    name = '{{T1S1P2}}',
                                },
                            },
                            properties = {
                                Properties.{{Pr1}},
                                {
                                    name = '{{T1S1Pr2}}',
                                },
                            },
                            channels = {
                                DO = {},
                                AO = { '{{T1S1Ch1}}', '{{T1S1Ch2}}' },
                            },
                        },
                    }
                },
                [ {{T2_ID}} ] = {
                    name = '{{T2}}',
                    subtypes = {
                        [ {{T2S1_ID}} ] = {
                            name = '{{T2S1}}',
                            parameters = {
                                Parameters.{{P1}},
                            },
                            properties = {
                                Properties.{{Pr1}},
                            },
                        },
                    }
                },
            }

            function Init(devicesSpecificationBuilder)
                for type_id, type in pairs(devices) do
                    local TypeBuilder = devicesSpecificationBuilder:AddType(type.name, type_id, type.description or '');
                    for subtype_id, subtype in pairs(type.subtypes) do
                        local SubtypeBuilder = TypeBuilder:AddSubtype(subtype.name, subtype_id, subtype.description or '')
        
                        for _, parameter in ipairs(subtype.parameters or {}) do
                            SubtypeBuilder:AddParameter(devicesSpecificationBuilder:FindOrAddParameter(parameter.name, parameter.description or '', parameter.unit or UnitFormat.Empty))
                        end

                        for _, property in ipairs(subtype.properties or {}) do
                            SubtypeBuilder:AddProperty(devicesSpecificationBuilder:FindOrAddProperty(property.name, property.description or ''))
                        end

                        for channel_type, channels in pairs(subtype.channels or {}) do
                            if not next(channels) then
                                SubtypeBuilder:AddChannel(channel_type, '');
                            else
                                for _, comment in ipairs(channels) do
                                    SubtypeBuilder:AddChannel(channel_type, comment);
                                end
                            end
                        end
                    end
                end
            end
            """);

        Assert.Multiple(() =>
        {
            var firstType = devicesSpecification.TypeList.FirstOrDefault(type => type.ID == T1_ID);
            Assert.That(firstType, Is.Not.Null);
            Assert.That(firstType?.Name, Is.EqualTo(T1));
            Assert.That(firstType?.Description, Is.EqualTo(T1Desc));

            var secondType = devicesSpecification.TypeList.FirstOrDefault(type => type.ID == T2_ID);
            Assert.That(secondType, Is.Not.Null);
            Assert.That(secondType?.Name, Is.EqualTo(T2));
            Assert.That(secondType?.Description, Is.Empty);

            var parameter = devicesSpecification.SharedParameters.FirstOrDefault(p => p.Name == P1);
            Assert.That(parameter, Is.Not.Null);
            Assert.That(parameter?.Name, Is.EqualTo(P1));
            Assert.That(parameter?.Description, Is.EqualTo(P1Desc));
            Assert.That(parameter?.UnitFormat, Is.EqualTo(P1Unit));

            var property = devicesSpecification.SharedProperties.FirstOrDefault(pr => pr.Name == Pr1);
            Assert.That(property, Is.Not.Null);
            Assert.That(property?.Name, Is.EqualTo(Pr1));
            Assert.That(property?.Description, Is.EqualTo(Pr1Desc));

            var firstTypeSubtype = firstType?.SubtypeList.FirstOrDefault(type => type.ID == T1S1_ID);
            Assert.That(firstTypeSubtype, Is.Not.Null);
            Assert.That(firstTypeSubtype?.Name, Is.EqualTo(T1S1));
            Assert.That(firstTypeSubtype?.Description, Is.EqualTo(T1S1Desc));
            CollectionAssert.AreEquivalent(new[] { P1, T1S1P2 }, firstTypeSubtype?.Parameters.Select(p => p.Name));
            CollectionAssert.AreEquivalent(new[] { Pr1, T1S1Pr2 }, firstTypeSubtype?.Properties.Select(p => p.Name));
            CollectionAssert.AreEquivalent(new[] { T1S1Ch1, T1S1Ch2 }, firstTypeSubtype?.Channels.Where(ch => ch.Name == "AO").Select(ch => ch.Comment));
            Assert.That(firstTypeSubtype?.Parameters.FirstOrDefault(p => p.Name == parameter?.Name), Is.SameAs(parameter));
            Assert.That(firstTypeSubtype?.Properties.FirstOrDefault(p => p.Name == property?.Name), Is.SameAs(property));


            var secondTypeSubtype = secondType?.SubtypeList.FirstOrDefault(type => type.ID == T2S1_ID);
            Assert.That(secondTypeSubtype, Is.Not.Null);
            Assert.That(secondTypeSubtype?.Name, Is.EqualTo(T2S1));
            Assert.That(secondTypeSubtype?.Description, Is.Empty);
            CollectionAssert.AreEquivalent(new[] { P1 }, secondTypeSubtype?.Parameters.Select(p => p.Name));
            CollectionAssert.AreEquivalent(new[] { Pr1 }, secondTypeSubtype?.Properties.Select(p => p.Name));
            Assert.That(secondTypeSubtype?.Parameters.FirstOrDefault(p => p.Name == parameter?.Name), Is.SameAs(parameter));
            Assert.That(secondTypeSubtype?.Properties.FirstOrDefault(p => p.Name == property?.Name), Is.SameAs(property));
        });


    }
}
