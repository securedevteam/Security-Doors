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
        /// Уровень 1 - Сотрудник.
        /// </summary>
        IsEmployee = 1,

        /// <summary>
        /// Уровень 2 - Администратор.
        /// </summary>
        IsAdministrator = 2,

        /// <summary>
        /// Уровень 3 - Управляющий.
        /// </summary>
        IsManager = 3
    }
}
