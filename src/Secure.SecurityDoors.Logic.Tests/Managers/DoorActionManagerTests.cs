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
                DoorReaderId = 1,
                CardId = 1,
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
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                DoorReaderId = 1,
                CardId = 1,
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
        public void GetAllAsync_DoorActionsExist_DoorActionRetrievedWithPagination()
        {
            // Arrange
            var pageDto = new PageDto
            {
                Page = 1,
                PageSize = 1,
            };

            var doorAction1 = new DoorAction
            {
                Id = 1,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync(pageDto: pageDto)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos);
        }

        [Fact]
        public void GetAllAsync_DoorActionsExist_DoorActionRetrievedByDateFilter()
        {
            // Arrange
            var defaultDate = new DateTime(2000, 1, 1);

            var doorAction1 = new DoorAction
            {
                Id = 1,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Success,
                TimeStamp = defaultDate,
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync(dateFilter: defaultDate)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction1.Id));
        }

        [Fact]
        public void GetAllAsync_DoorActionsExist_DoorActionRetrievedByStatusFilter()
        {
            // Arrange
            var doorAction1 = new DoorAction
            {
                Id = 1,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync(statusFilter: DoorActionStatusType.Success)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction1.Id));
        }

        [Fact]
        public void GetAllAsync_DoorActionsExist_DoorActionRetrievedByCardIdsFilter()
        {
            // Arrange
            var doorAction1 = new DoorAction
            {
                Id = 1,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync(cardIds: new int[] { doorAction1.CardId })
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction1.Id));
        }

        [Fact]
        public void GetAllAsync_DoorActionsExist_DoorActionRetrievedByDoorIdsFilter()
        {
            // Arrange
            var doorId = 1;

            var doorAction1 = new DoorAction
            {
                Id = 1,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            var doorAction2 = new DoorAction
            {
                Id = 2,
                DoorReaderId = 1,
                CardId = 1,
                Status = DoorActionStatusType.Error,
                TimeStamp = new DateTime(2000, 1, 2),
            };

            var doorReader1 = new DoorReader
            {
                Id = 1,
                SerialNumber = "123-01",
                DoorId = doorId,
                Type = DoorReaderType.Entrance,
            };

            var doorReader2 = new DoorReader
            {
                Id = 2,
                SerialNumber = "123-02",
                DoorId = doorId,
                Type = DoorReaderType.Exit,
            };

            _applicationContext.DoorActions.AddRange(doorAction1, doorAction2);
            _applicationContext.DoorReaders.AddRange(doorReader1, doorReader2);
            _applicationContext.SaveChanges();

            // Act
            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync(doorIds: new int[] { doorId })
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction1.Id));
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction2.Id));
        }

        [Fact]
        public void GetAllAsync_DoorActionsExist_DoorActionRetrievedWithIncludes()
        {
            // Arrange
            var card = new Card
            {
                Id = 1,
                UserId = "QWERTY123",
                UniqueNumber = "123-45",
                Status = CardStatusType.Active,
                Level = LevelType.Administrator,
            };

            var door = new Door
            {
                Id = 1,
                Name = "Door1",
                Description = "DoorDescription1",
                Level = LevelType.Administrator,
                Status = DoorStatusType.Active,
            };

            var doorReader = new DoorReader
            {
                Id = 1,
                SerialNumber = "123-01",
                DoorId = door.Id,
                Type = DoorReaderType.Entrance,
            };

            var doorAction = new DoorAction
            {
                Id = 1,
                DoorReaderId = doorReader.Id,
                CardId = card.Id,
                Status = DoorActionStatusType.Success,
                TimeStamp = new DateTime(2000, 1, 1),
            };

            _applicationContext.Cards.Add(card);
            _applicationContext.Doors.Add(door);
            _applicationContext.DoorReaders.Add(doorReader);
            _applicationContext.DoorActions.Add(doorAction);
            _applicationContext.SaveChanges();

            // Act
            var includes = new string[]
            {
                nameof(DoorActionDto.Card),
                nameof(DoorActionDto.DoorReader),
                nameof(DoorReader.Door)
            };

            var receivedDoorActionDtos = _doorActionManager
                .GetAllAsync(includes: includes)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Id == doorAction.Id));
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.Card.Id == card.Id));
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.DoorReader.Id == doorReader.Id));
            Assert.Single(receivedDoorActionDtos.Where(doorActionDto => doorActionDto.DoorReader.Door.Id == door.Id));
        }
    }
}
