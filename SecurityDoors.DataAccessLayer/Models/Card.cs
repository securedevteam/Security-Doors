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
		/// Уникальный номер.
		/// </summary>
		public string UniqueNumber { get; set; }

		/// <summary>
		/// Статус.
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// Комментарий.
		/// </summary>
		public string Comment { get; set; }

		public Person Person { get; set; }
	}
}
