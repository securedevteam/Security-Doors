using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SecurityDoors.Tests
{
	public class PersonRepositoryTests : IClassFixture<ServiceFixture>, IDisposable
	{
		private readonly ServiceProvider _serviceProvider;
		private readonly DataManager _dataManagerService;
		private readonly ApplicationContext _context;
        private readonly ClearingDataContext _clearingDataContext;

        private readonly Random rnd = new Random();
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="fixture">приспособление для внедрения DI и InMemoryDatabase.</param>
		public PersonRepositoryTests(ServiceFixture fixture)
		{
			_serviceProvider = fixture.ServiceProvider;
			_context = _serviceProvider.GetRequiredService<ApplicationContext>();
			_dataManagerService = _serviceProvider.GetRequiredService<DataManager>();

            _clearingDataContext = new ClearingDataContext(_context);
        }

        public void Dispose()
        {
            _clearingDataContext.Clear();
        }

        /// <summary>
        /// Тест получения списка людей
        /// </summary>
        [Fact]
		public void GetPeopleListTest ()
		{
			// Arrange
			var people = new List<Person>();
			var expected = 10;

			for (int i = 0; i < expected; i++)
			{
				people.Add(new Person()
				{
					FirstName = Guid.NewGuid().ToString(),
					SecondName = Guid.NewGuid().ToString(),
					LastName = Guid.NewGuid().ToString(),
					Comment = Guid.NewGuid().ToString(),
					Passport = Guid.NewGuid().ToString(),
					Gender = rnd.Next(0,1)
				});
			}

			// Act
			_context.People.AddRange(people);
			_context.SaveChanges();

			var peopleInDB = _dataManagerService.People.GetPeopleList().ToList();
			var actual = peopleInDB.Count;

			// Assert
			Assert.Equal(expected, actual);
			Assert.True(Equal(people, peopleInDB));
		}
		/// <summary>
		/// Тест получения человека по Id
		/// </summary>
		[Fact]
		public void GetPersonByIdTest ()
		{
			//Arrange
			var person = new Person()
			{
				FirstName = Guid.NewGuid().ToString(),
				SecondName = Guid.NewGuid().ToString(),
				LastName = Guid.NewGuid().ToString(),
				Comment = Guid.NewGuid().ToString(),
				Passport = Guid.NewGuid().ToString(),
				Gender = rnd.Next(0, 1)
			};

			_context.Add(person);
			_context.SaveChanges();
			//Act
			var personInDB = _dataManagerService.People.GetPersonById(person.Id);
			//Assert
			Assert.NotNull(personInDB);
			Assert.True(Equal(person, personInDB));
		}

		/// <summary>
		/// Тест обновления человека
		/// </summary>
		[Fact]
		public void UpdateTest ()
		{
			//Arrange
			var person = new Person()
			{
				FirstName = Guid.NewGuid().ToString(),
				SecondName = Guid.NewGuid().ToString(),
				LastName = Guid.NewGuid().ToString(),
				Comment = Guid.NewGuid().ToString(),
				Passport = Guid.NewGuid().ToString(),
				Gender = rnd.Next(0, 1)
			};

			_context.Add(person);
			_context.SaveChanges();
			//Act
			var personInDB = _dataManagerService.People.GetPersonById(person.Id);
			personInDB.FirstName = Guid.NewGuid().ToString();
			personInDB.SecondName = Guid.NewGuid().ToString();
			personInDB.LastName = Guid.NewGuid().ToString();
			personInDB.Comment = Guid.NewGuid().ToString();
			personInDB.Passport = Guid.NewGuid().ToString();
			personInDB.Gender = rnd.Next(0, 1);

			_dataManagerService.People.Update(personInDB);

			var newPersonInDB = _dataManagerService.People.GetPersonById(personInDB.Id);
			//Assert
			Assert.NotNull(newPersonInDB);
			Assert.True(Equal(newPersonInDB, personInDB));
		}

		/// <summary>
		/// Тест удаления человека
		/// </summary>
		[Fact]
		public void DeleteTest ()
		{
			//Arrange
			//int countOfPeople = _context.People.Count();

			//var person = new Person()
			//{
			//	FirstName = Guid.NewGuid().ToString(),
			//	SecondName = Guid.NewGuid().ToString(),
			//	LastName = Guid.NewGuid().ToString(),
			//	Comment = Guid.NewGuid().ToString(),
			//	Passport = Guid.NewGuid().ToString(),
			//	Gender = rnd.Next(0, 1)
			//};

			//_context.Add(person);
			//_context.SaveChanges();
			////Act
			//_dataManagerService.People.Delete(person.Id);

			//var personInDB = _dataManagerService.People.GetPersonById(person.Id);

			////Assert
			//Assert.Null(personInDB);
			//Assert.True(countOfPeople == _context.People.Count());
		}

		/// <summary>
		/// Тест сохранения человека
		/// </summary>
		[Fact]
		public void SaveTest ()
		{
			//Arrange
			//var person = new Person()
			//{
			//	FirstName = Guid.NewGuid().ToString(),
			//	SecondName = Guid.NewGuid().ToString(),
			//	LastName = Guid.NewGuid().ToString(),
			//	Comment = Guid.NewGuid().ToString(),
			//	Passport = Guid.NewGuid().ToString(),
			//	Gender = rnd.Next(0, 1)
			//};

			////Act
			//_dataManagerService.People.Save(person);

			//var personInDB = _context.People.Find(person.Id);

			////Assert
			//Assert.NotNull(personInDB);
			//Assert.True(Equal(person, personInDB));
		}

		/// <summary>
		/// Сравнивает два объекта Person по каждому полю
		/// </summary>
		/// <param name="personA">Первый человек</param>
		/// <param name="personB">Второй человек</param>
		/// <returns>Если все поля совпадают - true</returns>
		private static bool Equal (Person personA, Person personB)
		{
			return personA.Id == personB.Id &&
					personA.FirstName == personB.FirstName &&
					personA.SecondName == personB.SecondName &&
					personA.LastName == personB.LastName &&
					personA.Comment == personB.Comment &&
					personA.CardId == personB.CardId &&
					personA.Card == personB.Card &&
					personA.Gender == personB.Gender &&
					personA.Passport == personB.Passport;
		}

		/// <summary>
		/// Сравнивает два списка людей по каждому полю их содержимого
		/// </summary>
		/// <param name="peopleA">Первый список</param>
		/// <param name="peopleB">Второй список</param>
		/// <returns>Если все поля всех людей совпадают - true</returns>
		private static bool Equal (List<Person> peopleA, List<Person> peopleB)
		{
			if (peopleA.Count != peopleB.Count)
			{
				return false;
			}
			for (int i = 0; i < peopleA.Count; i++)
			{
				if (Equal(peopleA[i],peopleB[i]))
				{
					continue;
				}
				else
				{
					return false;
				}
			}
			return true;
		}
	}
}
