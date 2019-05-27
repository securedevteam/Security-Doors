
using System;

namespace SecurityDoors.RemoteControl.cli
{
    class Cli
    {
        private Command command = new Command();
        public void run()
        {
            Console.WriteLine("Wellcome to remote Controll system");
            Console.WriteLine("type quit to exit program");
            command.printHelp();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("quit"))
                {
                    break;
                }
                switch (input)
                {
                    case "help":
                    case "h":
                        command.printHelp();
                        break;
                    case "clear":
                    case "c":
                        command.clearScreen();
                        break;
                    case "add person":
                    case "a-p":
                        if (command.addPerson())
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
                        if (command.addDoor())
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
                        if (command.addCard())
                        {
                            Console.WriteLine("card added succesfull");
                        }
                        else
                        {
                            Console.WriteLine("card added failed");
                        }
                        break;
                    case "count-record":
                    case "c-r":
                        command.printCountOfRecord();
                        break;
                    case "list-person":
                    case "l-p":
                        command.printListOfPerson();
                        break;
                    case "list-card":
                    case "l-c":
                        command.printListOfCard();
                        break;
                    case "list-door":
                    case "l-d":
                        command.printListOfDoor();
                        break;
                    case "list-doorPassing":
                    case "l-dp":
                        command.printListOfDoorPassing();
                        break;
                    case "show-person":
                    case "s-p":
                        command.printPerson();
                        break;
                    case "show-card":
                    case "s-c":
                        command.printCard();
                        break;
                    case "show-door":
                    case "s-d":
                        command.printDoor();
                        break;
                    default:
                        Console.WriteLine("command unrecognized");
                        break;
                }
            }
        }
    }
}
