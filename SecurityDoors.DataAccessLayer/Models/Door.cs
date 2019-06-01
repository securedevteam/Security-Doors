using System.Collections.Generic;

namespace SecurityDoors.DataAccessLayer.Models
{
	/// <summary>
	/// Модель двери.
	/// </summary>
	public class Door
    {
		/// <summary>
		/// Id двери.
		/// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
		public string Name { get; set; }
        
        /// <summary>
        /// Описание.
        /// </summary>
		public string Description { get; set; }

        /// <summary>
		/// Статус.
		/// </summary>
		public int Status { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

		public virtual ICollection<DoorPassing> DoorPassings { get; set; }
	}
}
