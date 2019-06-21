namespace SecurityDoors.Core.Logger
{
    /// <summary>
    /// Основные статусы логгера.
    /// </summary>
    public class LoggingEvents
    {
        /// <summary>
        /// Успешная генерация элементов.
        /// </summary>
        public const int GenerateItems = 1000;

        /// <summary>
        /// Успешный лист объектов.
        /// </summary>
        public const int ListItems = 1001;

        /// <summary>
        /// Успешное получение объекта.
        /// </summary>
        public const int GetItem = 1002;

        /// <summary>
        /// Успешная вставка объекта.
        /// </summary>
        public const int InsertItem = 1003;

        /// <summary>
        /// Успешное изменение объекта.
        /// </summary>
        public const int EditItem = 1004;

        /// <summary>
        /// Успешное удаление объекта.
        /// </summary>
        public const int DeleteItem = 1005;

        /// <summary>
        /// Успешное создание объекта.
        /// </summary>
        public const int CreateItem = 1006;

        /// <summary>
        /// Успешное получение информации об объекте.
        /// </summary>
        public const int InformationItem = 1007;



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



        /// <summary>
        /// Запрашиваем объект не найден.
        /// </summary>
        public const int GetItemNotFound = 4000;

        /// <summary>
        /// Запрашиваем объект для обновления не найден.
        /// </summary>
        public const int UpdateItemNotFound = 4001;

        /// <summary>
        /// Запрашиваемые объекты не найдены.
        /// </summary>
        public const int ListItemsNotFound = 4002;

        /// <summary>
        /// Запрашиваем объект для создания не найден.
        /// </summary>
        public const int CreateItemNotFound = 4003;

        /// <summary>
        /// Запрашиваем объект для получения информации не найден.
        /// </summary>
        public const int InformationItemNotFound = 4004;

        /// <summary>
        /// Запрашиваем объект для редактирования не найден.
        /// </summary>
        public const int EditItemNotFound = 4005;

        /// <summary>
        /// Запрашиваем объект для удаления не найден.
        /// </summary>
        public const int DeleteItemNotFound = 4006;

        /// <summary>
        /// Запрашиваем пользователь для создания не найден.
        /// </summary>
        public const int CreateAccountNotFound = 4003;



        /// <summary>
        /// Запрашиваемые объекты не найдены.
        /// </summary>
        public const int ListUsersItemsNotFound = 5002;

        /// <summary>
        /// Запрашиваем пользователь для редактирования не найден.
        /// </summary>
        public const int EditUserNotFound = 5005;

        /// <summary>
        /// Авторизация пользователя завершилась с ошибкой.
        /// </summary>
        public const int LoginUserItemNotFound = 6001;

        /// <summary>
        /// Регистрация пользователя завершилась с ошибкой.
        /// </summary>
        public const int RegisterUserItemNotFound = 6000;
    }
}
