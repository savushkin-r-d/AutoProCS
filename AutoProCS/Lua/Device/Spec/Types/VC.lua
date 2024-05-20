local VC = {
    name = 'VC',
    description = 'Управляемый Клапан',
    subtypes = {},
}

VC.subtypes = {

    [ 1 ] = {
        name = 'VC',
        description = 'Аналоговый клапан',
        channels = {
            AO = {},
        },
    },

    [ 2 ] = {
        name = 'VC_IOLINK',
        description = 'IO-Link аналоговый клапан',
        channels = {
            AO = {},
            AI = {},
        },
    },

    [ 3 ] = {
        name = 'VC_VIRT',
        description = 'Виртуальный аналоговый клапан (без привязки к модулям)',
    },
}

return VC