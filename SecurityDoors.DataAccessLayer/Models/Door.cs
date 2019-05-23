using System;
using System.Collections.Generic;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Контроллер дверей.
    /// </summary>
    public class Door
    {
        /// <summary>
        /// Id дверного контроллера.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время прохода пользователя через контроллер.
        /// </summary>
        public DateTime PersonEnter { get; set; } = DateTime.Now;

        /// <summary>
        /// Вход/выход пользователя.
        /// </summary>
        public bool InOut { get; set; }

        ICollection<Person> People { get; set; }
    }
}
