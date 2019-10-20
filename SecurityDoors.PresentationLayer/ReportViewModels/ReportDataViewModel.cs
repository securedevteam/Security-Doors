using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ReportViewModels
{
    /// <summary>
    /// Модель базовых данных для отчета для просмотра.
    /// </summary>
    public class ReportDataViewModel
    {
        /// <summary>
        /// Электронная почта.
        /// </summary>
        [Required(ErrorMessage = "InvalidEmail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Тип отчета.
        /// </summary>
        [Required(ErrorMessage = "InvalidReportType")]
        [Display(Name = "ReportType")]
        public string Type { get; set; }

        /// <summary>
        /// Заголовок документа.
        /// </summary>
        [Required(ErrorMessage = "InvalidLetterHeading")]
        [Display(Name = "LetterHeading")]
        public string Header { get; set; }

        /// <summary>
        /// Описание таблицы.
        /// </summary>
        [Display(Name = "TableDescription")]
        public string Description { get; set; }

        /// <summary>
        /// Нижний колонтитул.
        /// </summary>
        [Required(ErrorMessage = "InvalidDocumentHeader")]
        [Display(Name = "DocumentHeader")]
        public string Footer { get; set; }
    }
}
