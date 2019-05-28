using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель для просмотра.
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
        [Required(ErrorMessage = "Уникальный номер не указан")]
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
        [Required(ErrorMessage = "Неверный комментарий")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }

    /// <summary>
    /// Модель для изменения.
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
        [Required(ErrorMessage = "Неверный комментарий")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}
