using Application.Commands.Dogs;
using Application.Dtos;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    internal class AddDogTest
    {
        private MockDatabase _mockDatabase;
        private AddDogCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {

            //Initializes the mockdatabase and handler before every test
            _mockDatabase = new MockDatabase();
            _handler = new AddDogCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ChecksAddedDog_ReturnTrue()
        {
            // Arrange
            var command = new AddDogCommand(new DogDto { Name = "Rio" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var newDogToDB = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Name == "Rio");

            Assert.IsNotNull(newDogToDB);
            Assert.That(newDogToDB.Name, Is.EqualTo("Rio"));
        }
    }
}
