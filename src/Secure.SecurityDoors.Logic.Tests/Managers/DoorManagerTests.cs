using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Managers;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Secure.SecurityDoors.Logic.Tests.Managers
{
    public class DoorManagerTests
    {
        // SUT
        private readonly IDoorManager _doorManager;

        // Application context
        private readonly ApplicationContext _applicationContext;

        public DoorManagerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase($"{nameof(DoorManagerTests)}_Db")
                        .UseInternalServiceProvider(
                            new ServiceCollection()
                                .AddEntityFrameworkInMemoryDatabase()
                                .BuildServiceProvider()))
                .AddAutoMapper(Assembly.Load("Secure.SecurityDoors.Logic"))
                .BuildServiceProvider();

            _applicationContext = serviceProvider.GetRequiredService<ApplicationContext>();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            _doorManager = new DoorManager(
                mapper,
                _applicationContext);
        }

        [Fact]
        public void Constructor_Throws_ArgumentNullException()
        {
            var mapper = new Mock<IMapper>().Object;

            Assert.Throws<ArgumentNullException>(() =>
                new DoorManager(null, null));

            Assert.Throws<ArgumentNullException>(() =>
                new DoorManager(mapper, null));
        }

        [Fact]
        public void GetAllAsync_DoorsExist_DoorsRetrieved()
        {
            // Arrange
            var door = new Door
            {
                Id = 1,
                Name = "Test door 1",
                Level = LevelType.Administrator,
                Status = DoorStatusType.Active,
            };

            var doorReader1 = new DoorReader
            {
                Id = 1,
                SerialNumber = "123-01",
                DoorId = 1,
                Type = DoorReaderType.Entrance,
            };

            var doorReader2 = new DoorReader
            {
                Id = 2,
                SerialNumber = "123-02",
                DoorId = 1,
                Type = DoorReaderType.Exit,
            };

            _applicationContext.Doors.Add(door);
            _applicationContext.DoorReaders.AddRange(doorReader1, doorReader2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorDtos = _doorManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(
                2,
                receivedDoorDtos.Select(door => door.DoorReaders)
                    .FirstOrDefault()
                    .Count());
        }

        [Fact]
        public void GetAllAsync_DoorsNotExist_RetrievedEmptyCollection()
        {
            // Arrange

            // Act
            var receivedDoorDtos = _doorManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Empty(receivedDoorDtos);
        }
    }
}
