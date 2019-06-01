namespace SecurityDoors.Core.Constants
{
    /// <summary>
    /// Константы карты.
    /// </summary>
    public class CardConstants
    {
        /// <summary>
        /// Закрыта.
        /// </summary>
        public const string IsClosed = "Закрыта";

        /// <summary>
        /// Активна.
        /// </summary>
        public const string IsActive = "Активна";

        /// <summary>
        /// Утеряна.
        /// </summary>
        public const string IsLost = "Утеряна";

        /// <summary>
        /// Приостановлена.
        /// </summary>
        public const string IsSuspended = "Приостановлена";

        /// <summary>
        /// Уровень 0 - Гостевой.
        /// </summary>
        public const string IsGuest = "Гость";

        /// <summary>
        /// Уровень 1 - Стажер.
        /// </summary>
        public const string IsIntern = "Стажер";

        /// <summary>
        /// Уровень 2 - Сотрудник.
        /// </summary>
        public const string IsEmployee = "Сотрудник";

        /// <summary>
        /// Уровень 3 - Администратор.
        /// </summary>
        public const string IsAdministrator = "Администратор";

        /// <summary>
        /// Уровень 4 - Управляющий.
        /// </summary>
        public const string IsManager = "Управляющий";

        /// <summary>
        /// Вход.
        /// </summary>
        public const string Entrance = "В здании";

        /// <summary>
        /// Выход.
        /// </summary>
        public const string Exit = "За пределами здания";

        /// <summary>
        /// Вход.
        /// </summary>
        public const bool IsEntrance = true;

        /// <summary>
        /// Выход.
        /// </summary>
        public const bool IsExit = false;
    }
}
