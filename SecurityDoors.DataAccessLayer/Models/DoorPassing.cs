using System;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Модель дверного контроллера.
    /// </summary>
	public class DoorPassing
	{
        /// <summary>
        /// Id дверного контроллера.
        /// </summary>
		public int Id { get; set; }
		
        /// <summary>
        /// Время прохода.
        /// </summary>
		public DateTime PassingTime { get; set; } = DateTime.Now;

        /// <summary>
		/// Статус.
		/// </summary>
		public int Status { get; set; }

        /// <summary>
		/// Нахождение.
		/// </summary>
		public bool Location { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string UserAccount { get; set; }  

        /// <summary>
        /// Id двери.
        /// </summary>
        public int DoorId { get; set; }

		public Door Door { get; set; }
		
        /// <summary>
        /// Id карточки.
        /// </summary>
		public int CardId { get; set; }

		public Card Card { get; set; }
	}
}
