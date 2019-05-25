using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    ///  Интерфейс пользователя.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        ///  Коллекция пользователей.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Person> GetPeopleList();

        /// <summary>
        ///  Получить пользователя.
        /// </summary>
        /// <param name="id">идентификатор пользователя.</param>
        /// <returns></returns>
        Person GetPersonById(int id);

        /// <summary>
        ///  Создать пользователя.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Create(Person item);

        /// <summary>
        ///  Обновить пользователя.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Person item);

        /// <summary>
        ///  Удалить пользователя.
        /// </summary>
        /// <param name="id">идентификатор пользователя.</param>
        void Delete(int id);

        /// <summary>
        ///  Сохранить изменения.
        /// </summary>
        void Save();
    }
}
