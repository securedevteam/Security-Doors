using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель двери для просмотра.
    /// </summary>
	public class DoorViewModel
	{
        /// <summary>
        /// Id двери.
        /// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Required(ErrorMessage = "Неверное название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
		[Required(ErrorMessage = "Неверное описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
		[Required(ErrorMessage = "Неверный уровень")]
        [Display(Name = "Уровень")]
        public string Level { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        [Required(ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        /// <summary>
		/// Комментарий.
		/// </summary>
        //[Required(ErrorMessage = "Неверный комментарий")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        /// <summary>
        /// Список доступных карт.
        /// </summary>
        //[Display(Name = "Список доступных уникальных номеров карт")]
        public List<string> AvailableCards { get; set; }
    }

    /// <summary>
    /// Модель двери для изменения.
    /// </summary>
	public class DoorEditModel
	{
        /// <summary>
        /// Id двери.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Required(ErrorMessage = "Неверное название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
		[Required(ErrorMessage = "Неверное описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Статус карточки.
        /// </summary>
        [Required(ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        /// <summary>
		/// Комментарий.
		/// </summary>
        //[Required(ErrorMessage = "Неверный комментарий")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}
