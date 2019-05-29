﻿using SecurityDoors.RemoteControl.cli;

namespace SecurityDoors.RemoteControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Cli cli = new Cli();
            Database.Init();
            cli.run();
        }
    }
}