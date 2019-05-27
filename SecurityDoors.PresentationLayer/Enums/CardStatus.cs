namespace SecurityDoors.PresentationLayer.Enums
{
    /// <summary>
    /// Статусы карточки.
    /// </summary>
    public class CardStatus
    {
        /// <summary>
        /// Перечисление.
        /// </summary>
        enum Card
        {
            /// <summary>
            /// Закрыта.
            /// </summary>
            IsClosed = 0,

            /// <summary>
            /// Активна.
            /// </summary>
            Active = 1,

            /// <summary>
            /// Утеряна.
            /// </summary>
            Lost = 2,

            /// <summary>
            /// Приостановлена.
            /// </summary>
            Suspended = 3
        }
    }
}
