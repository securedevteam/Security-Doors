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
    public class DoorActionManagerTests
    {
        // SUT
        private readonly IDoorActionManager _doorActionManager;

        // Application context
        private readonly ApplicationContext _applicationContext;

        public DoorActionManagerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase($"{nameof(DoorActionManagerTests)}_Db")
                        .UseInternalServiceProvider(
                            new ServiceCollection()
                                .AddEntityFrameworkInMemoryDatabase()
                                .BuildServiceProvider()))
                .AddAutoMapper(Assembly.Load("Secure.SecurityDoors.Logic"))
                .BuildServiceProvider();

            _applicationContext = serviceProvider.GetRequiredService<ApplicationContext>();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            _doorActionManager = new DoorActionManager(
                mapper,
                _applicationContext);
        }

        [Fact]
        public void Constructor_Throws_ArgumentNullException()
        {
            var mapper = new Mock<IMapper>().Object;

            Assert.Throws<ArgumentNullException>(() =>
                new DoorActionManager(null, null));

            Assert.Throws<ArgumentNullException>(() =>
                new DoorActionManager(mapper, null));
        }

        [Fact]
        public void Method_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _doorActionManager.AddAsync(null)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void AddAsync_DoorActionDtoWithoutId_DoorActionIsAdded()
        {
            // Arrange
            var doorActionDto = new DoorActionDto
            {
                Id = 1,
                CardId = 1,
                DoorId = 1,
                IsEntrance = true,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            // Act
            _doorActionManager.AddAsync(doorActionDto)
                .GetAwaiter()
                .GetResult();

            _applicationContext.SaveChanges();

            // Assert
            Assert.Equal(1, _applicationContext.DoorActions.Count());
        }

        [Fact]
        public void GetAllAsync_DoorActionsExist_DoorActionsRetrieved()
        {
            // Arrange
            var doorAction1 = new DoorAction
            {
                Id = 1,
                CardId = 1,
                DoorId = 1,
                IsEntrance = true,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                CardId = 1,
                DoorId = 2,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction1.Id));
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction2.Id));
        }

        [Fact]
        public void GetAllAsync_DoorActionsNotExist_RetrievedEmptyCollection()
        {
            // Arrange

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Empty(receivedDoorActionDtos);
        }

        [Fact]
        public void GetAllAsync_DoorActionsExist_DoorActionRetrievedByStatusFilter()
        {
            // Arrange
            var doorAction1 = new DoorAction
            {
                Id = 1,
                CardId = 1,
                DoorId = 1,
                IsEntrance = true,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                CardId = 1,
                DoorId = 2,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync(filterDoorActionStatusType: DoorActionStatusType.Success)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction1.Id));
        }

        [Fact]
        public void GetByIdAsync_DoorActionsExist_DoorActionRetrieved()
        {
            // Arrange
            var doorActionIdentifier = 1;
            var doorAction1 = new DoorAction
            {
                Id = doorActionIdentifier,
                CardId = 1,
                DoorId = 1,
                IsEntrance = true,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                CardId = 1,
                DoorId = 2,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDto = _doorActionManager
                .GetByIdAsync(doorActionIdentifier)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(doorActionIdentifier, receivedDoorActionDto.Id);
        }

        [Fact]
        public void GetByIdAsync_DoorActionsExist_DoorActionRetrievedByStatusFilter()
        {
            // Arrange
            var doorActionIdentifier = 1;
            var doorAction1 = new DoorAction
            {
                Id = doorActionIdentifier,
                CardId = 1,
                DoorId = 1,
                IsEntrance = true,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                CardId = 1,
                DoorId = 2,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDto = _doorActionManager
                .GetByIdAsync(
                    doorActionIdentifier,
                    filterDoorActionStatusType: DoorActionStatusType.Success)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(doorActionIdentifier, receivedDoorActionDto.Id);
        }

        [Fact]
        public void GetByIdAsync_DoorActionsNotExist_DoorActionNotRetrieved()
        {
            // Arrange
            var doorActionIdentifier = 1;

            // Act

            // Assert
            Assert.Throws<NotFoundException>(() =>
                _doorActionManager.GetByIdAsync(doorActionIdentifier)
                    .GetAwaiter()
                    .GetResult());
        }
    }
}
