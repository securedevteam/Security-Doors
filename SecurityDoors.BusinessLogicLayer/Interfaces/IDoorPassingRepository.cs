using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    ///  Интерфейс прохода.
    /// </summary>
    public interface IDoorPassingRepository : IDisposable
    {
        /// <summary>
        ///  Коллекция проходов.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DoorPassing> GetDoorsPassingList();

        /// <summary>
        ///  Получить проход.
        /// </summary>
        /// <param name="id">идентификатор прохода.</param>
        /// <returns></returns>
        DoorPassing GetDoorPassingById(int id);

        /// <summary>
        ///  Создать проход.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Create(DoorPassing item);

        /// <summary>
        ///  Обновить проход.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(DoorPassing item);

        /// <summary>
        ///  Удалить проход.
        /// </summary>
        /// <param name="id">идентификатор прохода.</param>
        void Delete(int id);

        /// <summary>
        ///  Сохранить изменения.
        /// </summary>
        void Save();
    }
}
