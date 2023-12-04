using System.Diagnostics.CodeAnalysis;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using Application.Commands.Dogs;
using Infrastructure.Database;
using Application.Queries.Dogs;


namespace Test.GetAllDogsTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetAllDogsQueryHandler _handler;
        private MockDatabase _mockDatabase;
        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new(_mockDatabase);
        }
        [Test]
        public async Task GetAllDogs_ShouldReturnallDogsInList()
        {
            // Arrange
            int expectedNumberOfDogs = 5; // Checks how many dogs is in the mockDB List

            // Act
            var result = await _handler.Handle(new GetAllDogsQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(expectedNumberOfDogs));


        }

    }
}