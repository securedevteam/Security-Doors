using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    ///  Интерфейс двери.
    /// </summary>
    public interface IDoorRepository : IDisposable
    {
        /// <summary>
        ///  Коллекция дверей.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Door> GetDoorsList();

        /// <summary>
        ///  Получить дверь.
        /// </summary>
        /// <param name="id">идентификатор двери.</param>
        /// <returns></returns>
        Door GetDoorById(int id);

        /// <summary>
        ///  Создать дверь.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Create(Door item);

        /// <summary>
        ///  Обновить дверь.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Door item);

        /// <summary>
        ///  Удалить дверь.
        /// </summary>
        /// <param name="id">идентификатор двери.</param>
        void Delete(int id);

        /// <summary>
        ///  Сохранить изменения.
        /// </summary>
        void Save();
    }
}
