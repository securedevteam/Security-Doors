using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель карты для просмотра.
    /// </summary>
    public class CardViewModel
    {
        /// <summary>
        /// Id карты.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
        [Required(ErrorMessage = "Неверный уникальный номер")]
        [Display(Name = "Уникальный номер")]
        public string UniqueNumber { get; set; }

        /// <summary>
        /// Статус.
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

    /// <summary>
    /// Модель карты для изменения.
    /// </summary>
    public class CardEditModel
    {
        /// <summary>
        /// Id карты.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Статус карточки.
        /// </summary>
        [Required (ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}
