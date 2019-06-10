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

            // Act
            _context.Cards.Add(expected);
            _context.SaveChanges();

            var actual = _dataManagerService.Cards.GetCardById(expected.Id);

            // Assert
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.UniqueNumber, actual.UniqueNumber);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Level, actual.Level);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.Comment, actual.Comment);
        }

        /// <summary>
        /// Тест на получение карты по уникальному номеру.
        /// </summary>
        [Fact]
        public void GetCardByUniqueNumberTest_Return_True()
        {
            // Arrange
            var card = new Card()
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Status = rnd.Next(),
                Level = rnd.Next(),
                Location = false,
                Comment = string.Empty
            };

            //Act
            _context.Cards.Add(card);
            _context.SaveChanges();
            var uniqueNumberCard = _dataManagerService.Cards.GetCardByUniqueNumber(card.UniqueNumber);

            //Assert
            Assert.Equal(card.UniqueNumber, uniqueNumberCard.UniqueNumber);
        }

        /// <summary>
        ///  Тест на проверку создания новой карты.
        /// </summary>
        [Fact]
        public void CreateCardTest_Return_True()
        {
            // Arrange
            var card = new Card()
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Status = rnd.Next(),
                Level = rnd.Next(),
                Location = false,
                Comment = string.Empty
            };

            //Act
            _context.Cards.Add(card);
            _context.SaveChanges();
            var createCard = _dataManagerService.Cards.GetCardById(card.Id);

            //Assert
            Assert.NotNull(createCard);
        }

        /// <summary>
        /// Тест на проверку удаления карты.
        /// </summary>
        [Fact]
        public void DeletCardTest_Return_True()
        {
            //Arrange
            var card = new Card()
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Status = rnd.Next(),
                Level = rnd.Next(),
                Location = false,
                Comment = string.Empty
            };
            _context.Cards.Add(card);
            _context.SaveChanges();

            //Act
            _dataManagerService.Cards.Delete(card.Id);
            var cardDelete = _dataManagerService.Cards.GetCardById(card.Id);

            //Assert
            Assert.Null(cardDelete);
        }

        /// <summary>
        /// Тест на проверку сохранения карты.
        /// </summary>
        [Fact]
        public void SaveCardTest_Return_True()
        {
            // Arrange
            var card = new Card()
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Status = rnd.Next(),
                Level = rnd.Next(),
                Location = false,
                Comment = string.Empty
            };

            //Act
            _dataManagerService.Cards.Save(card);
            var cardSave = _dataManagerService.Cards.GetCardById(card.Id);

            //Assert
            Assert.Equal(card, cardSave);
        } 
        
        /// <summary>
        /// Тест на проверку обновления карты
        /// </summary>
        [Fact]        
        public void UpdateCardTest_Return_True()
        {
            //Arrange
            var card = new Card()
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Status = rnd.Next(),
                Level = rnd.Next(),
                Location = false,
                Comment = string.Empty
            };
            _context.Cards.Add(card);
            _context.SaveChanges();
            
            //Act
            var cardUpdate = _dataManagerService.Cards.GetCardById(card.Id);
            cardUpdate.UniqueNumber = Guid.NewGuid().ToString();
            cardUpdate.Status = rnd.Next();
            cardUpdate.Level = rnd.Next(1, 10);
            cardUpdate.Location = true;
            cardUpdate.Comment = Guid.NewGuid().ToString();

            _dataManagerService.Cards.Update(cardUpdate);

            var cardUpdateInDataBase = _dataManagerService.Cards.GetCardById(card.Id);
            
            //Assert            
            Assert.NotEqual(card, cardUpdateInDataBase);
        }
    }
}
