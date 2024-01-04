using Application.Commands.UserAnimal.UpdateUseranimal;
using Infrastructure.Database.Repositories.UserAnimalRepo;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UserAnimalTest.CommandTest
{
    public class UpdateAnimalUserTest
    {
        [TestFixture]
        internal class UpdateUserAnimalTest
        {
            private Mock<IUserAnimalRepository> _mockUserAnimalRepository;
            private Mock<ILogger<UpdateUserAnimalCommandHandler>> _mockLogger;
            private UpdateUserAnimalCommandHandler _handler;

            [SetUp]
            public void Setup()
            {
                _mockUserAnimalRepository = new Mock<IUserAnimalRepository>();
                _mockLogger = new Mock<ILogger<UpdateUserAnimalCommandHandler>>();
                _handler = new UpdateUserAnimalCommandHandler(_mockUserAnimalRepository.Object, _mockLogger.Object);
            }

            [Test]
            public async Task Handle_ShouldReturnTrue_WhenUserAnimalRelationshipIsUpdated()
            {
                // Arrange
                var userId = Guid.NewGuid();
                var currentAnimalId = Guid.NewGuid();
                var newAnimalId = Guid.NewGuid();
                _mockUserAnimalRepository.Setup(repo => repo.UpdateUserAnimalAsync(userId, currentAnimalId, newAnimalId))
                                         .Returns(Task.CompletedTask);

                var command = new UpdateUserAnimalCommand(userId, currentAnimalId, newAnimalId);

                // Act
                var result = await _handler.Handle(command, CancellationToken.None);

                // Assert
                Assert.IsTrue(result);
                _mockLogger.Verify(log => log.Log(
                    It.Is<LogLevel>(level => level == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Successfully updated")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                    Times.Once);
            }

            [Test]
            public void Handle_ShouldReturnFalse_WhenUpdateFailsDueToNonExistentEntities()
            {
                // Arrange
                var userId = Guid.NewGuid();
                var currentAnimalId = Guid.NewGuid();
                var newAnimalId = Guid.NewGuid();
                _mockUserAnimalRepository
                        .Setup(repo => repo.UpdateUserAnimalAsync(userId, currentAnimalId, newAnimalId))
                        .ThrowsAsync(new InvalidOperationException("User or AnimalModel not found"));


                var command = new UpdateUserAnimalCommand(userId, currentAnimalId, newAnimalId);

                // Act & Assert
                Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
            }

        }





    }
}

