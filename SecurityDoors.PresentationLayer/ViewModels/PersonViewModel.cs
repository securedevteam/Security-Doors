using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель карты для просмотра.
    /// </summary>
    public class PersonViewModel
	{
        /// <summary>
        /// Id сотрудника.
        /// </summary>
		[Display(Name = "Id")]
		public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
		[Required(ErrorMessage = "InvalidName")]
		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
		[Display(Name = "SecondName")]
		public string SecondName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
		[Required(ErrorMessage = "InvalidLastName")]
		[Display(Name = "LastName")]
		public string LastName { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
		[Required(ErrorMessage = "InvalidGender")]
		[Display(Name = "Gender")]
		public string Gender { get; set; }

        /// <summary>
        /// Паспорт.
        /// </summary>
		[Required(ErrorMessage = "InvalidPassport")]
		[Display(Name = "Passport")]
		public string Passport { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
		[Display(Name = "Comment")]
		public string Comment { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
        [Required(ErrorMessage = "InvalidUniqueNumber")]
		[Display(Name = "UniqueNumber")]
		public string Card { get; set; }

        /// <summary>
        /// Список доступных карт.
        /// </summary>
        //[Display(Name = "Список доступных уникальных номеров карт")]
        public List<string> AvailableCards { get; set; }
    }

    public class PersonEditModel
	{
        /// <summary>
        /// Id сотрудника.
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
		[Required(ErrorMessage = "InvalidName")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
		[Display(Name = "SecondName")]
        public string SecondName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
		[Required(ErrorMessage = "InvalidLastName")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
		[Required(ErrorMessage = "InvalidGender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Паспорт.
        /// </summary>
		[Required(ErrorMessage = "InvalidPassport")]
        [Display(Name = "Passport")]
        public string Passport { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
		[Display(Name = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
		[Required(ErrorMessage = "InvalidUniqueNumber")]
        [Display(Name = "UniqueNumber")]
        public string Card { get; set; }

        /// <summary>
        /// Новый уникальный номер карты.
        /// </summary>
		[Required(ErrorMessage = "InvalidNewUniqueNumber")]
        [Display(Name = "NewUniqueNumber")]
        public string SelectedNewUniqueNumberCard { get; set; }

        /// <summary>
        /// Список доступных карт.
        /// </summary>
        //[Display(Name = "Заменить на новый уникальный номер карты")]
        public List<string> AvailableCards { get; set; }
    }
}
