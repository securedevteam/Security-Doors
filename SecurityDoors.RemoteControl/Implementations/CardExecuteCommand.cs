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
    public class CardExecuteCommand : ICardExecuteCommand
    {
        private DataManager _dataManager;
        private ApplicationContext _applicationContext;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        /// <param name="applicationContext">контекст основной базы данных.</param>
        public CardExecuteCommand(DataManager dataManager, ApplicationContext applicationContext)
        {
            _dataManager = dataManager;
            _applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public async Task AddCardAsync()
        {
            try
            {
                var uniqueNumber = Guid.NewGuid().ToString();

                Console.Write("Enter level: ");
                var level = int.Parse(Console.ReadLine());

                if (level <= -1 || level >= 5)
                {
                    throw new FormatException();
                }

                Console.Write("Enter status: ");
                var status = int.Parse(Console.ReadLine());

                if (status <= -1 || status >= 4)
                {
                    throw new FormatException();
                }

                Console.Write("Enter location: ");
                var location = bool.Parse(Console.ReadLine());

                Console.Write("Enter comment: ");
                var comment = Console.ReadLine();

                var card = new Card()
                {
                    UniqueNumber = uniqueNumber,
                    Level = level,
                    Status = status,
                    Location = location,
                    Comment = comment
                };

                await _dataManager.Cards.CreateAsync(card);
                _applicationContext.SaveChanges();

                Console.WriteLine();
                CLIColor.WriteInfo("Card successfully added!\n");
            }
            catch (FormatException)
            {
                CLIColor.WriteError("The entered value is not valid!\n");
            }
        }

        /// <inheritdoc/>
        public async Task PrintCardByIdAsync()
        {
            Console.Write("Enter card id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var card = await _dataManager.Cards.GetCardByIdAsync(id);

                if (card != null)
                {
                    var (status, level, location) = card.ConvertStatus();

                    CLIColor.WriteInfo("Information about card:");
                    Console.WriteLine("===========================");
                    Console.WriteLine($"Id: {card.Id}");
                    Console.WriteLine($"UniqueNumber: {card.UniqueNumber}");
                    Console.WriteLine($"Level: {level}");
                    Console.WriteLine($"Status: {status}");
                    Console.WriteLine($"Location: {location}");
                    Console.WriteLine($"Comment: {card.Comment}");
                    Console.WriteLine("===========================");
                    Console.WriteLine();
                }
                else
                {
                    CLIColor.WriteError("Card with this id does not exitst!");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                CLIColor.WriteError("Input value is not a number!\n");
            }
        }

        /// <inheritdoc/>
        public async Task DeleteCardByIdAsync()
        {
            Console.Write("Enter card id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var card = await _dataManager.Cards.GetCardByIdAsync(id);

                if (card != null)
                {
                    await _dataManager.Cards.DeleteAsync(id);
                    CLIColor.WriteInfo("Card successfully deleted!\n");
                }
                else
                {
                    CLIColor.WriteError("Card with this id does not exitst!");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                CLIColor.WriteError("Input value is not a number!\n");
            }
        }

        /// <inheritdoc/>
        public async Task PrintListOfCardsAsync()
        {
            CLIColor.WriteInfo("Information about cards:");

            Console.Write("========================================");
            Console.Write("========================================");
            Console.Write("=====================================");
            Console.WriteLine();

            Console.Write(string.Format("| {0,5} |", "Id"));
            Console.Write(string.Format(" {0,36} |", "UniqueNumber"));
            Console.Write(string.Format(" {0,13} |", "Level"));
            Console.Write(string.Format(" {0,10} |", "Status"));
            Console.Write(string.Format(" {0,19} |", "Location"));
            Console.Write(string.Format(" {0,15} |", "Comment"));
            Console.WriteLine();

            Console.Write("========================================");
            Console.Write("========================================");
            Console.Write("=====================================");
            Console.WriteLine();

            var cards = await _dataManager.Cards.GetCardsListAsync();

            foreach (var c in cards)
            {
                var (status, level, location) = c.ConvertStatus();

                Console.Write(string.Format("| {0,5} |", c.Id));
                Console.Write(string.Format(" {0,36} |", c.UniqueNumber));               
                Console.Write(string.Format(" {0,13} |", level));
                Console.Write(string.Format(" {0,10} |", status));
                Console.Write(string.Format(" {0,19} |", location));
                Console.Write(string.Format(" {0,15} |", c.Comment));
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
