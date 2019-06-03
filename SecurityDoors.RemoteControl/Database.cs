using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Linq;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.Core.Enums;
using System.Collections.Generic;
using SecurityDoors.BusinessLogicLayer;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer.Interfaces;

namespace SecurityDoors.RemoteControl
{
    class Database
    {
        private readonly DataManager _dataManager;
        public Database()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICardRepository, CardRepository>()
                .AddTransient<IDoorRepository, DoorRepository>()
                .AddTransient<IDoorPassingRepository, DoorPassingRepository>()
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddScoped<DataManager>()
                .BuildServiceProvider();
            _dataManager = serviceProvider.GetService<DataManager>();
        }

        public static void Init()
        {
            using (var context = new ApplicationContext())
            {
                if (context.Cards.Count() == 0)
                {
                    context.Cards.Add(new Card {
                        UniqueNumber = Guid.NewGuid().ToString(),
						Status = (int)CardStatus.IsActive,
					});
                    context.SaveChangesAsync();
                }
                Console.WriteLine("count of record in database:");
                Command command = new Command();
                command.printCountOfRecord();
            }
        }
        #region методы для добавление обьектов в БД
        public void AddPerson(Person person)
        {
            _dataManager.People.Save(person);
        }

        public void AddCard(Card card)
        {
            _dataManager.Cards.Save(card);
        }

        public void AddDoor(Door door)
        {
            _dataManager.Doors.Save(door);
        }
        #endregion

        #region методы для вывода количества обьектов в таблицах БД
        public int GetCountOfPerson()
        {
            return _dataManager.People.GetPeopleList().Count();
        }

        public int GetCountOfDoor()
        {
            return _dataManager.Doors.GetDoorsList().Count();
        }

        public int GetCountOfDoorPassing()
        {
            return _dataManager.DoorsPassing.GetDoorsPassingList().Count();
        }

        public int GetCountOfCard()
        {
            return _dataManager.Cards.GetCardsList().Count();
        }
        #endregion

        #region методы получения множества обьектов
        public IEnumerable<Person> GetPersons()
        {
            return _dataManager.People.GetPeopleList();
        }

        public IEnumerable<Card> GetCards()
        {
            return _dataManager.Cards.GetCardsList();
        }

        public IEnumerable<Door> GetDoors()
        {
            return _dataManager.Doors.GetDoorsList();
        }

        public IEnumerable<DoorPassing> GetDoorPassings()
        {
            return _dataManager.DoorsPassing.GetDoorsPassingList();
        }
        #endregion

        #region методы получения обьекта по id
        public Person GetPersonById(int id)
        {
            return _dataManager.People.GetPersonById(id);
        }

        public Card GetCardById(int id)
        {
            return _dataManager.Cards.GetCardById(id);
        }

        public Door GetDoorById(int id)
        {
            return _dataManager.Doors.GetDoorById(id);
        }
        #endregion

        #region методы удаления объектов из БД
        public void deletePerson(int id)
        {
            _dataManager.People.Delete(id);
        }

        public void deleteCard(int id)
        {
            _dataManager.Cards.Delete(id);
        }

        public void deleteDoor(int id)
        {
            _dataManager.Doors.Delete(id);
        }

        public void deleteDoorPassing(int id)
        {
            _dataManager.DoorsPassing.Delete(id);
        }
        #endregion
    }
}