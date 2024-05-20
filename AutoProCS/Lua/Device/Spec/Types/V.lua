local V = {
    name = 'V',
    description = 'Клапан',
    subtypes = {},
}

V.subtypes = {
    [ 1 ] = {
        name = 'V_DO1',
        description = 'Клапан с одним каналом управления',
        channels = {
            DO = {},
        },
    },

    [ 2 ] = {
        name = 'V_DO2',
        description = 'Клапан с двумя каналами управления',
        channels = {
            DO = { 'Открыт', 'Закрыт' },
        },
    },

    [ 3 ] = {
        name = 'V_DO1_DI1_FB_OFF',
        channels = {
            DI = {},
            DO = {},
        },
        parameters = {
            Parameters.P_ON_TIME,
            Parameters.P_FB,
        }
    },
}
-- return V
----------------------------
----------------------------
--[[
Devices.V = {
    name = "V",

}

Devices.V.subtypes = {
    V_DO1 = {
        description = 'Клапан с одним каналом управления',
        channels = {
            DO = {},
        },
    },

    V_DO2 = {
        description = 'Клапан с двумя каналами управления',
        channels = {
            DO = { 'Открыт', 'Закрыт' },
        },
    },

    V_DO1_DI1_FB_OFF = {
        channels = {
            DI = {},
            DO = {},
        },
        parameters = {
            Parameters.P_ON_TIME,
            Parameters.P_FB,
        }
    }
}
]]

return V