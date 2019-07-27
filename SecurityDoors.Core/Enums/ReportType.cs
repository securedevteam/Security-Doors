namespace SecurityDoors.Core.Enums
{
    /// <summary>
    /// Перечисления для отчета.
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        IsNone = -1,

        /// <summary>
        /// Excel отчет.
        /// </summary>
        IsExcel = 0,

        /// <summary>
        /// PDF отчет.
        /// </summary>
        IsPDF = 1,

        /// <summary>
        /// Тип DoorPassing.
        /// </summary>
        IsDoorPassing = 5
    }
}
