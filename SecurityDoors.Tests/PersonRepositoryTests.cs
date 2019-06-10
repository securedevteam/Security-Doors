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
		}

		public void Dispose()
		{
			foreach (var entity in _context.Doors)
			{
				_context.Doors.Remove(entity);
			}

			_context.SaveChanges();
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

		[Fact]
		public void GetPersonByIdTest ()
		{
			var person = new Person()
			{

			};
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
