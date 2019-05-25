using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecurityDoors.DataAccessLayer.Models
{
	public class DoorPassing
	{
		public int Id { get; set; }
		[Required]
		public DateTime PassingTime { get; set; } = DateTime.Now;
		[Required]
		public int DoorId { get; set; }
		public virtual Door Door { get; set; }
		[Required]
		public int PersonId { get; set; }
		public virtual Person Person { get; set; }
	}
}
