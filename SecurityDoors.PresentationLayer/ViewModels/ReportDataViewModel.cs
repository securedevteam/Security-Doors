using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class ReportDataViewModel
    {
        [Required(ErrorMessage = "Неверный электронный адрес")]
        [Display(Name = "Электронный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Неверный тип отчета")]
        [Display(Name = "Тип отчета")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Неверный заголовок документа")]
        [Display(Name = "Заголовок документа")]
        public string Header { get; set; }

        [Display(Name = "Описание таблицы (необязательно)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Неверный нижний колонтитул")]
        [Display(Name = "Нижний колонтитул")]
        public string Footer { get; set; }

        // TODO: Добавить сначала DoorPassing параметры, а потом остальные при необходимости
        // Может быть сделать вообще родительской моделью? А остальные наследовать от нее (TODO: Delete me)
    }
}
