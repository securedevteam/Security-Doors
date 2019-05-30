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

        [Required(ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Комментарий")]
		public string Comment { get; set; }
		
		[Required(ErrorMessage = "Неверное название двери")]
		[Display(Name = "Дверь")]
		public string Door { get; set; }

		[Required(ErrorMessage = "Неверный уникальный номер карточки")]
		[Display(Name = "Уникальный номер карточки")]
		public string Card { get; set; }
	}

    public class DoorPassingEditModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Неверное время прохода")]
        [Display(Name = "Время прохода")]
        public DateTime PassingTime { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Неверное название двери")]
        [Display(Name = "Дверь")]
        public string Door { get; set; }

        [Required(ErrorMessage = "Неверный уникальный номер карточки")]
        [Display(Name = "Уникальный номер карточки")]
        public string Card { get; set; }
    }
}
