using System;

namespace SecurityDoors.Core.Models
{
    /// <summary>
    /// Модель дверного контроллера.
    /// </summary>
    public class DoorPassingModel
    {
        /// <summary>
        /// Id дверного контроллера.
        /// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Время прохода.
        /// </summary>
        public DateTime PassingTime { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Нахождение.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Название двери.
        /// </summary>
        public string Door { get; set; }

        /// <summary>
        /// Уникальный номер карты.
        /// </summary>
        public string Card { get; set; }
    }
}
