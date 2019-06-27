using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.RemoteControl.Interfaces;
using System;
using System.Threading.Tasks;

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
        public async Task AddDoorAsync()
        {
            try
            {
                Console.Write("Enter name: ");
                var name = Console.ReadLine();

                Console.Write("Enter description: ");
                var description = Console.ReadLine();

                Console.Write("Enter level: ");
                var level = int.Parse(Console.ReadLine());

                if (level <= -1 || level >= 3)
                {
                    throw new FormatException();
                }

                Console.Write("Enter status: ");
                var status = int.Parse(Console.ReadLine());

                if (status <= -1 || status >= 3)
                {
                    throw new FormatException();
                }

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

                await _dataManager.Doors.CreateAsync(door);
                _applicationContext.SaveChanges();

                Console.WriteLine();
                CLIColor.WriteInfo("Door successfully added!\n");
            }
            catch (FormatException)
            {
                CLIColor.WriteError("The entered value is not valid!\n");
            }
        }

        /// <inheritdoc/>
        public async Task PrintDoorByIdAsync()
        {
            Console.Write("Enter door id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var door = await _dataManager.Doors.GetDoorByIdAsync(id);

                if (door != null)
                {
                    var result = door.ConvertStatus();

                    CLIColor.WriteInfo("Information about door:");
                    Console.WriteLine("===========================");
                    Console.WriteLine($"Id: {door.Id}");
                    Console.WriteLine($"Name: {door.Name}");
                    Console.WriteLine($"Description: {door.Description}");
                    Console.WriteLine($"Level: {result.Item2}");
                    Console.WriteLine($"Status: {result.Item1}");
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
        public async Task DeleteDoorByIdAsync()
        {
            Console.Write("Enter door id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var door = await _dataManager.Doors.GetDoorByIdAsync(id);

                if (door != null)
                {
                    await _dataManager.Doors.DeleteAsync(id);
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
        public async Task PrintListOfDoorsAsync()
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

            var doors = await _dataManager.Doors.GetDoorsListAsync();

            foreach (var d in doors)
            {
                var result = d.ConvertStatus();

                Console.Write(string.Format("| {0,5} |", d.Id));
                Console.Write(string.Format(" {0,15} |", d.Name));
                Console.Write(string.Format(" {0,15} |", d.Description));
                Console.Write(string.Format(" {0,10} |", result.Item2));
                Console.Write(string.Format(" {0,10} |", result.Item1));
                Console.Write(string.Format(" {0,15} |", d.Comment));
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
