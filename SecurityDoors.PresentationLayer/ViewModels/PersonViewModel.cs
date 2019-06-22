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
		[Required(ErrorMessage = "Неверное имя")]
		[Display(Name = "Имя")]
		public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
		[Display(Name = "Отчество")]
		public string SecondName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
		[Required(ErrorMessage = "Неверная фамилия")]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
		[Required(ErrorMessage = "Неверный пол")]
		[Display(Name = "Пол")]
		public string Gender { get; set; }

        /// <summary>
        /// Паспорт.
        /// </summary>
		[Required(ErrorMessage = "Неверный номер паспорта")]
		[Display(Name = "Паспорт")]
		public string Passport { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
		[Display(Name = "Комментарий")]
		public string Comment { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
        [Required(ErrorMessage = "Неверный уникальный номер карты")]
		[Display(Name = "Уникальный номер карты")]
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
		[Required(ErrorMessage = "Неверное имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
		[Display(Name = "Отчество")]
        public string SecondName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
		[Required(ErrorMessage = "Неверная фамилия")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
		[Required(ErrorMessage = "Неверный пол")]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        /// <summary>
        /// Паспорт.
        /// </summary>
		[Required(ErrorMessage = "Неверный паспорт")]
        [Display(Name = "Паспорт")]
        public string Passport { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
		[Display(Name = "Комментарий")]
        public string Comment { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
		[Required(ErrorMessage = "Неверный уникальный номер карты")]
        [Display(Name = "Уникальный номер карты")]
        public string Card { get; set; }

        /// <summary>
        /// Новый уникальный номер карты.
        /// </summary>
		[Required(ErrorMessage = "Неверный новый уникальный номер карты")]
        [Display(Name = "Новый уникальный номер карты")]
        public string SelectedNewUniqueNumberCard { get; set; }

        /// <summary>
        /// Список доступных карт.
        /// </summary>
        //[Display(Name = "Заменить на новый уникальный номер карты")]
        public List<string> AvailableCards { get; set; }
    }
}
