using System.Threading.Tasks;

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
        Task AddDoorAsync();

        /// <summary>
        /// Получить данные о двери.
        /// </summary>
        Task PrintDoorByIdAsync();

        /// <summary>
        /// Удалить выбранную дверь.
        /// </summary>
        Task DeleteDoorByIdAsync();

        /// <summary>
        /// Вывести список дверей.
        /// </summary>
        Task PrintListOfDoorsAsync();
    }
}
