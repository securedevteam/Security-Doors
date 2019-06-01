namespace SecurityDoors.Core.Enums
{
    /// <summary>
    /// Перечисление уровней карты.
    /// </summary>
    public enum CardLevels
    {
        /// <summary>
        /// Уровень 0 - Гостевой.
        /// </summary>
        IsGuest = 0,

        /// <summary>
        /// Уровень 1 - Стажер.
        /// </summary>
        IsIntern = 1,

        /// <summary>
        /// Уровень 2 - Сотрудник.
        /// </summary>
        IsEmployee = 2,

        /// <summary>
        /// Уровень 3 - Администратор.
        /// </summary>
        IsAdministrator = 3,

        /// <summary>
        /// Уровень 4 - Управляющий.
        /// </summary>
        IsManager = 4
    }
}
