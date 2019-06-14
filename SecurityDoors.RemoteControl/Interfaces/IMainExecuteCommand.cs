namespace SecurityDoors.RemoteControl.Interfaces
{
    /// <summary>
    /// Интерфейс для управления служебными командами консоли.
    /// </summary>
    interface IMainExecuteCommand
    {
        /// <summary>
        /// Очистка экрана консоли.
        /// </summary>
        void ClearScreen();

        /// <summary>
        /// Печать доступных команд для ввода.
        /// </summary>
        void PrintHelpInformation();

        /// <summary>
        /// Вывод информации о количества записей в базе данных.
        /// </summary>
        void PrintCountOfRecord();
    }
}
