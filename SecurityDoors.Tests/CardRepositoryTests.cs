using Xunit;

namespace SecurityDoors.Tests
{
    /// <summary>
    /// Класс для тестов класса CardRepository.
    /// </summary>
    public class CardRepositoryTests
    {
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
    }
}
