namespace SecurityDoors.Core.Logger.Events
{
    /// <summary>
    /// Основные неуспешные статусы логгера.
    /// </summary>
    public class CommonUnsuccessfulEvents
    {
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
    }
}
