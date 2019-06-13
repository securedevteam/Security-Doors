using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using System;

namespace SecurityDoors.RemoteControl.cli
{
    /// <summary>
    /// Класс для работы с интерфейсом командной строки.
    /// </summary>
    public class CommandLineInterface
    {
        private DataManager _dataManager;
        private ApplicationContext _applicationContext;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        /// <param name="applicationContext">контекст основной базы данных.</param>
        public CommandLineInterface(DataManager dataManager, ApplicationContext applicationContext)
        {
            _dataManager = dataManager;
            _applicationContext = applicationContext;
        }

        /// <summary>
        /// Запуск консольной программы.
        /// </summary>
        public void Run()
        {
            CLIColor.WriteInfo("Wellcome to remote Controll system");
       
            ExecuteCommand ec = new ExecuteCommand(_dataManager, _applicationContext);

            ec.PrintCountOfRecord();
            ec.PrintHelpInformation();
            
            #region Основной цикл разбора ввода на команды

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "quit":
                    case "q":
                        {
                            return;
                        }

                    case "help":
                    case "h":
                        {
                            ec.PrintHelpInformation();
                        }
                        break;

                    case "clear":
                    case "c":
                        {
                            ec.ClearScreen();
                            Console.WriteLine("Enter 'h' and press 'Enter' to get help information..\n");
                        }
                        break;

                    case "add person":
                    case "a-p":
                        {
                            //command.addPerson();
                        }
                        break;

                    case "add-door":
                    case "a-d":
                        {
                            ec.AddDoor();
                        }
                        break;

                    case "add-card":
                    case "a-c":
                        {
                            //command.addCard();
                        }
                        break;

                    case "count-record":
                    case "c-r":
                        {
                            ec.PrintCountOfRecord();
                        }
                        break;

                    case "list-person":
                    case "l-p":
                        {
                            //command.printListOfPerson();
                        }
                        break;

                    case "list-card":
                    case "l-c":
                        {
                            //command.printListOfCard();
                        }
                        break;

                    case "list-door":
                    case "l-d":
                        {
                            //command.printListOfDoor();
                        }
                        break;

                    case "list-doorPassing":
                    case "l-dp":
                        {
                            //command.printListOfDoorPassing();
                        }
                        break;

                    case "show-person":
                    case "s-p":
                        {
                            //command.printPerson();
                        }
                        break;

                    case "show-card":
                    case "s-c":
                        {
                            //command.printCard();
                        }
                        break;

                    case "show-door":
                    case "s-d":
                        {
                            //command.printDoor();
                        }
                        break;

                    case "delete-person":
                    case "d-p":
                        {
                            //command.DeletePerson();
                        }
                        break;

                    case "delete-card":
                    case "d-c":
                        {
                            //command.DeleteCard();
                        }
                        break;

                    case "delete-door":
                    case "d-d":
                        {
                            //command.DeleteDoor();
                        }
                        break;

                    case "delete-doorPassing":
                    case "d-dp":
                        {
                            //command.DeleteDoorPassing();  
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("command unrecognized");
                        }
                        break;
                }

                #endregion
            }
        }
    }
}
