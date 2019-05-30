using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Linq;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.DataAccessLayer.Enums;
using System.Collections.Generic;

namespace SecurityDoors.RemoteControl
{
    class Database
    {
        private readonly CardRepository cardRepository     = new CardRepository();
        private readonly PersonRepository personRepository = new PersonRepository();
        private readonly DoorRepository doorRepository     = new DoorRepository();
        private readonly DoorPassingRepository doorPassingRepository = new DoorPassingRepository();
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
            personRepository.Save(person);
        }

        public void AddCard(Card card)
        {
            cardRepository.Save(card);
        }

        public void AddDoor(Door door)
        {
            doorRepository.Save(door);
        }
        #endregion

        #region методы для вывода количества обьектов в таблицах БД
        public int GetCountOfPerson()
        {
            return personRepository.GetPeopleList().Count();
        }

        public int GetCountOfDoor()
        {
            return doorRepository.GetDoorsList().Count();
        }

        public int GetCountOfDoorPassing()
        {
            return doorRepository.GetDoorsList().Count();
        }

        public int GetCountOfCard()
        {
            return cardRepository.GetCardsList().Count();
        }
        #endregion

        #region методы получения множества обьектов
        public IEnumerable<Person> GetPersons()
        {
            return personRepository.GetPeopleList();
        }

        public IEnumerable<Card> GetCards()
        {
            return cardRepository.GetCardsList();
        }

        public IEnumerable<Door> GetDoors()
        {
            return doorRepository.GetDoorsList();
        }

        public IEnumerable<DoorPassing> GetDoorPassings()
        {
            return doorPassingRepository.GetDoorsPassingList();
        }
        #endregion

        #region методы получения обьекта по id
        public Person GetPersonById(int id)
        {
            return personRepository.GetPersonById(id);
        }

        public Card GetCardById(int id)
        {
            return cardRepository.GetCardById(id);
        }

        public Door GetDoorById(int id)
        {
            return doorRepository.GetDoorById(id);
        }
        #endregion

        #region методы удаления объектов из БД
        public void deletePerson(int id)
        {
            personRepository.Delete(id);
        }

        public void deleteCard(int id)
        {
            cardRepository.Delete(id);
        }

        public void deleteDoor(int id)
        {
            doorRepository.Delete(id);
        }

        public void deleteDoorPassing(int id)
        {
            doorPassingRepository.Delete(id);
        }
        #endregion
    }
}