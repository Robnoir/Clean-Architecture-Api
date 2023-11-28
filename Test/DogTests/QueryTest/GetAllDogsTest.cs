using System.Diagnostics.CodeAnalysis;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using Infrastructure.Database;


namespace Test.GetAllDogsTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTests
    {
        private GetDogByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;
        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new (_mockDatabase);
        }
        [Test]
        public async Task GetAllDogs_ShouldReturnallDogsInList()
        {
            // Arrange
        

            // Act
           var result = await _handler.Handle(new GetAllDogsQuery(), CancellationToken.None);


            // Assert
            Assert.NotNull(result);



        }

    }
}