using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<IEnumerable<Door>> GetDoorsListAsync();

        /// <summary>
        /// Получить дверь.
        /// </summary>
        /// <param name="id">идентификатор двери.</param>
        /// <returns>Дверь.</returns>
        Task<Door> GetDoorByIdAsync(int id);

        /// <summary>
        /// Получить дверь по названию.
        /// </summary>
        /// <param name="item">название.</param>
        /// <returns>Дверь.</returns>
        Task<Door> GetDoorByNameAsync(string item);

        /// <summary>
        /// Создать дверь.
        /// </summary>
        /// <param name="item">элемент.</param>
        Task CreateAsync(Door item);

        /// <summary>
        /// Обновить дверь.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Door item);

        /// <summary>
        /// Удалить дверь.
        /// </summary>
        /// <param name="id">идентификатор двери.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        Task SaveAsync(Door item);
    }
}
