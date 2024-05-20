namespace AutoProCS.IO;

/// <summary>
/// Тип канала/клеммы ввода-вывода
/// </summary>
[Flags]
public enum IOType
{
    AO = 0b_0001,
    AI = 0b_0010,
    DO = 0b_0100,
    DI = 0b_1000,

    AOAI = AO | AI,
    DODI = DO | DI,

    AOAIDODI = AOAI | DODI,
}