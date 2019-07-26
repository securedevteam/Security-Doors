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
        [Required(ErrorMessage = "Неверная электронная почта")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        /// <summary>
        /// Тип отчета.
        /// </summary>
        [Required(ErrorMessage = "Неверный тип отчета")]
        [Display(Name = "Тип отчета")]
        public string Type { get; set; }

        /// <summary>
        /// Заголовок документа.
        /// </summary>
        [Required(ErrorMessage = "Неверный заголовок документа")]
        [Display(Name = "Заголовок документа")]
        public string Header { get; set; }

        /// <summary>
        /// Описание таблицы.
        /// </summary>
        [Display(Name = "Описание таблицы (необязательно)")]
        public string Description { get; set; }

        /// <summary>
        /// Нижний колонтитул.
        /// </summary>
        [Required(ErrorMessage = "Неверный нижний колонтитул")]
        [Display(Name = "Нижний колонтитул")]
        public string Footer { get; set; }
    }
}
