using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.RemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.RemoteControl.Implementations
{
    /// <summary>
    /// Класс для управления сотрудниками через консольные команды.
    /// </summary>
    public class PersonExecuteCommand : IPersonExecuteCommand
    {
        private DataManager _dataManager;
        private ApplicationContext _applicationContext;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        /// <param name="applicationContext">контекст основной базы данных.</param>
        public PersonExecuteCommand(DataManager dataManager, ApplicationContext applicationContext)
        {
            _dataManager = dataManager;
            _applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public async Task AddPersonAsync()
        {
            try
            {
                Console.Write("Enter first name: ");
                var fn = Console.ReadLine();

                Console.Write("Enter second name: ");
                var sn = Console.ReadLine();

                Console.Write("Enter last name: ");
                var ln = Console.ReadLine();

                Console.Write("Enter gender: ");
                var gender = int.Parse(Console.ReadLine());

                if (gender <= -1 || gender >= 2)
                {
                    throw new FormatException();
                }

                Console.Write("Enter passport: ");
                var passport = Console.ReadLine();

                Console.Write("Enter comment: ");
                var comment = Console.ReadLine();

                Console.Write("Enter CardId: ");
                var cardId = int.Parse(Console.ReadLine());

                var people = await _dataManager.People.GetPeopleListAsync();

                var allCardIds = new List<int>();

                foreach (var item in people)
                {
                    allCardIds.Add(item.CardId);
                }

                foreach (var item in allCardIds)
                {
                    if(cardId == item)
                    {
                        throw new FormatException();
                    }
                }

                var person = new Person()
                {
                    FirstName = fn,
                    SecondName = sn,
                    LastName = ln,
                    Gender = gender,
                    Passport = passport,
                    Comment = comment,
                    CardId = cardId
                };

                await _dataManager.People.CreateAsync(person);
                _applicationContext.SaveChanges();

                Console.WriteLine();
                CLIColor.WriteInfo("Person successfully added!\n");
            }
            catch (FormatException)
            {
                CLIColor.WriteError("The entered value is not valid!\n");
            }
            catch (DbUpdateException)
            {
                CLIColor.WriteError("It is impossible to use a card with such Id!\n");
            }
        }

        /// <inheritdoc/>
        public async Task PrintPersonByIdAsync()
        {
            Console.Write("Enter person id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var person = await _dataManager.People.GetPersonByIdAsync(id);

                if (person != null)
                {
                    var result = person.ConvertGender();

                    CLIColor.WriteInfo("Information about person:");
                    Console.WriteLine("===========================");
                    Console.WriteLine($"Id: {person.Id}");
                    Console.WriteLine($"First name: {person.FirstName}");
                    Console.WriteLine($"Second name: {person.SecondName}");
                    Console.WriteLine($"Last name: {person.LastName}");
                    Console.WriteLine($"Gender: {result}");
                    Console.WriteLine($"Passport: {person.Passport}");
                    Console.WriteLine($"Passport: {person.CardId}");
                    Console.WriteLine($"Comment: {person.Comment}");
                    Console.WriteLine("===========================");
                    Console.WriteLine();
                }
                else
                {
                    CLIColor.WriteError("Person with this id does not exitst!");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                CLIColor.WriteError("Input value is not a number!\n");
            }
        }

        /// <inheritdoc/>
        public async Task DeletePersonByIdAsync()
        {
            Console.Write("Enter person id: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var card = await _dataManager.People.GetPersonByIdAsync(id);

                if (card != null)
                {
                    await _dataManager.People.DeleteAsync(id);
                    CLIColor.WriteInfo("Person successfully deleted!\n");
                }
                else
                {
                    CLIColor.WriteError("Person with this id does not exitst!");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                CLIColor.WriteError("Input value is not a number!\n");
            }
        }

        /// <inheritdoc/>
        public async Task PrintListOfPeopleAsync()
        {
            CLIColor.WriteInfo("Information about people:");

            Console.Write("========================================");
            Console.Write("========================================");
            Console.Write("=====================================");
            Console.WriteLine();

            Console.Write(string.Format("| {0,5} |", "Id"));
            Console.Write(string.Format(" {0,14} |", "First name"));
            Console.Write(string.Format(" {0,14} |", "Second name"));
            Console.Write(string.Format(" {0,14} |", "Last name"));
            Console.Write(string.Format(" {0,10} |", "Gender"));
            Console.Write(string.Format(" {0,14} |", "Passport"));
            Console.Write(string.Format(" {0,6} |", "CardId"));
            Console.Write(string.Format(" {0,15} |", "Comment"));
            Console.WriteLine();

            Console.Write("========================================");
            Console.Write("========================================");
            Console.Write("=====================================");
            Console.WriteLine();

            var people = await _dataManager.People.GetPeopleListAsync();

            foreach (var p in people)
            {
                var result = p.ConvertGender();

                Console.Write(string.Format("| {0,5} |", p.Id));
                Console.Write(string.Format(" {0,14} |", p.FirstName));
                Console.Write(string.Format(" {0,14} |", p.SecondName));
                Console.Write(string.Format(" {0,14} |", p.LastName));
                Console.Write(string.Format(" {0,10} |", result));
                Console.Write(string.Format(" {0,14} |", p.Passport));
                Console.Write(string.Format(" {0,6} |", p.CardId));
                Console.Write(string.Format(" {0,15} |", p.Comment));
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
