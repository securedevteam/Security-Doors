namespace SecurityDoors.RemoteControl.Interfaces
{
    /// <summary>
    /// Интерфейс для управления сотрудниками через консольные команды.
    /// </summary>
    interface IPersonExecuteCommand
    {
        /// <summary>
        /// Добавить нового сотрудника.
        /// </summary>
        void AddPerson();

        /// <summary>
        /// Получить данные о сотруднике.
        /// </summary>
        void PrintPersonById();

        /// <summary>
        /// Удалить выбранного сотрудника.
        /// </summary>
        void DeletePersonById();

        /// <summary>
        /// Вывести список сотрудников.
        /// </summary>
        void PrintListOfPeople();
    }
}
