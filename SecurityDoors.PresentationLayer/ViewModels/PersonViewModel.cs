using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class PersonViewModel
	{
		[Display(Name = "ID")]
		public int Id { get; set; }
		[Required(ErrorMessage = "Неверное имя")]
		[Display(Name = "Имя")]
		public string FirstName { get; set; }

		[Display(Name = "Отчество")]
		public string SecondName { get; set; }

		[Required(ErrorMessage = "Неверная фамилия")]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Неверный пол")]
		[Display(Name = "Пол")]
		public bool Gender { get; set; }

		[Required(ErrorMessage = "Неверный паспорт")]
		[Display(Name = "Паспорт")]
		public string Passport { get; set; }

		[Display(Name = "Комментарий")]
		public string Comment { get; set; }

		[Display(Name = "ID карты")]
		public int? CardId { get; set; }

	}

    public class PersonEditModel
	{
		[Display(Name = "ID")]
		public int Id { get; set; }
		[Required(ErrorMessage = "Неверное имя")]
		[Display(Name = "Имя")]
		public string FirstName { get; set; }

		[Display(Name = "Отчество")]
		public string SecondName { get; set; }

		[Required(ErrorMessage = "Неверная фамилия")]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Неверный пол")]
		[Display(Name = "Пол")]
		public bool Gender { get; set; }

		[Required(ErrorMessage = "Неверный паспорт")]
		[Display(Name = "Паспорт")]
		public string Passport { get; set; }

		[Display(Name = "Комментарий")]
		public string Comment { get; set; }

		[Display(Name = "ID карты")]
		public int? CardId { get; set; }
	}
}
