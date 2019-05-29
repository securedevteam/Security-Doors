using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class DoorPassingViewModel:DoorPassing
	{
		[Required]
		public new int Id { get; set; }
		[Required]
		public new DateTime PassingTime { get; set; } = DateTime.Now;
		[Required]
		public new string Comment { get; set; }
		[Required]
		public new int DoorId { get; set; }
		[Required]
		public new int PersonId { get; set; }
	}

    public class DoorPassingEditModel:DoorPassing
	{
		[Required]
		public new int Id { get; set; }
		[Required]
		public new DateTime PassingTime { get; set; } = DateTime.Now;
		[Required]
		public new string Comment { get; set; }
		[Required]
		public new int DoorId { get; set; }
		[Required]
		public new int PersonId { get; set; }
	}
}
