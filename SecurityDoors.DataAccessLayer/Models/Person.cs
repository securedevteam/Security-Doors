using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.DataAccessLayer.Models
{
    class Person
    {
        /// <summary>
        /// Id сотрудника
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// Паспорт сотрудника
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public int DoorId { get; set; }
        public Door Door { get; set; }

        ICollection<Card> Cards { get; set; }
    }
}
