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
        //[Required(ErrorMessage = "Неверный уникальный номер")]
        [Display(Name = "Уникальный номер")]
        public string UniqueNumber { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        [Required(ErrorMessage = "Неверный статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        [Required(ErrorMessage = "Неверный уровень")]
        [Display(Name = "Уровень")]
        public string Level { get; set; }

        /// <summary>
        /// Нахождение.
        /// </summary>
        [Required(ErrorMessage = "Неверно указано нахождение")]
        [Display(Name = "Нахождение")]
        public string Location { get; set; }

        /// <summary>
        /// Аккаунт сотрудника.
        /// </summary>
        [Display(Name = "Аккаунт сотрудника")]
        public string UserAccount { get; set; }
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
        /// Аккаунт сотрудника.
        /// </summary>
        [Display(Name = "Аккаунт сотрудника")]
        public string UserAccount { get; set; }
    }
}
