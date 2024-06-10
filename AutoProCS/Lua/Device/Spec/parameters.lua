UnitFormat = {
    Empty = "{0}";
    Boolean = "{0:Да;-;Нет}";
    Seconds = "{0} c";
    Milliseconds = "{0} мс";
    Meters = "{0} м";
    Kilograms = "{0} кг";
    Bars = "{0} бар";
    RKP = "{0} мВ/В";
    Percentages = "{0} %";
    DegreesCelsius = "{0} °C";
    CubicMeterPerHour = "{0} м3/ч";
}

local Parameters = {
    P_NOMINAL_W = {
        description = "Номинальная нагрузка",
        unit = UnitFormat.Kilograms,
    },
    P_RKP = {
        description = "Рабочий коэффициент передачи",
        unit = UnitFormat.RKP,
    },
    P_C0 = {
        description = "Сдвиг нуля"
    },
    P_DT = {
        description = "Время порогового фильтра",
        unit = UnitFormat.Milliseconds,
    },
    P_ON_TIME = {
        description = "Время включения",
        unit = UnitFormat.Milliseconds,
    },
    P_OFF_TIME = {
        description = "Время выключения",
        unit = UnitFormat.Milliseconds,
    },
    P_FB = {
        description = "Обратная связь",
        unit = UnitFormat.Boolean,
    },
    P_ERR = {
        description = "Аварийное значение"
    },
    P_MIN_V = {
        description = "Мин. значение"
    },
    P_MAX_V = {
        description = "Мак. значение"
    },
    P_MAX_P = {
        description = "Давление датчика",
        unit = UnitFormat.Bars,
    },
    P_R = {
        description = "Радиус танка",
        unit = UnitFormat.Meters,
    },
    P_H_CONE = {
        description = "Высота конической части танка",
        unit = UnitFormat.Meters,
    },
    P_H_TRUNC = {
        description = "Высота усеченной части танка",
        unit = UnitFormat.Meters,
    },
    P_MIN_F = {
        description = "Мин. значение для потока"
    },
    P_MAX_F = {
        description = "Макс. значение для потока"
    },
    P_k = {
        description = "Коэффициент усиления"
    },
    P_Ti = {
        description = "Время интегрирования"
    },
    P_Td = {
        description = "Время дифференцирования"
    },
    P_dt = {
        description = "Интервал расчета",
        unit = UnitFormat.Milliseconds,
    },
    P_max = {
        description = "Макс. входное значение"
    },
    P_min = {
        description = "Мин. входное значение"
    },
    P_acceleration_time = {
        description = "Время выхода",
        unit = UnitFormat.Seconds,
    },
    P_is_manual_mode = {
        description = "Ручной режим",
        unit = UnitFormat.Boolean,
    },
    P_U_manual = {
        description = "Заданное ручное значение",
        unit = UnitFormat.Percentages,
    },
    P_k2 = {
        description = "Коэффициент усиления 2"
    },
    P_Ti2 = {
        description = "Время интегрирования 2"
    },
    P_Td2 = {
        description = "Время дифференцирования 2"
    },
    P_out_max = {
        description = "Макс. выходное значение"
    },
    P_out_min = {
        description = "Мин. выходное значение"
    },
    P_is_reverse = {
        description = "Выход обратного действия 100-0",
        unit = UnitFormat.Boolean,
    },
    P_is_zero_start = {
        description = "Выход прямого действия 0-100",
        unit = UnitFormat.Boolean
    },
    P_SHAFT_DIAMETER = {
        description = "Диаметр вала",
        unit = UnitFormat.Meters,
    },
    P_TRANSFER_RATIO = {
        description = "Передаточное число"
    },
    P_READY_TIME = {
        description = "Предельное время отсутсвя готовности к работе",
        unit = UnitFormat.Seconds,
    },
    P_ERR_MIN_FLOW = {
        description = "Ошибка счета импульсов"
    },
}

-- Дублирование ключа (названия параметра) в таблицу
for parameter_name in pairs(Parameters) do
    Parameters[parameter_name].name = parameter_name
end

return Parameters