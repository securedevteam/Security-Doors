using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SecurityDoors.RemoteControl
{
    class Database
    {
        /// <summary>
        /// TODO Atention: реализовать, либо не использовать 
        /// </summary>
        /// 
        private ApplicationContext db = new ApplicationContext();
        public static void init()
        {
            using (var context = new ApplicationContext())
            {
                if (context.Cards.Count() == 0)
                {
                    context.Cards.Add(new Card {
                        UniqueNumber = Guid.NewGuid().ToString(),
                        Status = true
                    });
                    context.SaveChangesAsync();
                }
                Console.WriteLine("count of record in database:");
                Command command = new Command();
                command.printCountOfRecord();
            }
        }
        #region методы для добавление обьектов в БД
        public void addPerson(Person person)
        {
            db.People.Add(person);
            db.SaveChangesAsync();
        }

        public void addCard(Card card)
        {
            db.Cards.Add(card);
            db.SaveChangesAsync();
        }

        public void addDoor(Door door)
        {
            db.Doors.Add(door);
            db.SaveChangesAsync();
        }
        #endregion

        #region методы для вывода количества обьектов в таблицах БД
        public int getCountOfPerson()
        {
            return db.People.Count();
        }

        public int getCountOfDoor()
        {
            return db.Doors.Count();
        }

        public int getCountOfDoorPassing()
        {
            return db.DoorPassings.Count();
        }

        public int getCountOfCard()
        {
            return db.Cards.Count();
        }
        #endregion

        #region методы получения множества обьектов
        public DbSet<Person> getPersons()
        {
            return db.People;
        }

        public DbSet<Card> getCards()
        {
            return db.Cards;
        }

        public DbSet<Door> getDoors()
        {
            return db.Doors;
        }

        public DbSet<DoorPassing> getDoorPassings()
        {
            return db.DoorPassings;
        }
        #endregion

        #region методы получения обьекта по id
        public Person getPersonById(int id)
        {
            return db.People.Find(id);
        }

        public Card getCardById(int id)
        {
            return db.Cards.Find(id);
        }

        public Door getDoorById(int id)
        {
            return db.Doors.Find(id);
        }
        #endregion
    }
}