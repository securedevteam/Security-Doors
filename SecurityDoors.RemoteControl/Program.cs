using SecurityDoors.RemoteControl.cli;

namespace SecurityDoors.RemoteControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Db.init();
            Cli.run();
        }
    }
}