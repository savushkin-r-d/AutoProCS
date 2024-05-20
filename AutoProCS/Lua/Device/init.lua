package.path =  './lua/device/spec/?.lua;' ..
                './lua/device/spec/types/?.lua;' ..
                package.path

local devices = require 'devices'

--- @diagnostic disable: undefined-doc-name, undefined-field

--- Инициализация спецификации устройств
--- @param devicesSpecificationBuilder AutoProCS.DeviceDefinitionManager.ILuaBuilder
function Init(devicesSpecificationBuilder)
    -- инициализация спецификации типов устройств
    for type_id, type in pairs(devices) do
        local TypeBuilder = devicesSpecificationBuilder:AddType(type.name, type_id, type.description or '');
        -- Инициализация спецификации подтипов
        for subtype_id, subtype in pairs(type.subtypes) do
            local SubtypeBuilder = TypeBuilder:AddSubtype(subtype.name, subtype_id, subtype.description or '')

            -- Инициализация спецификации параметров           
            for _, parameter in ipairs(subtype.parameters or {}) do
                SubtypeBuilder:AddParameter(devicesSpecificationBuilder:FindOrAddParameter(parameter.name, parameter.description or '', parameter.unit or UnitFormat.Empty))
            end

            -- Инициализация спецификации свойств
            for _, property in ipairs(subtype.properties or {}) do
                SubtypeBuilder:AddProperty(devicesSpecificationBuilder:FindOrAddProperty(property.name, property.description or ''))
            end

            -- Инициализация спецификации каналов ввода/вывода
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