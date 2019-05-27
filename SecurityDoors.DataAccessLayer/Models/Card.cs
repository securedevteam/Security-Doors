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

        /// <summary>
        /// Статус карточки.
        /// </summary>
        public bool Status { get; set; }
		public Person Person { get; set; }
	}
}
