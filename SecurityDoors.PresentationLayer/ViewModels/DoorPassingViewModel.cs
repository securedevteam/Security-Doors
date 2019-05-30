using System;
using System.ComponentModel.DataAnnotations;

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

		[Required(ErrorMessage = "Неверный Id сотрудника")]
		[Display(Name = "Id сотрудника")]
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

		[Required(ErrorMessage = "Неверный Id сотрудника")]
		[Display(Name = "Id сотрудника")]
		public int PersonId { get; set; }
	}
}
