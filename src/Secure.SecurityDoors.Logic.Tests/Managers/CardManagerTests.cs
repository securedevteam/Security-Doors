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
    public class CardManagerTests
    {
        // SUT
        private readonly ICardManager _cardManager;

        // Application context
        private readonly ApplicationContext _applicationContext;

        public CardManagerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase($"{nameof(CardManagerTests)}_Db")
                        .UseInternalServiceProvider(
                            new ServiceCollection()
                                .AddEntityFrameworkInMemoryDatabase()
                                .BuildServiceProvider()))
                .AddAutoMapper(Assembly.Load("Secure.SecurityDoors.Logic"))
                .BuildServiceProvider();

            _applicationContext = serviceProvider.GetRequiredService<ApplicationContext>();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            _cardManager = new CardManager(
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
                _cardManager.AddAsync(null)
                    .GetAwaiter()
                    .GetResult());

            Assert.Throws<ArgumentNullException>(() =>
                _cardManager.UpdateAsync(null)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void AddAsync_CardDtoWithoutId_CardIsAdded()
        {
            // Arrange
            var cardDto = new CardDto
            {
                UserId = "QWERTY123",
                Number = "123-45",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            // Act
            _cardManager.AddAsync(cardDto)
                .GetAwaiter()
                .GetResult();

            _applicationContext.SaveChanges();

            // Assert
            Assert.Equal(1, _applicationContext.Cards.Count());
        }

        [Fact]
        public void GetAllAsync_CardsExist_CardsRetrieved()
        {
            // Arrange
            var card1 = new Card
            {
                Id = 1,
                UserId = "QWERTY123",
                Number = "123-45",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            var card2 = new Card
            {
                Id = 2,
                UserId = "QWERTY321",
                Number = "123-67",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            _applicationContext.Cards.AddRange(card1, card2);
            _applicationContext.SaveChanges();

            // Act
            var receivedCardDtos = _cardManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedCardDtos.Where(cardDto => cardDto.Id == card1.Id));
            Assert.Single(receivedCardDtos.Where(cardDto => cardDto.Id == card2.Id));
        }

        [Fact]
        public void GetAllAsync_CardsNotExist_RetrievedEmptyCollection()
        {
            // Arrange

            // Act
            var receivedCardDtos = _cardManager
                .GetAllAsync()
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Empty(receivedCardDtos);
        }

        [Fact]
        public void GetAllAsync_CardsExist_CardRetrievedByLevelFilter()
        {
            // Arrange
            var card1 = new Card
            {
                Id = 1,
                UserId = "QWERTY123",
                Number = "123-45",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            var card2 = new Card
            {
                Id = 2,
                UserId = "QWERTY321",
                Number = "123-67",
                Level = LevelType.Employee,
                Status = CardStatusType.Locked,
            };

            _applicationContext.Cards.AddRange(card1, card2);
            _applicationContext.SaveChanges();

            // Act
            var receivedCardDtos = _cardManager
                .GetAllAsync(filterByLevelType: LevelType.Admin)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedCardDtos.Where(cardDto => cardDto.Id == card1.Id));
        }

        [Fact]
        public void GetAllAsync_CardsExist_CardRetrievedByStatusFilter()
        {
            // Arrange
            var card1 = new Card
            {
                Id = 1,
                UserId = "QWERTY123",
                Number = "123-45",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            var card2 = new Card
            {
                Id = 2,
                UserId = "QWERTY321",
                Number = "123-67",
                Level = LevelType.Employee,
                Status = CardStatusType.Locked,
            };

            _applicationContext.Cards.AddRange(card1, card2);
            _applicationContext.SaveChanges();

            // Act
            var receivedCardDtos = _cardManager
                .GetAllAsync(filterByCardStatusType: CardStatusType.Active)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Single(receivedCardDtos.Where(cardDto => cardDto.Id == card1.Id));
        }

        [Fact]
        public void UpdateAsync_CardDto_CardFounded()
        {
            // Arrange
            var card = new Card
            {
                Id = 1,
                UserId = "QWERTY123",
                Number = "123-45",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            _applicationContext.Cards.Add(card);
            _applicationContext.SaveChanges();

            var cardDto = new CardDto
            {
                Id = 1,
                Status = CardStatusType.Locked,
            };

            // Act
            _cardManager.UpdateAsync(cardDto)
                .GetAwaiter()
                .GetResult();

            _applicationContext.SaveChanges();

            var updatedCard = _applicationContext.Cards
                .SingleOrDefaultAsync(card => card.Id == cardDto.Id)
                .GetAwaiter()
                .GetResult();

            // Assert
            Assert.Equal(cardDto.Status, updatedCard.Status);
        }

        [Fact]
        public void UpdateAsync_CardDto_CardIdIsZero()
        {
            // Arrange
            var cardDto = new CardDto
            {
                Id = 0,
            };

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() =>
                _cardManager.UpdateAsync(cardDto)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void UpdateAsync_CardDto_CardNotFounded()
        {
            // Arrange
            var cardDto = new CardDto
            {
                Id = 1,
                UserId = "QWERTY123",
                Number = "123-45",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            // Act

            // Assert
            Assert.Throws<NotFoundException>(() =>
                _cardManager.UpdateAsync(cardDto)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void DeleteAsync_CardIdentifier_CardDeleted()
        {
            // Arrange
            var cardIdentifier = 1;
            var card = new Card
            {
                Id = cardIdentifier,
                UserId = "QWERTY123",
                Number = "123-45",
                Level = LevelType.Admin,
                Status = CardStatusType.Active,
            };

            _applicationContext.Cards.Add(card);
            _applicationContext.SaveChanges();

            // Act
            _cardManager.DeleteAsync(cardIdentifier)
                .GetAwaiter()
                .GetResult();

            _applicationContext.SaveChanges();

            // Assert
            Assert.Equal(0, _applicationContext.Cards.Count());
        }

        [Fact]
        public void DeleteAsync_CardIdentifier_CardIdIsZero()
        {
            // Arrange
            var cardIdentifier = 0;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() =>
                _cardManager.DeleteAsync(cardIdentifier)
                    .GetAwaiter()
                    .GetResult());
        }

        [Fact]
        public void DeleteAsync_CardIdentifier_CardNotFounded()
        {
            // Arrange
            var cardIdentifier = 1;

            // Act

            // Assert
            Assert.Throws<NotFoundException>(() =>
                _cardManager.DeleteAsync(cardIdentifier)
                    .GetAwaiter()
                    .GetResult());
        }
    }
}
