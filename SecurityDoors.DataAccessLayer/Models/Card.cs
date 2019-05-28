using System;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Карточка сотрудника.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Id карты.
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Уникальный номер карты.
		/// </summary>
		///TODO: Запретить NULL значения
		public string UniqueNumber { get; set; }
		/*
		/// <summary>
		/// Дата создания карты
		/// </summary>
		public DateTime CreationDate { get; set; } = DateTime.Now;
		*/
		/// <summary>
		/// Статус карточки.
		/// </summary>
		public int Status { get; set; }
		/// <summary>
		/// Дополнительная информация о карте
		/// </summary>
		public string Comment { get; set; }
		/*
		/// <summary>
		/// Дата прекращения работы карты
		/// </summary>
		public DateTime? ValidThru { get; set; } = DateTime.Now.AddMonths(1);*/

		public Person Person { get; set; }
	}
}
