using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс карта.
    /// </summary>
    public interface ICardRepository : IDisposable
    {
        /// <summary>
        /// Коллекция карт.
        /// </summary>
        /// <returns>Список карт.</returns>
        Task<IEnumerable<Card>> GetCardsListAsync();

        /// <summary>
        /// Получить карту по Id.
        /// </summary>
        /// <param name="id">идентификатор карты.</param>
        /// <returns>Карта.</returns>
        Task<Card> GetCardByIdAsync(int id);

        /// <summary>
        /// Получить карту по уникальному номеру.
        /// </summary>
        /// <param name="item">уникальный номер.</param>
        /// <returns>Карта.</returns>
        Task<Card> GetCardByUniqueNumberAsync(string item);

        /// <summary>
        /// Создать карту.
        /// </summary>
        /// <param name="item">элемент.</param>
		Task CreateAsync(Card item);

        /// <summary>
        /// Обновить карту.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Card item);

        /// <summary>
        /// Удалить карту.
        /// </summary>
        /// <param name="id">идентификатор карты.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        Task SaveAsync(Card item);
    }
}
