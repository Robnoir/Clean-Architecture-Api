using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.BirdRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class DeleteBirdByIdTest
    {
        private Mock<IBirdRepository> _mockBirdRepository;
        private Mock<ILogger<DeleteBirdByIdCommandHandler>> _mockLogger;
        private DeleteBirdByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockBirdRepository = new Mock<IBirdRepository>();
            _mockLogger = new Mock<ILogger<DeleteBirdByIdCommandHandler>>();
            _handler = new DeleteBirdByIdCommandHandler(_mockBirdRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task DeleteBirdById_ShouldRemoveBird_IfExistingBirdIsDeleted()
        {
            // Arrange
            var existingBirdId = Guid.NewGuid();
            var bird = new Bird { Id = existingBirdId };
            _mockBirdRepository.Setup(repo => repo.GetByIdAsync(existingBirdId)).ReturnsAsync(bird);
            _mockBirdRepository.Setup(repo => repo.DeleteAsync(existingBirdId)).Returns(Task.CompletedTask);

            var deleteCommand = new DeleteBirdByIdCommand(existingBirdId);

            // Act
            var result = await _handler.Handle(deleteCommand, new CancellationToken());

            // Assert
            _mockBirdRepository.Verify(repo => repo.DeleteAsync(existingBirdId), Times.Once);
            Assert.That(result.Id, Is.EqualTo(existingBirdId), "The returned bird should have the same ID as the deleted bird");
        }

        [Test]
        public void DeleteBirdById_ShouldThrowException_IfBirdNotFound()
        {
            // Arrange
            var nonExistingBirdId = Guid.NewGuid();
            _mockBirdRepository.Setup(repo => repo.GetByIdAsync(nonExistingBirdId)).ReturnsAsync((Bird)null);

            var deleteCommand = new DeleteBirdByIdCommand(nonExistingBirdId);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(deleteCommand, new CancellationToken()));
        }
    }
}
