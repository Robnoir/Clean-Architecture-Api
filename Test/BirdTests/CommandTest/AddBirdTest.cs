using Application.Commands.Birds.AddBird;
using Application.Dtos;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    public class AddBirdTest
    {
        private MockDatabase _mockDatabase;
        private AddBirdCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialize mock database and handler before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddBirdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ChecksAddedBird_ReturnTrue()
        {
            // Arrange
            var command = new AddBirdCommand(new BirdDto { Name = "Pete" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var newBirdToDB = _mockDatabase.Birds.FirstOrDefault(bird => bird.Name == "Pete");

            Assert.That(newBirdToDB, Is.Not.Null);
            Assert.That(newBirdToDB.Name, Is.EqualTo("Pete"));
        }
    }
}
