namespace SecurityDoors.Core.Logger.Events
{
    /// <summary>
    /// Основные статусы логгера для пользователя.
    /// </summary>
    public class UserSuccessfulEvents
    {
        /// <summary>
        /// Успешный лист пользователей.
        /// </summary>
        public const int ListUsersItems = 2001;

        /// <summary>
        /// Успешная вставка нового пользователя.
        /// </summary>
        public const int InsertUserItem = 2003;

        /// <summary>
        /// Успешное удаление пользователя.
        /// </summary>
        public const int DeleteUserItem = 2005;

        /// <summary>
        /// Успешное изменение пользователя.
        /// </summary>
        public const int EditUserItem = 2004;

        /// <summary>
        /// Успешная регистрация пользователя.
        /// </summary>
        public const int RegisterUserItem = 3000;

        /// <summary>
        /// Успешное авторизация пользователя.
        /// </summary>
        public const int LoginUserItem = 3001;

        /// <summary>
        /// Успешный выход из аккаунта пользователя.
        /// </summary>
        public const int LogoffUserItem = 3002;
    }
}
