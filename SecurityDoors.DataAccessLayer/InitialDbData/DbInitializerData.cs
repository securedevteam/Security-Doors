using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.DataAccessLayer.InitialDbData
{
	/// <summary>
	/// Класс для заполнения данными пустую базу данных.
	/// </summary>
	public class DbInitializerData
	{
		/// <summary>
		/// Заполнение первоначальными данными.
		/// </summary>
		/// <param name="context"></param>
		public static async Task InitializeAsync(ApplicationContext context)
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

			var rnd = new Random();
			var cards = new Card[]
			{
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(4,5), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(4,5), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(3,4), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(3,4), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(3,4), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))},
				new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = rnd.Next(3,4), Level = rnd.Next(0,3), Location = Convert.ToBoolean(rnd.Next(1,2))}
			};
			foreach (Card c in cards)
			{
				await context.Cards.AddAsync(c);
			}
            await context.SaveChangesAsync();

			var doors = new Door[]
			{
				new Door { Name = "Главный вход", Description = "Основной вход для персонала", Level = 0, Status = 1, Comment = "Добавлен вход для персонала"},
				new Door { Name = "Вход для охраны", Description = "Основной вход для охраны", Level = 2, Status = 1, Comment = "Добавлен вход для охраны"},
				new Door { Name = "Пожарный выход №1", Description = "Аварийный выход", Level = 1, Status = 1, Comment = "№1"},
				new Door { Name = "Пожарный выход №2", Description = "Аварийный выход", Level = 1, Status = 1, Comment = "№2"},
				new Door { Name = "Пожарный выход №3", Description = "Аварийный выход", Level = 1, Status = 1, Comment = "№3"},
				new Door { Name = "Дверь на крышу", Description = "Доступ к комуникациям и лифтам", Level = 2, Status = 1, Comment = "Для обслуживающего персонала"},
				new Door { Name = "Дверь в подвал", Description = "Доступ к комуникациям", Level = 2, Status = 1, Comment = "Для обслуживающего персонала"},
				new Door { Name = "Подсобное помещение", Description = "Помещение для обслуживающего персонала", Level = 1, Status = 1, Comment = "Рабочие места для обслуживающего персонала"},
				new Door { Name = "Рабочая зона №1", Description = "Первый цех", Level = 0, Status = 1, Comment = "Рабочие места"},
				new Door { Name = "Рабочая зона №2", Description = "Второй цех", Level = 0, Status = 1, Comment = "Рабочие места"},
				new Door { Name = "Зона для посетителей", Description = "Ресепшен", Level = 0, Status = 1, Comment = "Зона для встречи клиентов"},
				new Door { Name = "Дверь в правое крыло", Description = "Закрыто на ремонт", Level = 1, Status = 2, Comment = "Недоступно для прохода с 01.06.2019"}
			};
			foreach (Door d in doors)
			{
                await context.Doors.AddAsync(d);
			}
            await context.SaveChangesAsync();

			var people = new Person[]
			{
				new Person { FirstName="Иван", SecondName = "Иванович", LastName = "Иванов", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 1},
				new Person { FirstName="Петр", SecondName = "Петрович", LastName = "Петров", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 2},
				new Person { FirstName="Михаил", SecondName = "Михайлович", LastName = "Михайлов", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 3},
				new Person { FirstName="Алексей", SecondName = "Алексеевич", LastName = "Алсексеев", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 4},
				new Person { FirstName="Юрий", SecondName = "Юрьевич", LastName = "Юрьев", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 5},
				new Person { FirstName="Василиса", SecondName = "Васильевна", LastName = "Вась", Gender = 0, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 6},
				new Person { FirstName="Иосиф", SecondName = "Виссарионович", LastName = "Сталин", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 7},
				new Person { FirstName="Леонид", SecondName = "Леонидович", LastName = "Леонов", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 8},
				new Person { FirstName="Родион", SecondName = "Родионович", LastName = "Родионов", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 9},
				new Person { FirstName="Николай", SecondName = "Николаевич", LastName = "Николаев", Gender = 1, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 10}

			};
			foreach (Person p in people)
			{
                await context.People.AddAsync(p);
			}
            await context.SaveChangesAsync();
		}
	}
}
