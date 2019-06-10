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
    /// Класс для тестов класса CardRepository.
    /// </summary>
    public class CardRepositoryTests : IClassFixture<ServiceFixture>, IDisposable
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;
        private readonly ApplicationContext _context;

        private readonly Random rnd = new Random();

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="fixture">приспособление для внедрения DI и InMemoryDatabase.</param>
        public CardRepositoryTests(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;

            _context = _serviceProvider.GetRequiredService<ApplicationContext>();
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
        }

        public void Dispose()
        {
            foreach (var entity in _context.Cards)
            {
                _context.Cards.Remove(entity);
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Тест на проверку получения списка карт.
        /// </summary>
        [Fact]
        public void GetCardsListTest_Return_10()
        {
            // Arrange
            var listCards = new List<Card>();
            var expected = 10;

            for (int i = 0; i < expected; i++)
            {
                listCards.Add(new Card()
                {
                    UniqueNumber = Guid.NewGuid().ToString(),
                    Status = rnd.Next(),
                    Level = rnd.Next(),
                    Location = false,
                    Comment = string.Empty
                });
            }

            // Act
            _context.Cards.AddRange(listCards);
            _context.SaveChanges();

            var cardList = _dataManagerService.Cards.GetCardsList().ToList();
            var actual = cardList.Count();

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Тест на проверку получения определенной карты.
        /// </summary>
        [Fact]
        public void GetCardsById_Return_1()
        {
            // Arrange
            var expected = new Card()
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Status = rnd.Next(),
                Level = rnd.Next(),
                Location = false,
                Comment = string.Empty
            };

            // Act
            _context.Cards.Add(expected);
            _context.SaveChanges();

            var actual = _dataManagerService.Cards.GetCardById(1);

            // Assert
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.UniqueNumber, actual.UniqueNumber);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Level, actual.Level);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.Comment, actual.Comment);
        }

        
    }
}
