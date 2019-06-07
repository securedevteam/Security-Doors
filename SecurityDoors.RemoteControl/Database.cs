using SecurityDoors.DataAccessLayer.Models;
using System.Linq;
using SecurityDoors.BusinessLogicLayer.Implementations;
using System.Collections.Generic;
using SecurityDoors.BusinessLogicLayer;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer.Interfaces;

namespace SecurityDoors.RemoteControl
{
    /// <summary>
    /// класс для работы с БД, использую DI
    /// </summary>
    class Database
    {
        private readonly DataManager _dataManager;
        /// <summary>
        /// конструктор иницилизирует DI
        /// </summary>
        public Database()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICardRepository, CardRepository>()
                .AddSingleton<IDoorRepository, DoorRepository>()
                .AddSingleton<IDoorPassingRepository, DoorPassingRepository>()
                .AddSingleton<IPersonRepository, PersonRepository>()
                .AddScoped<DataManager>()
                .BuildServiceProvider();
            _dataManager = serviceProvider.GetService<DataManager>();
        }

        #region методы для добавление обьектов в БД
        /// <summary>
        /// добавление в БД обьекта Person
        /// </summary>
        /// <param name="person">обьект который мы хотим сохранить в БД</param>
        public void AddPerson(Person person)
        {
            _dataManager.People.Save(person);
        }
        /// <summary>
        /// добавление в БД обьекта Card
        /// </summary>
        /// <param name="card">обьект который мы хотим сохранить в БД</param>
        public void AddCard(Card card)
        {
            _dataManager.Cards.Save(card);
        }

        /// <summary>
        /// добавление в БД обьекта Door
        /// </summary>
        /// <param name="door">обьект который мы хотим сохранить в БД</param>
        public void AddDoor(Door door)
        {
            _dataManager.Doors.Save(door);
        }
        #endregion

        #region методы для вывода количества обьектов в таблицах БД
        /// <summary>
        /// получение количества обьектов типа Person в БД
        /// </summary>
        /// <returns>количество обьектов в БД</returns>
        public int GetCountOfPerson()
        {
            return _dataManager.People.GetPeopleList().Count();
        }

        /// <summary>
        ///  получение количества обьектов типа Door в БД
        /// </summary>
        /// <returns>количество обьектов в БД</returns>
        public int GetCountOfDoor()
        {
            return _dataManager.Doors.GetDoorsList().Count();
        }


        /// <summary>
        /// получение количества обьектов типа DoorPassing в БД
        /// </summary>
        /// <returns>количество обьектов в БД</returns>
        public int GetCountOfDoorPassing()
        {
            return _dataManager.DoorsPassing.GetDoorsPassingList().Count();
        }


        /// <summary>
        /// получение количества обьектов типа DoorPassing в БД
        /// </summary>
        /// <returns>количество обьектов в БД</returns>
        public int GetCountOfCard()
        {
            return _dataManager.Cards.GetCardsList().Count();
        }
        #endregion

        #region методы получения множества обьектов
        /// <summary>
        /// получить <c><List/c> обьектов Person
        /// </summary>
        /// <returns>IEnumerable<Person> всех обьектов БД </returns>
        public IEnumerable<Person> GetPersons()
        {
            return _dataManager.People.GetPeopleList();
        }

        /// <summary>
        /// получить <c><List/c> обьектов Card
        /// </summary>
        /// <returns>IEnumerable<Card> всех обьектов БД </returns>
        public IEnumerable<Card> GetCards()
        {
            return _dataManager.Cards.GetCardsList();
        }

        /// <summary>
        /// получить <c><List/c> обьектов Door
        /// </summary>
        /// <returns>IEnumerable<Door> всех обьектов БД </returns>
        public IEnumerable<Door> GetDoors()
        {
            return _dataManager.Doors.GetDoorsList();
        }

        /// <summary>
        /// получить <c><List/c> обьектов DoorPassing
        /// </summary>
        /// <returns>IEnumerable<DoorPassing> всех обьектов БД </returns>
        public IEnumerable<DoorPassing> GetDoorPassings()
        {
            return _dataManager.DoorsPassing.GetDoorsPassingList();
        }
        #endregion

        #region методы получения обьекта по id

        /// <summary>
        /// получить обьект типа Person по его id
        /// </summary>
        /// <param name="id">id обьекта, который надо получить</param>
        /// <returns>найденный обьек типа Person</returns>
        public Person GetPersonById(int id)
        {
            return _dataManager.People.GetPersonById(id);
        }

        /// <summary>
        /// получить обьект типа Card по его id
        /// </summary>
        /// <param name="id">id обьекта, который надо получить</param>
        /// <returns>найденный обьек типа card</returns>
        public Card GetCardById(int id)
        {
            return _dataManager.Cards.GetCardById(id);
        }

        /// <summary>
        /// получить обьект типа Door по его id
        /// </summary>
        /// <param name="id">id обьекта, который надо получить</param>
        /// <returns>найденный обьек типа Door</returns>
        public Door GetDoorById(int id)
        {
            return _dataManager.Doors.GetDoorById(id);
        }
        #endregion

        #region методы удаления объектов из БД

        /// <summary>
        /// удалить обьект из People
        /// </summary>
        /// <param name="id">id обьекта для удаления</param>
        public void deletePerson(int id)
        {
            _dataManager.People.Delete(id);
        }

        /// <summary>
        /// удалить обьект из Cards
        /// </summary>
        /// <param name="id">id обьекта для удаления</param>
        public void deleteCard(int id)
        {
            _dataManager.Cards.Delete(id);
        }

        /// <summary>
        /// удалить обьект из Doors
        /// </summary>
        /// <param name="id">id обьекта для удаления</param>
        public void deleteDoor(int id)
        {
            _dataManager.Doors.Delete(id);
        }

        /// <summary>
        /// удалить обьект из DoorPassings
        /// </summary>
        /// <param name="id">id обьекта для удаления</param>
        public void deleteDoorPassing(int id)
        {
            _dataManager.DoorsPassing.Delete(id);
        }
        #endregion
    }
}