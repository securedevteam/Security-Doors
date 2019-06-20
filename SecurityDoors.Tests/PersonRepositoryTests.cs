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
    /// Класс для тестов класса PersonRepository
    /// </summary>
    public class PersonRepositoryTests : IClassFixture<ServiceFixture>, IDisposable
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
        public PersonRepositoryTests(ServiceFixture fixture)
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
        /// Тест на проверку получения списка людей.
        /// </summary>
        [Fact]
        public async void GetPeopleListTest_Return_10()
        {
            // Arrange
            var listPeople = new List<Person>();
            var expected = 10;

            for (int i = 0; i < expected; i++)
            {
                listPeople.Add(new Person()
                {
                    FirstName = string.Empty,
                    SecondName = string.Empty,
                    LastName = string.Empty,
                    Gender = rnd.Next(),
                    Passport = string.Empty,
                    Comment = string.Empty,
                });
            }

            _context.People.AddRange(listPeople);
            _context.SaveChanges();

            // Act			
            var personList = await _dataManagerService.People.GetPeopleListAsync();
            var actual = personList.Count();

            // Assert
            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// Тест на проверку получение определенного человека.
        /// </summary>
        [Fact]
        public async void GetPersonByIdTest_Return_1()
        {
            // Arrange
            var expected = new Person()
            {
                FirstName = string.Empty,
                SecondName = string.Empty,
                LastName = string.Empty,
                Gender = rnd.Next(),
                Passport = string.Empty,
                Comment = string.Empty,
            };

            _context.Add(expected);
            _context.SaveChanges();

            // act
            var actual = await _dataManagerService.People.GetPersonByIdAsync(expected.Id);

            // assert			
            Assert.Equal(expected.id, actual.id);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.SecondName, actual.SecondName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Gender, actual.Gender);
            Assert.Equal(expected.Passport, actual.Passport);
            Assert.Equal(expected.Comment, actual.Comment);
        }

        /// <summary>
        /// Тест на проверку создания человека.
        /// </summary>
        [Fact]
        public async void CreatePersonTest_Return_True()
        {
            // Arrange
            var expected = new Person()
            {
                FirstName = string.Empty,
                SecondName = string.Empty,
                LastName = string.Empty,
                Gender = rnd.Next(),
                Passport = string.Empty,
                Comment = string.Empty,
            };

            // Act
            await _dataManagerService.People.CreateAsync(expected);
            _context.SaveChanges();

            var actual = await _dataManagerService.People.GetPersonByIdAsync(expected.Id);

            //Assert
            Assert.Equal(expected, actual);

            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.SecondName, actual.SecondName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Gender, actual.Gender);
            Assert.Equal(expected.Passport, actual.Passport);
            Assert.Equal(expected.Comment, actual.Comment);
        }

        /// <summary>
        /// Тест на проверку обновления человека.
        /// </summary>
        [Fact]
        public async void UpdatePersonTest_Return_True()
        {
            // Arrange
            var expected = new Person()
            {
                FirstName = string.Empty,
                SecondName = string.Empty,
                LastName = string.Empty,
                Gender = rnd.Next(),
                Passport = string.Empty,
                Comment = string.Empty,
            };

            _context.Add(expected);
            _context.SaveChanges();

            //Act
            var actual = await _dataManagerService.People.GetPersonByIdAsync(expected.Id);
            actual.FirstName = Guid.NewGuid().ToString();
            actual.SecondName = Guid.NewGuid().ToString();
            actual.LastName = Guid.NewGuid().ToString();
            actual.Gender = rnd.Next();
            actual.Passport = Guid.NewGuid().ToString();
            actual.Comment = Guid.NewGuid().ToString();

            _dataManagerService.People.Update(actual);
            _context.SaveChanges();

            var result = await _dataManagerService.People.GetPersonByIdAsync(actual.Id);

            //Assert
            Assert.NotEqual(expected.FirstName, result.FirstName);
            Assert.NotEqual(expected.SecondName, result.SecondName);
            Assert.NotEqual(expected.LastName, result.LastName);
            Assert.NotEqual(expected.Gender, result.Gender);
            Assert.NotEqual(expected.Passport, result.Passport);
            Assert.NotEqual(expected.Comment, result.Comment);
        }

        /// <summary>
        /// Тест на проверку удаления человека.
        /// </summary>
        [Fact]
        public async void DeletePersonTest_Return_True()
        {
            // Arrange           
            var expected = new Person()
            {
                FirstName = string.Empty,
                SecondName = string.Empty,
                LastName = string.Empty,
                Gender = rnd.Next(),
                Passport = string.Empty,
                Comment = string.Empty,
            };

            _context.Add(expected);
            _context.SaveChanges();

            // Act
            await _dataManagerService.People.DeleteAsync(expected.Id);
            var result = await _dataManagerService.People.GetPersonByIdAsync(expected.Id);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Тест на проверку сохранения человека.
        /// </summary>
        [Fact]
        public async void SavePersonTest_Return_True()
        {
            // Arrange           
            var expected = new Person()
            {
                FirstName = string.Empty,
                SecondName = string.Empty,
                LastName = string.Empty,
                Gender = rnd.Next(),
                Passport = string.Empty,
                Comment = string.Empty,
            };

            // Act
            await _dataManagerService.People.SaveAsync(expected);

            var actual = await _dataManagerService.People.GetPersonByIdAsync(expected.Id);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// Exception

        /// <summary>
        ///  Тест на проверку получения исключения при создании нового человека.
        /// </summary>
        [Fact]
        public async void CreatePersonTest_Return_Exception()
        {
            await Assert.ThrowsAnyAsync<Exception>(() => _dataManagerService.People.CreateAsync(null));
        }

        /// <summary>
        /// Тест на проверку получения исключения при обновлении человека.
        /// </summary>
        [Fact]
        public void UpdatePersonTest_Return_Exception()
        {
            Assert.ThrowsAny<Exception>(() => _dataManagerService.People.Update(null));
        }

        /// <summary>
        /// Тест на проверку получения исключения при сохранении человека.
        /// </summary>
        [Fact]
        public async void SavePersonTest_Return_Exception()
        {
            await Assert.ThrowsAnyAsync<Exception>(() => _dataManagerService.People.SaveAsync(null));
        }
    }
}