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

		public virtual ICollection<DoorPassing> DoorPassings { get; set; }
		public Door()
		{
			DoorPassings = new List<DoorPassing>();
		}
	}
}
