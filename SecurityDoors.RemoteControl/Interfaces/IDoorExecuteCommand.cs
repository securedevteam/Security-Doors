namespace SecurityDoors.RemoteControl.Interfaces
{
    /// <summary>
    /// Интерфейс для управления дверями через консольные команды.
    /// </summary>
    interface IDoorExecuteCommand
    {
        /// <summary>
        /// Добавить новую дверь.
        /// </summary>
        void AddDoor();

        /// <summary>
        /// Получить данные о двери.
        /// </summary>
        void PrintDoorById();

        /// <summary>
        /// Удалить выбранную дверь.
        /// </summary>
        void DeleteDoorById();

        /// <summary>
        /// Вывести список дверей.
        /// </summary>
        void PrintListOfDoors();
    }
}
