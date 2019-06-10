
using System;

namespace SecurityDoors.RemoteControl.cli
{
    class Cli
    {
        private Command command = new Command();
        /// <summary>
        /// метод запускающий консольную программу
        /// выводит приветственные сообщения и
        /// запускает бесконечный цикл обработки входных команд
        /// </summary>
        public void run()
        {
            Color.writeInfo("Wellcome to remote Controll system");
            Color.writeInfo("type quit to exit program");
            Console.WriteLine("count of record in database:");
            Command command = new Command();
            command.printCountOfRecord();
            command.printHelp();
            #region основной цикл разбора ввода на команды
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "quit":
                    case "q":
                        return;
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
                        command.addPerson();
                        break;
                    case "add-door":
                    case "a-d":
                        command.addDoor();
                        break;
                    case "add-card":
                    case "a-c":
                        command.addCard();
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
                    case "delete-person":
                    case "d-p":
                        command.DeletePerson();
                        break;
                    case "delete-card":
                    case "d-c":
                        command.DeleteCard();
                        break;
                    case "delete-door":
                    case "d-d":
                        command.DeleteDoor();
                        break;
                    case "delete-doorPassing":
                    case "d-dp":
                        command.DeleteDoorPassing();
                        break;
                    default:
                        Console.WriteLine("command unrecognized");
                        break;
                }
                #endregion
            }
        }
    }
}
