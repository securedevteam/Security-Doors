using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ReportViewModels
{
    /// <summary>
    /// Частичная модель для дверных проходов.
    /// </summary>
    public class ReportDoorPassingViewModel : ReportDataViewModel
    {
        /// <summary>
        /// С (дата и время).
        /// </summary>
        [Required(ErrorMessage = "Неверные данные")]
        [Display(Name = "С (дата и время)")]
        public DateTime Start { get; set; }

        /// <summary>
        /// По (дата и время).
        /// </summary>
        [Required(ErrorMessage = "Неверные данные")]
        [Display(Name = "По (дата и время)")]
        public DateTime End { get; set; }

        /// <summary>
        /// Уникальный номер карточки.
        /// </summary>
        [Display(Name = "Уникальный номер карточки")]
        public string Card { get; set; }
    }
}
