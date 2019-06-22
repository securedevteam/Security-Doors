using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.RemoteControl.Implementations;
using System;
using System.Threading.Tasks;

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
        public async Task Run()
        {
            CLIColor.WriteInfo("Wellcome to remote Controll system!\n");
       
            var mec = new MainExecuteCommand(_applicationContext);
            var dec = new DoorExecuteCommand(_dataManager, _applicationContext);
            var cec = new CardExecuteCommand(_dataManager, _applicationContext);
            var pec = new PersonExecuteCommand(_dataManager, _applicationContext);

            mec.PrintCountOfRecord();
            mec.PrintHelpInformation();
            
            #region Основной цикл разбора ввода на команды

            while (true)
            {
                Console.Write("Please select the command: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "quit":
                    case "q":
                        {
                            return;
                        }

                    case "help":
                    case "h":
                        {
                            mec.PrintHelpInformation();
                        }
                        break;

                    case "clear":
                    case "c":
                        {
                            mec.ClearScreen();
                        }
                        break;

                    case "count-record":
                    case "c-r":
                        {
                            mec.PrintCountOfRecord();
                        }
                        break;

                    case "add person":
                    case "a-p":
                        {
                            await pec.AddPersonAsync();
                        }
                        break;

                    case "add-door":
                    case "a-d":
                        {
                            await dec.AddDoorAsync();
                        }
                        break;

                    case "add-card":
                    case "a-c":
                        {
                            await cec.AddCardAsync();
                        }
                        break;

                    case "list-person":
                    case "l-p":
                        {
                            await pec.PrintListOfPeopleAsync();
                        }
                        break;

                    case "list-card":
                    case "l-c":
                        {
                            await cec.PrintListOfCardsAsync();
                        }
                        break;

                    case "list-doors":
                    case "l-d":
                        {
                            await dec.PrintListOfDoorsAsync();
                        }
                        break;

                    case "show-person":
                    case "s-p":
                        {
                            await pec.PrintPersonByIdAsync();
                        }
                        break;

                    case "show-card":
                    case "s-c":
                        {
                            await cec.PrintCardByIdAsync();
                        }
                        break;

                    case "show-door":
                    case "s-d":
                        {
                            await dec.PrintDoorByIdAsync();
                        }
                        break;

                    case "delete-person":
                    case "d-p":
                        {
                            await pec.DeletePersonByIdAsync();
                        }
                        break;

                    case "delete-card":
                    case "d-c":
                        {
                            await cec.DeleteCardByIdAsync();
                        }
                        break;

                    case "delete-door":
                    case "d-d":
                        {
                            await dec.DeleteDoorByIdAsync();
                        }
                        break;

                    default:
                        {
                            CLIColor.WriteError("Command unrecognized! Please re-enter..\n");
                        }
                        break;
                }

                #endregion
            }
        }
    }
}
