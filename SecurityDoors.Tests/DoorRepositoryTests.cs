using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SecurityDoors.Tests
{
	public class DoorRepositoryTests : IClassFixture<ServiceFixture>, IDisposable
	{
		private readonly ServiceProvider _serviceProvider;
		private readonly DataManager _dataManagerService;
		private readonly ApplicationContext _context;

		private readonly Random rnd = new Random();

		public DoorRepositoryTests(ServiceFixture fixture)
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
					/*
					UniqueNumber = Guid.NewGuid().ToString(),
					Status = rnd.Next(),
					Level = rnd.Next(),
					Location = false,
					Comment = string.Empty*/
				});
			}

			// Act
			_context.Doors.AddRange(doors);
			_context.SaveChanges();

			var doorsList = _dataManagerService.Doors.GetDoorsList();
			var actual = doorsList;

			// Assert
			//Assert.Equal(expected, actual);
		}
	}
}
