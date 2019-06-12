using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SecurityDoors.Tests
{
	/// <summary>
	/// Класс для тестов класса DoorPassingRepository.
	/// </summary>
	public class DoorPassingRepositoryTests : IClassFixture<ServiceFixture>, IDisposable
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
		public DoorPassingRepositoryTests(ServiceFixture fixture)
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
        /// Тест на проверку получения списка проходов через дверь.
        /// </summary>
        [Fact]
		public void GetDoorsPassingListTest_Return_10()
		{
			// Arrange
			var listDoorsPassing = new List<DoorPassing>();
			var numberDoorPassing = 10;

			for (int i = 0; i < numberDoorPassing; i++)
			{
				listDoorsPassing.Add(new DoorPassing()
				{
					PassingTime = DateTime.Now,
					Status = rnd.Next(),
					Location = false,
					Comment = string.Empty,
					DoorId = rnd.Next(),
					CardId = rnd.Next(),
				});
			}

			// Act
			_context.DoorPassings.AddRange(listDoorsPassing);
			_context.SaveChanges();

			var actual = listDoorsPassing.Count();

			// Assert
			Assert.Equal(numberDoorPassing, actual);
		}

		/// <summary>
		/// Тест на проверку получения определенного прохода через дверь.
		/// </summary>
		[Fact]
		public void GetDoorPassingByIdTest_Return_1()
		{
			// Arrange
			var expected = new DoorPassing()
			{
				PassingTime = DateTime.Now,
				Status = rnd.Next(),
				Location = false,
				Comment = string.Empty,
				DoorId = rnd.Next(),
				CardId = rnd.Next(),
			};

			// Act
			_context.DoorPassings.Add(expected);
			_context.SaveChanges();

			var actual = _dataManagerService.DoorsPassing.GetDoorPassingById(expected.Id);

			// Assert
			Assert.Equal(expected.Id, actual.Id);
			Assert.Equal(expected.PassingTime, actual.PassingTime);
			Assert.Equal(expected.Status, actual.Status);
			Assert.Equal(expected.Location, actual.Location);
			Assert.Equal(expected.Comment, actual.Comment);
			Assert.Equal(expected.DoorId, actual.DoorId);
			Assert.Equal(expected.CardId, actual.CardId);
		}

		/// <summary>
		///  Тест на проверку создания нового прохода через двер.
		/// </summary>
		[Fact]
		public void CreateDoorPassingTest_Return_True()
		{
			// Arrange
			var doorPassing = new DoorPassing()
			{
				PassingTime = DateTime.Now,
				Status = rnd.Next(),
				Location = false,
				Comment = string.Empty,
				DoorId = rnd.Next(),
				CardId = rnd.Next(),
			};

			//Act
			_dataManagerService.DoorsPassing.Save(doorPassing);
			var createDoorPassing = _dataManagerService.DoorsPassing.GetDoorPassingById(doorPassing.Id);

			//Assert
			Assert.NotNull(createDoorPassing);
		}

		/// <summary>
		/// Тест на проверку обновления прохода через дверь.
		/// </summary>
		[Fact]
		public void UpdateDoorPassingTest_Return_True()
		{
			//Arrange
			var doorPassing = new DoorPassing()
			{
				PassingTime = DateTime.Now,
				Status = rnd.Next(),
				Location = false,
				Comment = string.Empty,
				DoorId = rnd.Next(),
				CardId = rnd.Next(),
			};
			_context.DoorPassings.Add(doorPassing);
			_context.SaveChanges();

			//Act
			var doorPassingUpdate = _dataManagerService.DoorsPassing.GetDoorPassingById(doorPassing.Id);
			doorPassingUpdate.PassingTime = DateTime.Now;
			doorPassingUpdate.Status = rnd.Next();
			doorPassingUpdate.Location = false;
			doorPassingUpdate.Comment = string.Empty;
			doorPassingUpdate.DoorId = rnd.Next();
			doorPassingUpdate.CardId = rnd.Next();

			_dataManagerService.DoorsPassing.Update(doorPassingUpdate);

			var doorPassingUpdateInDataBase = _dataManagerService.DoorsPassing.GetDoorPassingById(doorPassing.Id);

			//Assert            
			Assert.NotEqual(doorPassing, doorPassingUpdateInDataBase);
		}


		/// <summary>
		/// Тест на проверку сохранения прохода через дверь.
		/// </summary>
		[Fact]
		public void SaveDPTest_Return_True()
		{
			// Arrange
			var doorPassing = new DoorPassing()
			{
				PassingTime = DateTime.Now,
				Status = rnd.Next(),
				Location = false,
				Comment = string.Empty,
				DoorId = rnd.Next(),
				CardId = rnd.Next(),
			};

			//Act
			_dataManagerService.DoorsPassing.Save(doorPassing);
			var doorPassingSave = _dataManagerService.DoorsPassing.GetDoorPassingById(doorPassing.Id);

			//Assert
			Assert.Equal(doorPassing, doorPassingSave);
		}

		/// <summary>
		/// Тест на проверку удаления прохода через дверь.
		/// </summary>
		[Fact]
		public void DeleteDoorPassingTest_Return_True()
		{
			//Arrange
			var doorPassing = new DoorPassing()
			{
				PassingTime = DateTime.Now,
				Status = rnd.Next(),
				Location = false,
				Comment = string.Empty,
				DoorId = rnd.Next(),
				CardId = rnd.Next(),
			};
			_context.DoorPassings.Add(doorPassing);
			_context.SaveChanges();

			//Act
			_dataManagerService.DoorsPassing.Delete(doorPassing.Id);
			var doorPassingDelete = _dataManagerService.DoorsPassing.GetDoorPassingById(doorPassing.Id);

			//Assert
			Assert.Null(doorPassingDelete);
		}
	}
}
