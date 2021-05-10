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
    public class DoorReaderManagerTests
    {
        // SUT
        private readonly IDoorReaderManager _doorReaderManager;

        // Application context
        private readonly ApplicationContext _applicationContext;

        public DoorReaderManagerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase($"{nameof(DoorReaderManagerTests)}_Db")
                        .UseInternalServiceProvider(
                            new ServiceCollection()
                                .AddEntityFrameworkInMemoryDatabase()
                                .BuildServiceProvider()))
                .AddAutoMapper(Assembly.Load("Secure.SecurityDoors.Logic"))
                .BuildServiceProvider();

            _applicationContext = serviceProvider.GetRequiredService<ApplicationContext>();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            _doorReaderManager = new DoorReaderManager(
                mapper,
                _applicationContext);
        }

        [Fact]
        public void Constructor_Throws_ArgumentNullException()
        {
            var mapper = new Mock<IMapper>().Object;

            Assert.Throws<ArgumentNullException>(() =>
                new DoorReaderManager(null, null));

            Assert.Throws<ArgumentNullException>(() =>
                new DoorReaderManager(mapper, null));
        }

        [Fact]
        public void GetAllAsync_DoorReadersExist_DoorReadersRetrieved()
        {
            // Arrange
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

            _applicationContext.DoorReaders.AddRange(doorReader1, doorReader2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorReaderDtos = _doorReaderManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(2, receivedDoorReaderDtos.Count());
        }

        [Fact]
        public void GetAllAsync_DoorReadersNotExist_RetrievedEmptyCollection()
        {
            // Arrange

            // Act
            var receivedDoorReaderDtos = _doorReaderManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Empty(receivedDoorReaderDtos);
        }

        [Fact]
        public void GetAllAsync_DoorReadersExist_DoorReadersRetrievedByTypeFilter()
        {
            // Arrange
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

            _applicationContext.DoorReaders.AddRange(doorReader1, doorReader2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorReaderDtos = _doorReaderManager
                .GetAllAsync(typeFilter: DoorReaderType.Entrance)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorReaderDtos.Where(doorReaderDto => doorReaderDto.Id == doorReader1.Id));
        }

        [Fact]
        public void GetAllAsync_DoorReadersExist_DoorReadersRetrievedWithIncludes()
        {
            // Arrange
            var doorReader = new DoorReader
            {
                Id = 1,
                SerialNumber = "123-01",
                DoorId = 1,
                Type = DoorReaderType.Entrance,
            };

            var door = new Door
            {
                Id = 1,
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            _applicationContext.DoorReaders.Add(doorReader);
            _applicationContext.Doors.Add(door);
            _applicationContext.SaveChanges();

            // Act
            var includes = new string[]
            {
                nameof(DoorReader.Door)
            };

            var receivedDoorReaderDtos = _doorReaderManager
                .GetAllAsync(includes: includes)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(door.Id, receivedDoorReaderDtos.FirstOrDefault().Door.Id);
        }
    }
}
