using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс проход.
    /// </summary>
    public interface IDoorPassingRepository : IDisposable
    {
        /// <summary>
        /// Коллекция проходов.
        /// </summary>
        /// <returns>Список проходов.</returns>
        IEnumerable<DoorPassing> GetDoorsPassingList();

        /// <summary>
        /// Получить проход.
        /// </summary>
        /// <param name="id">идентификатор прохода.</param>
        /// <returns>Проход.</returns>
        DoorPassing GetDoorPassingById(int id);

        /// <summary>
        /// Создать проход.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Create(DoorPassing item);

        /// <summary>
        /// Обновить проход.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(DoorPassing item);

        /// <summary>
        /// Удалить проход.
        /// </summary>
        /// <param name="id">идентификатор прохода.</param>
        void Delete(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Save(DoorPassing item);
    }
}
