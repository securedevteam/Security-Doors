using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.RemoteControl.Interfaces;
using System;

namespace SecurityDoors.RemoteControl.Implementations
{
    /// <summary>
    /// Класс для управления дверями через консольные команды.
    /// </summary>
    public class DoorExecuteCommand : IDoorExecuteCommand
    {
        private DataManager _dataManager;
        private ApplicationContext _applicationContext;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        /// <param name="applicationContext">контекст основной базы данных.</param>
        public DoorExecuteCommand(DataManager dataManager, ApplicationContext applicationContext)
        {
            _dataManager = dataManager;
            _applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public void AddDoor()
        {
            try
            {
                Console.Write("Enter name: ");
                var name = Console.ReadLine();

                Console.Write("Enter description: ");
                var description = Console.ReadLine();

                Console.Write("Enter level: ");
                var level = int.Parse(Console.ReadLine()); // TODO: добавить ограничения

                Console.Write("Enter status: ");
                var status = int.Parse(Console.ReadLine()); // TODO: добавить ограничения

                Console.Write("Enter comment: ");
                var comment = Console.ReadLine();

                var door = new Door()
                {
                    Name = name,
                    Description = description,
                    Level = level,
                    Status = status,
                    Comment = comment
                };

                _dataManager.Doors.Create(door);
                _applicationContext.SaveChanges();

                Console.WriteLine();
                CLIColor.WriteInfo("Door successfully added!\n");
            }
            catch (FormatException)
            {
                CLIColor.WriteError("Input value is not a number!\n");
            }
        }

        /// <inheritdoc/>
        public void PrintDoorById()
        {
            Console.Write("Enter door id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var door = _dataManager.Doors.GetDoorById(id);

                if (door != null)
                {
                    CLIColor.WriteInfo("Information about door:");
                    Console.WriteLine("===========================");
                    Console.WriteLine($"Id: {door.Id}");
                    Console.WriteLine($"Name: {door.Name}");
                    Console.WriteLine($"Description: {door.Description}");
                    Console.WriteLine($"Level: {door.Level}");
                    Console.WriteLine($"Status: {door.Status}");
                    Console.WriteLine($"Comment: {door.Comment}");
                    Console.WriteLine("===========================");
                    Console.WriteLine();
                }
                else
                {
                    CLIColor.WriteError("Door with this id does not exitst!");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                CLIColor.WriteError("Input value is not a number!\n");
            }
        }

        /// <inheritdoc/>
        public void DeleteDoorById()
        {
            Console.Write("Enter door id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var door = _dataManager.Doors.GetDoorById(id);

                if (door != null)
                {
                    _dataManager.Doors.Delete(id);
                    CLIColor.WriteInfo("Door successfully deleted!\n");
                }
                else
                {
                    CLIColor.WriteError("Door with this id does not exitst!");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                CLIColor.WriteError("Input value is not a number!\n");
            }
        }

        /// <inheritdoc/>
        public void PrintListOfDoors()
        {
            CLIColor.WriteInfo("Information about doors:");

            Console.Write("========================================");
            Console.Write("========================================");
            Console.Write("=========");
            Console.WriteLine();

            Console.Write(string.Format("| {0,5} |", "Id"));
            Console.Write(string.Format(" {0,15} |", "Name"));
            Console.Write(string.Format(" {0,15} |", "Description"));
            Console.Write(string.Format(" {0,10} |", "Level"));
            Console.Write(string.Format(" {0,10} |", "Status"));
            Console.Write(string.Format(" {0,15} |", "Comment"));
            Console.WriteLine();

            Console.Write("========================================");
            Console.Write("========================================");
            Console.Write("=========");
            Console.WriteLine();

            var doors = _dataManager.Doors.GetDoorsList();

            foreach (var d in doors)
            {
                // TODO: Доделать с выводом string значений level и status

                Console.Write(string.Format("| {0,5} |", d.Id));
                Console.Write(string.Format(" {0,15} |", d.Name));
                Console.Write(string.Format(" {0,15} |", d.Description));
                Console.Write(string.Format(" {0,10} |", d.Level));
                Console.Write(string.Format(" {0,10} |", d.Status));
                Console.Write(string.Format(" {0,15} |", d.Comment));
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
