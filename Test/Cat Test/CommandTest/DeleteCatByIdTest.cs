using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using Infrastructure.Database.Repositories.CatRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Cat_Test.CommandTest
{
    [TestFixture]
    internal class DeleteCatByIdTest
    {
        private Mock<ICatRepository> _mockCatRepository;
        private Mock<ILogger<DeleteCatByIdCommandHandler>> _mockLogger;
        private DeleteCatByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockCatRepository = new Mock<ICatRepository>();
            _mockLogger = new Mock<ILogger<DeleteCatByIdCommandHandler>>();
            _handler = new DeleteCatByIdCommandHandler(_mockCatRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task DeleteCatById_ShouldRemoveCat_IfExistingCatIsDeleted()
        {
            // Arrange
            var existingCatId = Guid.NewGuid();
            _mockCatRepository.Setup(repo => repo.GetByIdAsync(existingCatId)).ReturnsAsync(new Cat { Id = existingCatId });
            _mockCatRepository.Setup(repo => repo.DeleteAsync(existingCatId)).Returns(Task.CompletedTask);

            var deleteCommand = new DeleteCatByIdCommand(existingCatId);

            // Act
            var result = await _handler.Handle(deleteCommand, new CancellationToken());

            // Assert
            _mockCatRepository.Verify(repo => repo.DeleteAsync(existingCatId), Times.Once);
        }

        [Test]
        public void DeleteCatById_ShouldThrowException_IfCatNotFound()
        {
            // Arrange
            var nonExistingCatId = Guid.NewGuid();
            _mockCatRepository.Setup(repo => repo.GetByIdAsync(nonExistingCatId)).ReturnsAsync((Cat)null);

            var deleteCommand = new DeleteCatByIdCommand(nonExistingCatId);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(deleteCommand, new CancellationToken()));
        }
    }
}
