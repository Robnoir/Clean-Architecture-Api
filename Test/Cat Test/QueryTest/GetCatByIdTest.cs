using Application.Queries.Cats.GetById;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Test.Cat_Test.QueryTest
{
    [TestFixture]
    public class GetCatByIdTest
    {
        private GetCatByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            //Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetCatByIdQueryHandler(_mockDatabase);

        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectCat()
        {
            //Arrange 
            var catId = new Guid("12345678-1234-5678-1234-567812345611");
            var query = new GetCatByIdQuery(catId);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);


            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(catId));

        }
        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidCatId = Guid.NewGuid();

            var query = new GetCatByIdQuery(invalidCatId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

    }
}
