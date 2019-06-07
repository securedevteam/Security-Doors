using Microsoft.EntityFrameworkCore;
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
    public class CardRepositoryTests : IClassFixture<ServiceFixture>
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;
        private readonly TestContext _context;

        public CardRepositoryTests(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;

            _context = _serviceProvider.GetRequiredService<TestContext>();
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
        }

        /// <summary>
        /// Примитивный тест.
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var expected = 3;

            // Act
            var actual = 3;

            // Assert
            Assert.Equal(expected, actual);
        }

        //private DbContextOptions<ApplicationContext> GetContextOptions()
        //{
        //    return new DbContextOptionsBuilder<ApplicationContext>()
        //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //        .Options;
        //}

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void GetCardsListTests_Return_10()
        {
            //using (var context = new ApplicationContext(GetContextOptions()))
            //{
                // Arrange
                var listCards = new List<Card>();
                var expected = 10;

                for (int i = 0; i < expected; i++)
                {
                    listCards.Add(new Card()
                    {
                        UniqueNumber = "1",
                        Status = 1,
                        Level = 1,
                        Location = false,
                        Comment = string.Empty
                    });
                }

                // Act
                _context.Cards.AddRange(listCards);
                _context.SaveChanges();

                //var cardList = _dataManagerService.Cards.GetCardsList().ToList();
                //var actual = cardList.Count();

                //// Assert
                //Assert.Equal(expected, actual);
            //}


            

        }
    }
}
