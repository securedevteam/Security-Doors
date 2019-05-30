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
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }  

        /// <summary>
        /// Id двери.
        /// </summary>
        public int DoorId { get; set; }

		public Door Door { get; set; }
		
        /// <summary>
        /// Id сотрудника.
        /// </summary>
		public int PersonId { get; set; }

		public Person Person { get; set; }
	}
}
