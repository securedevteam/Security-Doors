using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.DataAccessLayer.Models
{
    class Card
    {
        /// <summary>
        /// Id карты
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Уникальный номер карты
        /// </summary>
        public string UniqueNumber { get; set; }
        /// <summary>
        /// Действительна ли карта
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
