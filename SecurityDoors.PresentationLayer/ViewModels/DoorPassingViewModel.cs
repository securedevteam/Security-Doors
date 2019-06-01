using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель дверного контроллера для просмотра.
    /// </summary>
    public class DoorPassingViewModel
	{
        /// <summary>
        /// Id дверного контроллера.
        /// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Время прохода.
        /// </summary>
		[Required(ErrorMessage = "Неверное время прохода")]
		[Display(Name = "Время прохода")]
		public DateTime PassingTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Статус
        /// </summary>
        [Required(ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [Display(Name = "Комментарий")]
		public string Comment { get; set; }
		
        /// <summary>
        /// Название двери.
        /// </summary>
		[Required(ErrorMessage = "Неверное название двери")]
		[Display(Name = "Дверь")]
		public string Door { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
		[Required(ErrorMessage = "Неверный уникальный номер карточки")]
		[Display(Name = "Уникальный номер карточки")]
		public string Card { get; set; }
	}

    /// <summary>
    /// Модель дверного контроллера для изменений.
    /// </summary>
    public class DoorPassingEditModel
	{
        /// <summary>
        /// Id дверного контроллера.
        /// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [Required(ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}
