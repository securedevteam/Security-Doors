namespace SecurityDoors.Core.Logger.Events
{
    /// <summary>
    /// Основные неуспешные статусы логгера для пользователя.
    /// </summary>
    public class UserUnsuccessfulEvents
    {
        /// <summary>
        /// Запрашиваемые объекты не найдены.
        /// </summary>
        public const int ListUsersItemsNotFound = 5002;

        /// <summary>
        /// Запрашиваем пользователь для редактирования не найден.
        /// </summary>
        public const int EditUserNotFound = 5005;

        /// <summary>
        /// Регистрация пользователя завершилась с ошибкой.
        /// </summary>
        public const int RegisterUserItemNotFound = 6000;

        /// <summary>
        /// Авторизация пользователя завершилась с ошибкой.
        /// </summary>
        public const int LoginUserItemNotFound = 6001;
    }
}
