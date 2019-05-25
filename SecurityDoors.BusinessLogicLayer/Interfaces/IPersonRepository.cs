using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс сотрудник.
    /// </summary>
    public interface IPersonRepository : IDisposable
    {
        /// <summary>
        /// Коллекция сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        IEnumerable<Person> GetPeopleList();

        /// <summary>
        /// Получить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор пользователя.</param>
        /// <returns>Сотрудник.</returns>
        Person GetPersonById(int id);

        /// <summary>
        /// Создать сотрудника.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Create(Person item);

        /// <summary>
        /// Обновить сотрудника.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Person item);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор пользователя.</param>
        void Delete(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Save(Person item);
    }
}
