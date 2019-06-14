namespace SecurityDoors.Core.Enums
{
    /// <summary>
    /// Перечисление статусов карты.
    /// </summary>
    public enum CardStatus
    {
        /// <summary>
        /// Закрыта.
        /// </summary>
        IsClosed = 0,

        /// <summary>
        /// Активна.
        /// </summary>
        IsActive = 1,

        /// <summary>
        /// Утеряна.
        /// </summary>
        IsLost = 2,

        /// <summary>
        /// Приостановлена (Неактивна).
        /// </summary>
        IsSuspended = 3
    }
}
