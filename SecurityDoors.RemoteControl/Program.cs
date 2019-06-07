using SecurityDoors.RemoteControl.cli;

namespace SecurityDoors.RemoteControl
{
    class Program
    {
        /// <summary>
        ///<c>Main</c>  метод
        ///создание и иницидизация консоли
        /// </summary>
        /// <param name="args">никогда не используются</param>
        static void Main(string[] args)
        {
            Cli cli = new Cli();
            cli.run();
        }
    }
}