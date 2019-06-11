using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Linq;

namespace SecurityDoors.DataAccessLayer
{
    /// <summary>
    /// Класс для заполнения данными пустую базу данных.
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Заполнение первоначальными данными.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ApplicationContext context)
        {
            #region Проверка на пустоту данных в базе данных.

            if (context.Cards.Any())
            {
                return;
            }

            if (context.Doors.Any())
            {
                return;
            }

            if (context.DoorPassings.Any())
            {
                return;
            }

            if (context.People.Any())
            {
                return;
            }

            #endregion

            // TODO: Добавить больше значений.

            var cards = new Card[]
            {
            new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = 1, Level = 1, Location = false, Comment = "123"},
            };
            foreach (Card c in cards)
            {
                context.Cards.Add(c);
            }
            context.SaveChanges();

            var doors = new Door[]
            {
            new Door { Name = "123", Description = "123", Level = 1, Status = 1, Comment = "123"}
            };
            foreach (Door d in doors)
            {
                context.Doors.Add(d);
            }
            context.SaveChanges();

            var people = new Person[]
            {
            new Person { FirstName="Иван", SecondName = "Иванович", LastName = "Иванов", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", Comment = "123", CardId = 1}
            };
            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
        }
    }
}
