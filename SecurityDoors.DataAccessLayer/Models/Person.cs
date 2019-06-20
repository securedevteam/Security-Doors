using System.Collections.Generic;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Person
    {
        public IEnumerable<object> id;

        /// <summary>
        /// Id сотрудника.
        /// </summary> 
        public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		public string SecondName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Пол.
		/// </summary>
		public int Gender { get; set; }

		/// <summary>
		/// Паспорт.
		/// </summary>
		public string Passport { get; set; }

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Id карточки.
		/// </summary>
		public int CardId { get; set; }

		public Card Card { get; set; }
	}
}
