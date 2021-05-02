using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Exceptions;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Managers;
using Secure.SecurityDoors.Logic.Models;
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
        public void Method_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _doorManager.AddAsync(null)
                    .GetAwaiter()
                    .GetResult());

            Assert.Throws<ArgumentNullException>(() =>
                _doorManager.UpdateAsync(null)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void GetAllAsync_DoorsExist_DoorsRetrieved()
        {
            // Arrange
            var door1 = new Door
            {
                Id = 1,
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            var door2 = new Door
            {
                Id = 2,
                Name = "Test door 2",
                Level = LevelType.Employee,
                Status = DoorStatusType.Closed,
            };

            _applicationContext.Doors.AddRange(door1, door2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorDtos = _doorManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorDtos.Where(doorDto => doorDto.Id == door1.Id));
            Assert.Single(receivedDoorDtos.Where(doorDto => doorDto.Id == door2.Id));
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

        [Fact]
        public void GetAllAsync_DoorsExist_DoorRetrievedByLevelFilter()
        {
            // Arrange
            var door1 = new Door
            {
                Id = 1,
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            var door2 = new Door
            {
                Id = 2,
                Name = "Test door 2",
                Level = LevelType.Employee,
                Status = DoorStatusType.Closed,
            };

            _applicationContext.Doors.AddRange(door1, door2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorDtos = _doorManager
                .GetAllAsync(LevelType.Admin)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorDtos.Where(doorDto => doorDto.Id == door1.Id));
        }

        [Fact]
        public void GetAllAsync_DoorsExist_DoorRetrievedByStatusFilter()
        {
            // Arrange
            var door1 = new Door
            {
                Id = 1,
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            var door2 = new Door
            {
                Id = 2,
                Name = "Test door 2",
                Level = LevelType.Employee,
                Status = DoorStatusType.Closed,
            };

            _applicationContext.Doors.AddRange(door1, door2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorDtos = _doorManager
                .GetAllAsync(whereDoorStatusType: DoorStatusType.Active)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorDtos.Where(doorDto => doorDto.Id == door1.Id));
        }

        [Fact]
        public void AddAsync_DoorDtoWithoutId_DoorIsAdded()
        {
            // Arrange
            var doorDto = new DoorDto
            {
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            // Act
            _doorManager.AddAsync(doorDto)
                .GetAwaiter()
                .GetResult();

            _applicationContext.SaveChanges();

            // Assert
            Assert.Equal(1, _applicationContext.Doors.Count());
        }

        [Fact]
        public void UpdateAsync_DoorDto_DoorIdIsZero()
        {
            // Arrange
            var doorDto = new DoorDto
            {
                Id = 0,
            };

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() =>
                _doorManager.UpdateAsync(doorDto).GetAwaiter().GetResult());
        }

        [Fact]
        public void UpdateAsync_DoorDto_DoorNotFounded()
        {
            // Arrange
            var doorDto = new DoorDto
            {
                Id = 1,
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            // Act

            // Assert
            Assert.Throws<NotFoundException>(() =>
                _doorManager.UpdateAsync(doorDto)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void UpdateAsync_DoorDto_DoorFounded()
        {
            // Arrange
            var door = new Door
            {
                Id = 1,
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            _applicationContext.Doors.Add(door);
            _applicationContext.SaveChanges();

            var doorDto = new DoorDto
            {
                Id = 1,
                Status = DoorStatusType.OnRepair,
            };

            // Act
            _doorManager.UpdateAsync(doorDto)
                .GetAwaiter()
                .GetResult();

            _applicationContext.SaveChanges();

            var updatedDoor = _applicationContext.Doors
                .SingleOrDefaultAsync(door => door.Id == doorDto.Id)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(doorDto.Status, updatedDoor.Status);
        }

        [Fact]
        public void DeleteAsync_DoorIdentifier_DoorIdIsZero()
        {
            // Arrange
            var doorIdentifier = 0;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() =>
                _doorManager.DeleteAsync(doorIdentifier)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void DeleteAsync_DoorIdentifier_DoorNotFounded()
        {
            // Arrange
            var doorIdentifier = 1;

            // Act

            // Assert
            Assert.Throws<NotFoundException>(() =>
                _doorManager.DeleteAsync(doorIdentifier)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void DeleteAsync_DoorIdentifier_DoorDeleted()
        {
            // Arrange
            var doorIdentifier = 1;
            var door = new Door
            {
                Id = doorIdentifier,
                Name = "Test door 1",
                Level = LevelType.Admin,
                Status = DoorStatusType.Active,
            };

            _applicationContext.Doors.Add(door);
            _applicationContext.SaveChanges();

            // Act
            _doorManager.DeleteAsync(doorIdentifier)
                .GetAwaiter()
                .GetResult();

            _applicationContext.SaveChanges();

            // Assert
            Assert.Equal(0, _applicationContext.Doors.Count());
        }
    }
}
