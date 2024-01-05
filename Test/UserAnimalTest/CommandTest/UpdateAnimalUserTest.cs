using NUnit.Framework;
using Moq;
using Application.Commands.UserAnimal.UpdateUseranimal;
using Infrastructure.Database.Repositories.UserAnimalRepo;
using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Test.UserAnimalTest.CommandTest
{
    [TestFixture]
    public class UpdateUserAnimalTest
    {
        private Mock<IUserAnimalRepository> _mockUserAnimalRepository;
        private UpdateUserAnimalCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserAnimalRepository = new Mock<IUserAnimalRepository>();
            var mockLogger = new Mock<ILogger<UpdateUserAnimalCommandHandler>>();
            _handler = new UpdateUserAnimalCommandHandler(_mockUserAnimalRepository.Object, mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnTrue_WhenUserAnimalRelationshipIsUpdated()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var currentAnimalId = Guid.NewGuid();
            var newAnimalId = Guid.NewGuid();

            // Assuming UpdateUserAnimalAsync returns void and updates the database
            _mockUserAnimalRepository.Setup(repo => repo.UpdateUserAnimalAsync(userId, currentAnimalId, newAnimalId))
                                     .Returns(Task.CompletedTask);

            var command = new UpdateUserAnimalCommand(userId, currentAnimalId, newAnimalId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Handle_ShouldReturnFalse_WhenUpdateFails()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var currentAnimalId = Guid.NewGuid();
            var newAnimalId = Guid.NewGuid();

            // Simulating an update failure
            _mockUserAnimalRepository.Setup(repo => repo.UpdateUserAnimalAsync(userId, currentAnimalId, newAnimalId))
                                     .ThrowsAsync(new Exception("Update failed due to XYZ reason"));

            var command = new UpdateUserAnimalCommand(userId, currentAnimalId, newAnimalId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsFalse(result);
        }

    }
}
