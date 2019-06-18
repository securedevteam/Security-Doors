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
        private readonly ClearingDataContext _clearingDataContext;

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

            _clearingDataContext = new ClearingDataContext(_context);
        }

        public void Dispose()
        {
            _clearingDataContext.Clear();
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

            _context.Cards.AddRange(listCards);
            _context.SaveChanges();

            // Act
            //var cardList = _dataManagerService.Cards.GetCardsList().ToList(); // TODO: Асинхронность.
            //var actual = cardList.Count();

            // Assert
            //Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Тест на проверку получения определенной карты.
        /// </summary>
        [Fact]
        public void GetCardsByIdTest_Return_1()
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

            _context.Cards.Add(expected);
            _context.SaveChanges();

            // Act
            //var actual = _dataManagerService.Cards.GetCardById(expected.Id);

            //// Assert
            //Assert.Equal(expected.Id, actual.Id);
            //Assert.Equal(expected.UniqueNumber, actual.UniqueNumber);
            //Assert.Equal(expected.Status, actual.Status);
            //Assert.Equal(expected.Level, actual.Level);
            //Assert.Equal(expected.Location, actual.Location);
            //Assert.Equal(expected.Comment, actual.Comment);
        }

        /// <summary>
        /// Тест на получение карты по уникальному номеру.
        /// </summary>
        [Fact]
        public void GetCardByUniqueNumberTest_Return_True()
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

            _context.Cards.Add(expected);
            _context.SaveChanges();

            // Act
            //var actual = _dataManagerService.Cards.GetCardByUniqueNumber(expected.UniqueNumber);

            //// Assert
            //Assert.Equal(expected.Id, actual.Id);
            //Assert.Equal(expected.UniqueNumber, actual.UniqueNumber);
            //Assert.Equal(expected.Status, actual.Status);
            //Assert.Equal(expected.Level, actual.Level);
            //Assert.Equal(expected.Location, actual.Location);
            //Assert.Equal(expected.Comment, actual.Comment);
        }

        /// <summary>
        /// Тест на проверку создания новой карты.
        /// </summary>
        [Fact]
        public void CreateCardTest_Return_True()
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
            //_dataManagerService.Cards.CreateAsync(expected);
            //_context.SaveChanges();

            //var actual = _dataManagerService.Cards.GetCardById(expected.Id);

            //// Assert
            //Assert.Equal(expected, actual);

            //Assert.Equal(expected.Id, actual.Id);
            //Assert.Equal(expected.UniqueNumber, actual.UniqueNumber);
            //Assert.Equal(expected.Status, actual.Status);
            //Assert.Equal(expected.Level, actual.Level);
            //Assert.Equal(expected.Location, actual.Location);
            //Assert.Equal(expected.Comment, actual.Comment);
        }

        /// <summary>
        /// Тест на проверку удаления карты.
        /// </summary>
        [Fact]
        public void DeletCardTest_Return_True()
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

            _context.Cards.Add(expected);
            _context.SaveChanges();

            // Act
            //_dataManagerService.Cards.Delete(expected.Id);
            //var result = _dataManagerService.Cards.GetCardById(expected.Id);

            //// Assert
            //Assert.Null(result);
        }

        /// <summary>
        /// Тест на проверку сохранения карты.
        /// </summary>
        [Fact]
        public void SaveCardTest_Return_True()
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
            //_dataManagerService.Cards.SaveAsync(expected);
            //var actual = _dataManagerService.Cards.GetCardById(expected.Id);

            //// Assert
            //Assert.Equal(expected, actual);

            //Assert.Equal(expected.Id, actual.Id);
            //Assert.Equal(expected.UniqueNumber, actual.UniqueNumber);
            //Assert.Equal(expected.Status, actual.Status);
            //Assert.Equal(expected.Level, actual.Level);
            //Assert.Equal(expected.Location, actual.Location);
            //Assert.Equal(expected.Comment, actual.Comment);
        } 
        
        /// <summary>
        /// Тест на проверку обновления карты.
        /// </summary>
        [Fact]        
        public void UpdateCardTest_Return_True()
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

            _context.Cards.Add(expected);
            _context.SaveChanges();

            //Act
            //var actual = _dataManagerService.Cards.GetCardById(expected.Id);

            //actual.UniqueNumber = Guid.NewGuid().ToString();
            //actual.Status = rnd.Next();
            //actual.Level = rnd.Next();
            //actual.Location = true;
            //actual.Comment = Guid.NewGuid().ToString();

            //_dataManagerService.Cards.Update(actual);
            //_context.SaveChanges();

            //var result = _dataManagerService.Cards.GetCardById(actual.Id);

            //Assert            
            //Assert.NotEqual(expected, result);

            //Assert.NotEqual(expected.UniqueNumber, result.UniqueNumber);
            //Assert.NotEqual(expected.Status, result.Status);
            //Assert.NotEqual(expected.Level, result.Level);
            //Assert.NotEqual(expected.Location, result.Location);
            //Assert.NotEqual(expected.Comment, result.Comment);
        }
    }
}
