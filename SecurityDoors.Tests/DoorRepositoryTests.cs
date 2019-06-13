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
	/// Класс для тестов класса DoorRepository.
	/// </summary>
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
		/// Тест на проверку получения списка дверей.
		/// </summary>
		[Fact]
		public void GetDoorsListTest_Return_10()
		{
			// Arrange
			var listDoors = new List<Door>();
			var expected = 10;

			for (int i = 0; i < expected; i++)
			{
				listDoors.Add(new Door()
				{
					Name = Guid.NewGuid().ToString(),
					Comment = Guid.NewGuid().ToString(),
					Description = Guid.NewGuid().ToString(),
					Level = rnd.Next(1,10),
					Status = rnd.Next(1,10)
				});
			}

			_context.Doors.AddRange(listDoors);
			_context.SaveChanges();

			// Act			
			var doorsList = _dataManagerService.Doors.GetDoorsList().ToList();
			var actual = doorsList.Count();

			// Assert
			Assert.Equal(expected, actual);			
		}
		
		/// <summary>
		/// Тест на проверку получение определенной двери.
		/// </summary>
		[Fact]
		public void GetDoorByIdTest_Return_1()
		{
			// Arrange
			var expected = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),                			
				Level = rnd.Next(),
				Status = rnd.Next(),
				Comment = string.Empty,	
			};

			_context.Doors.Add(expected);
			_context.SaveChanges();

			// Act			
			var actual = _dataManagerService.Doors.GetDoorById(expected.Id);

			// Assert		
			Assert.Equal(expected.Id, actual.Id);
			Assert.Equal(expected.Name, actual.Name);
			Assert.Equal(expected.Description, actual.Description);
			Assert.Equal(expected.Level, actual.Level);
			Assert.Equal(expected.Status, actual.Status);
			Assert.Equal(expected.Comment, actual.Comment);
		}

		/// <summary>
		/// Тест на проверку получение двери по имени.
		/// </summary>
		[Fact]
		public void GetDoorByNameTest_Return_True()
		{
			// Arrange
			var expected = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(),
				Status = rnd.Next(),
				Comment = string.Empty,
			};

			_context.Doors.Add(expected);
			_context.SaveChanges();

			// Act			
			var actual = _dataManagerService.Doors.GetDoorByName(expected.Name);

			// Assert		
			Assert.Equal(expected.Id, actual.Id);
			Assert.Equal(expected.Name, actual.Name);
			Assert.Equal(expected.Description, actual.Description);
			Assert.Equal(expected.Level, actual.Level);
			Assert.Equal(expected.Status, actual.Status);
			Assert.Equal(expected.Comment, actual.Comment);
		}

		/// <summary>
		/// Тест на проверку создания двери.
		/// </summary>
		[Fact]
		public void CreateDoorTest_Return_True()
		{
			// Arrange
			var expected = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(),
				Status = rnd.Next(),
				Comment = string.Empty,
			};

			// Act
			_dataManagerService.Doors.Create(expected);
			_context.SaveChanges();

			var actual = _dataManagerService.Doors.GetDoorById(expected.Id);

			// Assert
			Assert.Equal(expected, actual);

			Assert.Equal(expected.Id, actual.Id);
			Assert.Equal(expected.Name, actual.Name);
			Assert.Equal(expected.Description, actual.Description);
			Assert.Equal(expected.Level, actual.Level);
			Assert.Equal(expected.Status, actual.Status);
			Assert.Equal(expected.Comment, actual.Comment);
		}

		/// <summary>
		/// Тест на проверку обновления двери.
		/// </summary>
		[Fact]
		public void UpdateDoorTest_Return_True()
		{
			// Arrange
			var expected = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(),
				Status = rnd.Next(),
				Comment = string.Empty,
			};

			_context.Doors.Add(expected);
			_context.SaveChanges();

			// Act
			var actual = _dataManagerService.Doors.GetDoorById(expected.Id);
			actual.Name = Guid.NewGuid().ToString();
			actual.Description = Guid.NewGuid().ToString();
			actual.Level = rnd.Next();
			actual.Status = rnd.Next();
			actual.Comment = Guid.NewGuid().ToString();

			_dataManagerService.Doors.Update(actual);
			_context.SaveChanges();

			var result = _dataManagerService.Doors.GetDoorById(actual.Id);

			// Assert
			Assert.NotEqual(expected.Name, result.Name);
			Assert.NotEqual(expected.Description, result.Description);
			Assert.NotEqual(expected.Level, result.Level);
			Assert.NotEqual(expected.Status, result.Status);
			Assert.NotEqual(expected.Comment, result.Comment);

		}
		/// <summary>
		/// Тест на проверку удаление двери.
		/// </summary>
		[Fact]
		public void DeleteDoorTest_Return_True()
		{
			// Arrange
			var expected = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(),
				Status = rnd.Next(),
				Comment = string.Empty,
			};

			_context.Doors.Add(expected);
			_context.SaveChanges();
			
			// Act
			_dataManagerService.Doors.Delete(expected.Id);
			var result = _dataManagerService.Doors.GetDoorById(expected.Id);

			// Assert
			Assert.Null(result);
		}

		/// <summary>
		/// Тест на проверку сохраниения двери.
		/// </summary>
		[Fact]
		public void SaveDoorTest_Return_True()
		{
			// Arrange
			var expected = new Door()
			{
				Name = Guid.NewGuid().ToString(),
				Description = Guid.NewGuid().ToString(),
				Level = rnd.Next(),
				Status = rnd.Next(),
				Comment = string.Empty,
			};
			
			// Act
			_dataManagerService.Doors.Save(expected);

			var actual = _dataManagerService.Doors.GetDoorById(expected.Id);

			// Assert
			Assert.Equal(expected, actual);

			Assert.Equal(expected.Id, actual.Id);
			Assert.Equal(expected.Name, actual.Name);
			Assert.Equal(expected.Description, actual.Description);
			Assert.Equal(expected.Level, actual.Level);
			Assert.Equal(expected.Status, actual.Status);
			Assert.Equal(expected.Comment, actual.Comment);
		}		
	}
}
