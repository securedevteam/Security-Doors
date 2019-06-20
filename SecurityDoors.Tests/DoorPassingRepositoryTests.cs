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
			var expected = 10;

			for (int i = 0; i < expected; i++)
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

			_context.DoorPassings.AddRange(listDoorsPassing);
			_context.SaveChanges();

            // Act
            var doorPassingList = _dataManagerService.DoorsPassing.GetDoorsPassingListAsync().Result;
            var actual = doorPassingList.Count();

            // Assert
            Assert.Equal(expected, actual);
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

			_context.DoorPassings.Add(expected);
			_context.SaveChanges();

            // Act			
            var actual = _dataManagerService.DoorsPassing.GetDoorPassingByIdAsync(expected.Id).Result;

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
			var expected = new DoorPassing()
			{
				PassingTime = DateTime.Now,
				Status = rnd.Next(),
				Location = false,
				Comment = string.Empty,
				DoorId = rnd.Next(),
				CardId = rnd.Next(),
			};

            //Act

            _dataManagerService.DoorsPassing.CreateAsync(expected);
            _context.SaveChanges();

            var actual = _dataManagerService.DoorsPassing.GetDoorPassingByIdAsync(expected.Id).Result;

            // Assert
            Assert.Equal(expected, actual);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.PassingTime, actual.PassingTime);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.Comment, actual.Comment);
            Assert.Equal(expected.DoorId, actual.DoorId);
            Assert.Equal(expected.CardId, actual.CardId);
        }

		/// <summary>
		/// Тест на проверку обновления прохода через дверь.
		/// </summary>
		[Fact]
		public void UpdateDoorPassingTest_Return_True()
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

			_context.DoorPassings.Add(expected);
			_context.SaveChanges();

            // Act
            var actual = _dataManagerService.DoorsPassing.GetDoorPassingByIdAsync(expected.Id).Result;

            actual.PassingTime = DateTime.Now;
            actual.Status = rnd.Next();
            actual.Location = true;
            actual.Comment = Guid.NewGuid().ToString();
            actual.DoorId = rnd.Next();
            actual.CardId = rnd.Next();

            _dataManagerService.DoorsPassing.Update(actual);

            var result = _dataManagerService.DoorsPassing.GetDoorPassingByIdAsync(expected.Id).Result;

            // Assert
            Assert.NotEqual(expected, result);

            Assert.NotEqual(expected.PassingTime, result.PassingTime);
            Assert.NotEqual(expected.Status, result.Status);
            Assert.NotEqual(expected.Location, result.Location);
            Assert.NotEqual(expected.Comment, result.Comment);
            Assert.NotEqual(expected.DoorId, result.DoorId);
            Assert.NotEqual(expected.CardId, result.CardId);
        }

		/// <summary>
		/// Тест на проверку удаления прохода через дверь.
		/// </summary>
		[Fact]
		public void DeleteDoorPassingTest_Return_True()
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

			_context.DoorPassings.Add(expected);
			_context.SaveChanges();

            // Act
            _dataManagerService.DoorsPassing.DeleteAsync(expected.Id);
            var result = _dataManagerService.DoorsPassing.GetDoorPassingByIdAsync(expected.Id).Result;

            // Assert
            Assert.Null(result);
        }

		/// <summary>
		/// Тест на проверку сохранения прохода через дверь.
		/// </summary>
		[Fact]
		public void SaveDPTest_Return_True() // TODO: Разобраться почему ругается с SaveDoorPassing
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
            _dataManagerService.DoorsPassing.SaveAsync(expected);

            var actual = _dataManagerService.DoorsPassing.GetDoorPassingByIdAsync(expected.Id).Result;

            // Assert
            Assert.Equal(expected, actual);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.PassingTime, actual.PassingTime);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.Comment, actual.Comment);
            Assert.Equal(expected.DoorId, actual.DoorId);
            Assert.Equal(expected.CardId, actual.CardId);
        }		
	}
}
