using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<IEnumerable<Person>> GetPeopleListAsync();

        /// <summary>
        /// Получить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор пользователя.</param>
        /// <returns>Сотрудник.</returns>
        Task<Person> GetPersonByIdAsync(int id);

        /// <summary>
        /// Создать сотрудника.
        /// </summary>
        /// <param name="item">элемент.</param>
        Task CreateAsync(Person item);

        /// <summary>
        /// Обновить сотрудника.
        /// </summary>
        /// <param name="item">элемент.</param>
        void Update(Person item);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор пользователя.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
        Task SaveAsync(Person item);
    }
}
