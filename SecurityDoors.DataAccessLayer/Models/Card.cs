using System.Collections.Generic;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Карточка сотрудника.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Id карты.
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Уникальный номер.
		/// </summary>
		public string UniqueNumber { get; set; }

		/// <summary>
		/// Статус.
		/// </summary>
		public int Status { get; set; }

        /// <summary>
		/// Уровень.
		/// </summary>
		public int Level { get; set; }

        /// <summary>
		/// Нахождение.
		/// </summary>
		public bool Location { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        public virtual ICollection<DoorPassing> DoorPassings { get; set; }

        public Person Person { get; set; }
	}
}
