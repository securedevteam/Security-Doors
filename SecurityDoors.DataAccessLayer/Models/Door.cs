﻿using System;
using System.Collections.Generic;

namespace SecurityDoors.DataAccessLayer.Models
{
	///TODO: Запретить NULL значения
	/// <summary>
	/// Модель двери.
	/// </summary>
	public class Door
    {
        /// <summary>
        /// Id дверного контроллера.
        /// </summary>
        public int Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<DoorPassing> DoorPassings { get; set; }
		public Door()
		{
			DoorPassings = new List<DoorPassing>();
		}
	}
}
