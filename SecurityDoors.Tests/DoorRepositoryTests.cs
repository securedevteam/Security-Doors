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
	public class DoorRepositoryTests : IClassFixture<ServiceFixture>, IDisposable
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
		public DoorRepositoryTests(ServiceFixture fixture)
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
        /// Тест на проверку получения списка дверей
        /// </summary>
        [Fact]
		public void GetDoorsListTest_Return10()
		{
			// Arrange
			var doors = new List<Door>();
			var expected = 10;

			for (int i = 0; i < expected; i++)
			{
				doors.Add(new Door()
				{
					Name = Guid.NewGuid().ToString(),
					Comment = Guid.NewGuid().ToString(),
					Description = Guid.NewGuid().ToString(),
					Level = rnd.Next(1,10),
					Status = rnd.Next(1,10)
				});
			}

			// Act
			_context.Doors.AddRange(doors);
			_context.SaveChanges();

			var doorsList = _dataManagerService.Doors.GetDoorsList().ToList();
			var actual = doorsList.Count;

			// Assert
			Assert.Equal(expected, actual);
			Assert.True(Equal(doors, doorsList));
		}
		
		/// <summary>
		/// Тест на получение двери по Id
		/// </summary>
		[Fact]
		public void GetDoorByIdTest()
		{
			//Arrange
			var door = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Comment = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(1, 10),
				Status = rnd.Next(1, 10)
			};
			//Act
			_context.Doors.Add(door);
			_context.SaveChanges();
			var doorInDB = _dataManagerService.Doors.GetDoorById(door.Id);
			//Assert
			Assert.True(Equal(door, doorInDB));
		}
		
		/// <summary>
		/// Тест на получение двери по имени
		/// </summary>
		[Fact]
		public void GetDoorByNameTest ()
		{
			//Arrange
			var door = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Comment = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(1, 10),
				Status = rnd.Next(1, 10)
			};
			//Act
			_context.Doors.Add(door);
			_context.SaveChanges();
			var doorInDB = _dataManagerService.Doors.GetDoorByName(door.Name);
			//Assert
			Assert.True(Equal(door, doorInDB));
		}

		/// <summary>
		/// Тест на обновление двери
		/// </summary>
		[Fact]
		public void UpdateTest()
		{
			//Arrange
			var door = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Comment = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(1, 10),
				Status = rnd.Next(1, 10)
			};
			_context.Doors.Add(door);
			_context.SaveChanges();

			/// Сперва добавляется дверь в репозиторий, после изменяется и сравнивается
			//Act

			var doorInDB = _dataManagerService.Doors.GetDoorById(door.Id);
			doorInDB.Name = Guid.NewGuid().ToString();
			doorInDB.Comment = Guid.NewGuid().ToString();
			doorInDB.Description = Guid.NewGuid().ToString();
			doorInDB.Level = rnd.Next(1, 10);
			doorInDB.Status = rnd.Next(1, 10);
			_dataManagerService.Doors.Update(doorInDB);

			var updatedDoorInDB = _dataManagerService.Doors.GetDoorById(door.Id);
			//Assert
			Assert.False(Equal(door, doorInDB));
			Assert.True(Equal(updatedDoorInDB, doorInDB));
		}
		/// <summary>
		/// Тест на удаление двери
		/// </summary>
		[Fact]
		public void DeleteTest()
		{
			//Arrange
			var door = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Comment = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(1, 10),
				Status = rnd.Next(1, 10)
			};
			_context.Doors.Add(door);
			_context.SaveChanges();

			/// Сперва добавляется дверь в репозиторий, после удаляется
			//Act


			_dataManagerService.Doors.Delete(door.Id);

			var doorInDB = _dataManagerService.Doors.GetDoorById(door.Id);
			//Assert
			Assert.Null(doorInDB);
		}

		/// <summary>
		/// Тест на добавление двери
		/// </summary>
		[Fact]
		public void SaveTest()
		{
			//Arrange
			var door = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Comment = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(1, 10),
				Status = rnd.Next(1, 10)
			};
			//Act

			_dataManagerService.Doors.Save(door);

			var doorInDB = _dataManagerService.Doors.GetDoorById(door.Id);
			//Assert
			Assert.True(Equal(door, doorInDB));
		}



		/// <summary>
		/// Сравнивает обе двери по их свойствам
		/// </summary>
		/// <param name="doorA">Первая дверь</param>
		/// <param name="doorB">Вторая дверь</param>
		/// <returns>Если свойства совпадают - true</returns>
		private static bool Equal (Door doorA, Door doorB)
		{
			return	doorA.Id == doorB.Id &&
					doorA.Name == doorB.Name &&
					doorA.Status == doorB.Status &&
					doorA.Level == doorB.Level &&
					doorA.Comment == doorB.Comment &&
					doorA.Description == doorB.Description &&
					doorA.DoorPassings == doorB.DoorPassings;
		}

		/// <summary>
		/// Сравнивает два списка дверей по свойствам их содержимого
		/// </summary>
		/// <param name="doorsA">Первый список</param>
		/// <param name="doorsB">Второй список</param>
		/// <returns>Если свойства совпадают - true</returns>
		private static bool Equal (List<Door> doorsA, List<Door> doorsB)
		{
			if (doorsA.Count != doorsB.Count)
			{
				return false;
			}
			for (int i = 0; i < doorsA.Count; i++)
			{
				if (Equal(doorsA[i], doorsB[i]))
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
