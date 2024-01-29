using Application.Commands.UserAnimal.RemoveUserAnimal;
using Infrastructure.Database.Repositories.UserAnimalRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.UserAnimalTest.CommandTest
{
    [TestFixture]
    public class Delete_UserAnimalTest
    {
        private Mock<IUserAnimalRepository> _mockUserAnimalRepository;
        private Mock<ILogger<RemoveUserAnimalCommandHandler>> _mockLogger;
        private RemoveUserAnimalCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserAnimalRepository = new Mock<IUserAnimalRepository>();
            _mockLogger = new Mock<ILogger<RemoveUserAnimalCommandHandler>>();
            _handler = new RemoveUserAnimalCommandHandler(_mockUserAnimalRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task RemoveUserAnimal_ShouldReturnTrue_WhenRelationshipExists()
        {
            var userId = Guid.NewGuid();
            var animalId = Guid.NewGuid();
            _mockUserAnimalRepository.Setup(repo => repo.RemoveUserAnimalAsync(userId, animalId)).Returns(Task.CompletedTask);

            var command = new RemoveUserAnimalCommand(userId, animalId);

            var result = await _handler.Handle(command, new CancellationToken());

            Assert.IsTrue(result, "Handler should return true indicating successful removal.");
        }

        [Test]
        public async Task RemoveUserAnimal_ShouldComplete_WhenRelationshipDoesNotExist()
        {
            var userId = Guid.NewGuid();
            var animalId = Guid.NewGuid();
            _mockUserAnimalRepository.Setup(repo => repo.RemoveUserAnimalAsync(userId, animalId)).Returns(Task.CompletedTask);

            var command = new RemoveUserAnimalCommand(userId, animalId);

            Assert.DoesNotThrowAsync(() => _handler.Handle(command, new CancellationToken()));
        }
    }
}
