using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.DataAccessLayer.Models
{
    class Door
    {
        /// <summary>
        /// Id контроллера
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата и время прохода через контроллер
        /// </summary>
        public DateTime PersonEnter { get; set; } = DateTime.Now;
        /// <summary>
        /// Вход/выход
        /// </summary>
        public bool InOut { get; set; }

        ICollection<Person> People { get; set; }
    }
}
