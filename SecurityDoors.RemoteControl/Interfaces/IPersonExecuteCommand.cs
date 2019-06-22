using System.Threading.Tasks;

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
        Task AddPersonAsync();

        /// <summary>
        /// Получить данные о сотруднике.
        /// </summary>
        Task PrintPersonByIdAsync();

        /// <summary>
        /// Удалить выбранного сотрудника.
        /// </summary>
        Task DeletePersonByIdAsync();

        /// <summary>
        /// Вывести список сотрудников.
        /// </summary>
        Task PrintListOfPeopleAsync();
    }
}
