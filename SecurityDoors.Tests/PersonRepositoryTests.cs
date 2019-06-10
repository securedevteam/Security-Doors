using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SecurityDoors.Tests
{
	class PersonRepositoryTests : IClassFixture<ServiceFixture>, IDisposable
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
	}
}
