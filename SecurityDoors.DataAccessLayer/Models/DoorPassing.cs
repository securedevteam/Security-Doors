using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecurityDoors.DataAccessLayer.Models
{
	public class DoorPassing
	{
		public int Id { get; set; }
		public DateTime PassingTime { get; set; } = DateTime.Now;

		public int DoorId { get; set; }
		public virtual Door Door { get; set; }
		public int PersonId { get; set; }
		public virtual Person Person { get; set; }
	}
}
