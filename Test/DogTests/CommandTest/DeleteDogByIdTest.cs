using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    internal class DeleteDogByIdTest
    {
        private Mock<IDogRepository> _mockDogRepository;
        private Mock<ILogger<DeleteDogByIdCommandHandler>> _mockLogger;
        private DeleteDogByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockDogRepository = new Mock<IDogRepository>();
            _mockLogger = new Mock<ILogger<DeleteDogByIdCommandHandler>>();
            _handler = new DeleteDogByIdCommandHandler(_mockDogRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task DeleteDogById_ShouldRemoveDog_IfExistingDogIsDeleted()
        {
            // Arrange
            var existingDogId = Guid.NewGuid();
            _mockDogRepository.Setup(repo => repo.GetByIdAsync(existingDogId)).ReturnsAsync(new Dog { Id = existingDogId });
            _mockDogRepository.Setup(repo => repo.DeleteAsync(existingDogId)).Returns(Task.CompletedTask);

            var deleteCommand = new DeleteDogByIdCommand(existingDogId);

            // Act
            var result = await _handler.Handle(deleteCommand, new CancellationToken());

            // Assert
            _mockDogRepository.Verify(repo => repo.DeleteAsync(existingDogId), Times.Once);
        }

        [Test]
        public void DeleteDogById_ShouldThrowException_IfDogNotFound()
        {
            // Arrange
            var nonExistingDogId = Guid.NewGuid();
            _mockDogRepository.Setup(repo => repo.GetByIdAsync(nonExistingDogId)).ReturnsAsync((Dog)null);

            var deleteCommand = new DeleteDogByIdCommand(nonExistingDogId);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(deleteCommand, new CancellationToken()));
        }
    }
}
