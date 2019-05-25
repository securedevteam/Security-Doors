using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс карты.
    /// </summary>
    public interface ICardRepository : IDisposable
    {
        /// <summary>
        ///  Коллекция карт.
        /// </summary>
        /// <returns>Список карт.</returns>
        IEnumerable<Card> GetCardsList();

        /// <summary>
        ///  Получить карту.
        /// </summary>
        /// <param name="id">идентификатор карты.</param>
        /// <returns>Карта.</returns>
        Card GetCardById(int id);

        /// <summary>
        ///  Создать карту.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Create(Card item);

        /// <summary>
        ///  Обновить карту.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Card item);

        /// <summary>
        ///  Удалить карту.
        /// </summary>
        /// <param name="id">идентификатор карты.</param>
        void Delete(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Save(Card item);
    }
}
