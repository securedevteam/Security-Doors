using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель двери для просмотра.
    /// </summary>
	public class DoorViewModel : DoorEditModel
    {
        /// <summary>
        /// Уровень.
        /// </summary>
		[Required(ErrorMessage = "InvalidLevel")]
        [Display(Name = "Level")]
        public string Level { get; set; }

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
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Required(ErrorMessage = "InvalidTitle")]
        [Display(Name = "Title")]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
		[Required(ErrorMessage = "InvalidDescription")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Статус карточки.
        /// </summary>
        [Required(ErrorMessage = "InvalidStatus")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        /// <summary>
		/// Комментарий.
		/// </summary>
        //[Required(ErrorMessage = "Неверный комментарий")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
