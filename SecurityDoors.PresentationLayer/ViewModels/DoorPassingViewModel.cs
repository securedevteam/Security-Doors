using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель дверного контроллера для просмотра.
    /// </summary>
    public class DoorPassingViewModel : DoorPassingEditModel
    {
        /// <summary>
        /// Время прохода.
        /// </summary>
		[Required(ErrorMessage = "InvalidPassingTime")]
		[Display(Name = "PassingTime")]
		public DateTime PassingTime { get; set; } = DateTime.Now;
		
        /// <summary>
        /// Название двери.
        /// </summary>
		[Required(ErrorMessage = "InvalidDoorName")]
		[Display(Name = "DoorName")]
		public string Door { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
		[Required(ErrorMessage = "InvalidUniqueNumber")]
		[Display(Name = "UniqueNumber")]
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
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [Required(ErrorMessage = "InvalidStatus")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// Нахождение.
        /// </summary>
        [Display(Name = "Location")]
        public string Location { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [Display(Name = "Account")]
        public string UserAccount { get; set; }
    }
}
