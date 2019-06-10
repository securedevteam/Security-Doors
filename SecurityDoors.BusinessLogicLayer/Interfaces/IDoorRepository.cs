using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс дверь.
    /// </summary>
    public interface IDoorRepository : IDisposable
    {
        /// <summary>
        /// Коллекция дверей.
        /// </summary>
        /// <returns>Список дверей.</returns>
        IEnumerable<Door> GetDoorsList();

        /// <summary>
        /// Получить дверь.
        /// </summary>
        /// <param name="id">идентификатор двери.</param>
        /// <returns>Дверь.</returns>
        Door GetDoorById(int id);

        /// <summary>
        /// Получить дверь по названию.
        /// </summary>
        /// <param name="item">название.</param>
        /// <returns>Дверь.</returns>
        Door GetDoorByName(string item);

        /// <summary>
        /// Создать дверь.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Create(Door item);

        /// <summary>
        /// Обновить дверь.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Door item);

        /// <summary>
        /// Удалить дверь.
        /// </summary>
        /// <param name="id">идентификатор двери.</param>
        void Delete(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Save(Door item);
    }
}
