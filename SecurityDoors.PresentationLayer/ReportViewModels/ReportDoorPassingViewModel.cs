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
        [Required(ErrorMessage = "WrongData")]
        [Display(Name = "FromDateTime")]
        public DateTime Start { get; set; }

        /// <summary>
        /// По (дата и время).
        /// </summary>
        [Required(ErrorMessage = "WrongData")]
        [Display(Name = "ToDateTime")]
        public DateTime End { get; set; }

        /// <summary>
        /// Уникальный номер карточки.
        /// </summary>
        [Display(Name = "UniqueNumber")]
        public string Card { get; set; }
    }
}
