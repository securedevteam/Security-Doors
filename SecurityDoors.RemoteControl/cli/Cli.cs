﻿
using System;

namespace SecurityDoors.RemoteControl.cli
{
    class Cli
    {
        public static void run()
        {
            Console.WriteLine("Wellcome to remote Controll system");
            Console.WriteLine("type quit to exit program");
            Console.WriteLine("aviable command:\n" +
                "add-person || a-p\n" +
                "add-door   || a-d\n" +
                "add-card   || a-c");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("quit"))
                {
                    break;
                }
                switch (input)
                {
                    case "add person":
                    case "a-p":
                        if (Command.addPerson())
                        {
                            Console.WriteLine("person added succesfull");
                        }
                        else
                        {
                            Console.WriteLine("person added failed");
                        }
                        break;
                    case "add-door":
                    case "a-d":
                        if (Command.addDoor())
                        {
                            Console.WriteLine("door added succesfull");
                        }
                        else
                        {
                            Console.WriteLine("door added failed");
                        }
                        break;
                    case "add-card":
                    case "a-c":
                        if (Command.addCard())
                        {
                            Console.WriteLine("card added succesfull");
                        }
                        else
                        {
                            Console.WriteLine("card added failed");
                        }
                        break;
                }
            }
        }
    }
}
