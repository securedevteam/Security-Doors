using System;

namespace SecurityDoors.Core.StaticClasses
{
    /// <summary>
    /// Вспомогательный класс подсвечивания текста определенным цветом.
    /// </summary>
    public static class CLIColor
    {
        /// <summary>
        /// Отображение ошибки особым цветом.
        /// </summary>
        /// <param name="message">сообщение.</param>
        public static void WriteError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Reset();
        }

        /// <summary>
        /// Отображение важного текста особым цветом.
        /// </summary>
        /// <param name="message">сообщение.</param>
        public static void WriteInfo(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Reset();
        }

        /// <summary>
        /// Сброс цвета.
        /// </summary>
        private static void Reset()
        {
            Console.ResetColor();
        }
    }
}
