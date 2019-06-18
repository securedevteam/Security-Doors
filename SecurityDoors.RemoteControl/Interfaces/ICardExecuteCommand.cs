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
        void AddCard();

        /// <summary>
        /// Получить данные о карте.
        /// </summary>
        void PrintCardById();

        /// <summary>
        /// Удалить выбранную карту.
        /// </summary>
        void DeleteCardById();

        /// <summary>
        /// Вывести список карт.
        /// </summary>
        Task PrintListOfCards();
    }
}
