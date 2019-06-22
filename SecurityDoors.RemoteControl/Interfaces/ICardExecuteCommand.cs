using System.Threading.Tasks;

namespace SecurityDoors.RemoteControl.Interfaces
{
    /// <summary>
    /// Интерфейс для управления дверями через консольные команды.
    /// </summary>
    interface ICardExecuteCommand
    {
        /// <summary>
        /// Добавить новую карту.
        /// </summary>
        Task AddCardAsync();

        /// <summary>
        /// Получить данные о карте.
        /// </summary>
        Task PrintCardByIdAsync();

        /// <summary>
        /// Удалить выбранную карту.
        /// </summary>
        Task DeleteCardByIdAsync();

        /// <summary>
        /// Вывести список карт.
        /// </summary>
        Task PrintListOfCardsAsync();
    }
}
