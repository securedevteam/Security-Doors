using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.DataAccessLayer.Enums;

namespace SecurityDoors.RemoteControl
{
    class Database
    {
        private ApplicationContext db = new ApplicationContext();
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
            db.People.Add(person);
            db.SaveChangesAsync();
        }

        public void AddCard(Card card)
        {
            // TODO: Пример использования BLL
            //var cr = new CardRepository();
            //cr.Create(card);
            //cr.Save();

            db.Cards.Add(card);
            db.SaveChangesAsync();
        }

        public void AddDoor(Door door)
        {
            db.Doors.Add(door);
            db.SaveChangesAsync();
        }
        #endregion

        #region методы для вывода количества обьектов в таблицах БД
        public int GetCountOfPerson()
        {
            return db.People.Count();
        }

        public int GetCountOfDoor()
        {
            return db.Doors.Count();
        }

        public int GetCountOfDoorPassing()
        {
            return db.DoorPassings.Count();
        }

        public int GetCountOfCard()
        {
            return db.Cards.Count();
        }
        #endregion

        #region методы получения множества обьектов
        public DbSet<Person> GetPersons()
        {
            return db.People;
        }

        public DbSet<Card> GetCards()
        {
            return db.Cards;
        }

        public DbSet<Door> GetDoors()
        {
            return db.Doors;
        }

        public DbSet<DoorPassing> GetDoorPassings()
        {
            return db.DoorPassings;
        }
        #endregion

        #region методы получения обьекта по id
        public Person GetPersonById(int id)
        {
            return db.People.Find(id);
        }

        public Card GetCardById(int id)
        {
            return db.Cards.Find(id);
        }

        public Door GetDoorById(int id)
        {
            return db.Doors.Find(id);
        }
        #endregion

        #region методы удаления объектов из БД
        public void deletePerson(Person person)
        {
            db.People.Remove(person);
            db.SaveChangesAsync();
        }

        public void deleteCard(Card card)
        {
            db.Cards.Remove(card);
            db.SaveChangesAsync();
        }

        public void deleteDoor(Door door)
        {
            db.Doors.Remove(door);
            db.SaveChangesAsync();
        }

        #endregion
    }
}