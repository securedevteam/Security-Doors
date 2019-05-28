namespace SecurityDoors.PresentationLayer.Enums
{
    /// <summary>
    /// Перечисление.
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
        /// Приостановлена.
        /// </summary>
        IsSuspended = 3
    }
}
