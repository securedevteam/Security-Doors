using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель карты для просмотра.
    /// </summary>
    public class CardViewModel : CardEditModel
    {
        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
        //[Required(ErrorMessage = "Неверный уникальный номер")]
        [Display(Name = "UniqueNumber")]
        public string UniqueNumber { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        [Required(ErrorMessage = "InvalidLevel")]
        [Display(Name = "Level")]
        public string Level { get; set; }

        /// <summary>
        /// Нахождение.
        /// </summary>
        [Required(ErrorMessage = "InvalidLocation")]
        [Display(Name = "Location")]
        public string Location { get; set; }
    }

    /// <summary>
    /// Модель карты для изменения.
    /// </summary>
    public class CardEditModel
    {
        /// <summary>
        /// Id карты.
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Статус карточки.
        /// </summary>
        [Required (ErrorMessage = "InvalidStatus")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// Аккаунт сотрудника.
        /// </summary>
        [Display(Name = "UserAccount")]
        public string UserAccount { get; set; }
    }
}
