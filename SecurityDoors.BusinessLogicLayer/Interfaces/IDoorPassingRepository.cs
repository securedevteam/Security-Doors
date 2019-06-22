using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<IEnumerable<DoorPassing>> GetDoorsPassingListAsync();

        /// <summary>
        /// Получить проход.
        /// </summary>
        /// <param name="id">идентификатор прохода.</param>
        /// <returns>Проход.</returns>
        Task<DoorPassing> GetDoorPassingByIdAsync(int id);

        /// <summary>
        /// Создать проход.
        /// </summary>
        /// <param name="item">элемент.</param>
        Task CreateAsync(DoorPassing item);

        /// <summary>
        /// Обновить проход.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(DoorPassing item);

        /// <summary>
        /// Удалить проход.
        /// </summary>
        /// <param name="id">идентификатор прохода.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        Task SaveAsync(DoorPassing item);
    }
}
