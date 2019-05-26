using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityDoors.DataAccessLayer.Models
{
	///TODO: Запретить NULL значения
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Id сотрудника.
        /// </summary> 
        public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Required]
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Required]
		public string SecondName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		[Required]
		public string LastName { get; set; }

		/// <summary>
		/// Пол.
		/// </summary>
		[Required]
		public bool Gender { get; set; }

		/// <summary>
		/// Паспорт.
		/// </summary>
		[Required]
		public string Passport { get; set; }
		
		public virtual ICollection<DoorPassing> DoorPassings { get; set; }
		public Person()
		{
			DoorPassings = new List<DoorPassing>();
		}

		[ForeignKey("Card")]
		public int? CardId { get; set; }
		public Card Card { get; set; }

        public static implicit operator Person(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
