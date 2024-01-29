using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
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
    internal class UpdateCatTest
    {
        private Mock<ICatRepository> _mockCatRepository;
        private Mock<ILogger<UpdateCatByIdCommandHandler>> _mockLogger;
        private UpdateCatByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockCatRepository = new Mock<ICatRepository>();
            _mockLogger = new Mock<ILogger<UpdateCatByIdCommandHandler>>();
            _handler = new UpdateCatByIdCommandHandler(_mockCatRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldUpdateCat_WhenCatExists()
        {
            // Arrange
            var catId = Guid.NewGuid();
            var existingCat = new Cat { Id = catId, Name = "Old Cat" };
            _mockCatRepository.Setup(repo => repo.GetByIdAsync(catId)).ReturnsAsync(existingCat);
            _mockCatRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Cat>())).Returns(Task.CompletedTask);

            var command = new UpdateCatByIdCommand(new CatDto { Name = "New Cat" }, catId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("New Cat"));
        }

        [Test]
        public async Task Handle_ShouldReturnNull_WhenCatDoesNotExist()
        {
            // Arrange
            var catId = Guid.NewGuid();
            _mockCatRepository.Setup(repo => repo.GetByIdAsync(catId)).ReturnsAsync((Cat)null);

            var command = new UpdateCatByIdCommand(new CatDto { Name = "New Cat" }, catId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
