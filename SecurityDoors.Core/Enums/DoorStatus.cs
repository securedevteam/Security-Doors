namespace SecurityDoors.Core.Enums
{
    /// <summary>
    /// Перечисление статусов двери.
    /// </summary>
    public enum DoorStatus
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
        /// На ремонте.
        /// </summary>
        OnRepair = 2
    }
}
