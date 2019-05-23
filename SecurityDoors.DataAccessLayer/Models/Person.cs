using System.Collections.Generic;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// Паспорт.
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
