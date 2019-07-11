using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.RemoteControl.Interfaces;
using System;
using System.Linq;

namespace SecurityDoors.RemoteControl.Implementations
{
    /// <summary>
    /// Класс для управления служебными командами консоли.
    /// </summary>
    public class MainExecuteCommand : IMainExecuteCommand
    {
        private ApplicationContext _applicationContext;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        /// <param name="applicationContext">контекст основной базы данных.</param>
        public MainExecuteCommand(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public void ClearScreen()
        {
            Console.Clear();
            CLIColor.WriteInfo("Enter 'h' and press 'Enter' to get help information..");
            Console.WriteLine();
        }

        /// <inheritdoc/>
        public void PrintHelpInformation()
        {
            CLIColor.WriteInfo("Available commands:");
            Console.WriteLine(
                              "quit          || q  \n" +
                              "help          || h  \n" +
                              "clear         || c  \n" +
                              "count-record  || c-r\n" +
                              "add-person    || a-p\n" +
                              "add-door      || a-d\n" +
                              "add-card      || a-c\n" +
                              "list-person   || l-p\n" +
                              "list-card     || l-c\n" +
                              "list-door     || l-d\n" +
                              "show-person   || s-p\n" +
                              "show-card     || s-c\n" +
                              "show-door     || s-d\n" +
                              "delete-person || d-p\n" +
                              "delete-card   || d-c\n" +
                              "delete-door   || d-d\n" 
                              );
        }

        /// <inheritdoc/>
        public void PrintCountOfRecord()
        {
            CLIColor.WriteInfo("Сount of records in database:");
            Console.WriteLine("===========================");
            Console.WriteLine($"DoorPassing:\t{_applicationContext.DoorPassings.Count()}");
            Console.WriteLine($"Person:     \t{_applicationContext.People.Count()}");
            Console.WriteLine($"Cards:      \t{_applicationContext.Cards.Count()}");
            Console.WriteLine($"Doors:      \t{_applicationContext.Doors.Count()}");
            Console.WriteLine("===========================");
            Console.WriteLine();
        }
    }
}