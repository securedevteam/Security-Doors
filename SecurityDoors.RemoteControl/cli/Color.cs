using System;

namespace SecurityDoors.RemoteControl.cli
{
    public static class Color
    {
        public static void writeError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            reset();
        }

        public static void writeInfo(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            reset();
        }
        private static void reset()
        {
            Console.ResetColor();
        }
    }
}
