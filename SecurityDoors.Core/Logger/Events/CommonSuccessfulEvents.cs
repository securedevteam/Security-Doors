namespace SecurityDoors.Core.Logger.Events
{
    /// <summary>
    /// Основные успешные статусы логгера.
    /// </summary>
    public class CommonSuccessfulEvents
    {
        /// <summary>
        /// Успешная генерация объектов.
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
    }
}
