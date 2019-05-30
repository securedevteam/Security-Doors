using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class DoorPassingViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Неверное время прохода")]
		[Display(Name = "Время прохода")]
		public DateTime PassingTime { get; set; } = DateTime.Now;

		[Display(Name = "Комментарий")]
		public string Comment { get; set; }
		
		[Required(ErrorMessage = "Неверный Id двери")]
		[Display(Name = "Id двери")]
		public int DoorId { get; set; }

		[Required(ErrorMessage = "Неверный Id человека")]
		[Display(Name = "Id человека")]
		public int PersonId { get; set; }
	}

    public class DoorPassingEditModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Неверное время прохода")]
		[Display(Name = "Время прохода")]
		public DateTime PassingTime { get; set; } = DateTime.Now;

		[Display(Name = "Комментарий")]
		public string Comment { get; set; }

		[Required(ErrorMessage = "Неверный Id двери")]
		[Display(Name = "Id двери")]
		public int DoorId { get; set; }

		[Required(ErrorMessage = "Неверный Id человека")]
		[Display(Name = "Id человека")]
		public int PersonId { get; set; }
	}
}
