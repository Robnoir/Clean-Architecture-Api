using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database.Repositories.BirdRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    internal class UpdateBirdTest
    {
        private Mock<IBirdRepository> _mockBirdRepository;
        private Mock<ILogger<UpdateBirdByIdCommandHandler>> _mockLogger;
        private UpdateBirdByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockBirdRepository = new Mock<IBirdRepository>();
            _mockLogger = new Mock<ILogger<UpdateBirdByIdCommandHandler>>();
            _handler = new UpdateBirdByIdCommandHandler(_mockBirdRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task UpdateBirdById_ShouldUpdateBird_IfBirdExists()
        {
            var birdId = Guid.NewGuid();
            var bird = new Bird { Id = birdId, Name = "Old Name" };
            var updatedBird = new BirdDto { Name = "New Name" };
            _mockBirdRepository.Setup(repo => repo.GetByIdAsync(birdId)).ReturnsAsync(bird);
            _mockBirdRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Bird>())).Returns(Task.CompletedTask);

            var command = new UpdateBirdByIdCommand(updatedBird, birdId);
            var result = await _handler.Handle(command, CancellationToken.None);

            _mockBirdRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Bird>()), Times.Once);
            Assert.That(result.Name, Is.EqualTo("New Name"));
        }

        [Test]
        public async Task UpdateBirdById_ShouldReturnNull_IfBirdDoesNotExist()
        {
            var birdId = Guid.NewGuid();
            var updatedBird = new BirdDto { Name = "New Name" };
            _mockBirdRepository.Setup(repo => repo.GetByIdAsync(birdId)).ReturnsAsync((Bird)null);

            var command = new UpdateBirdByIdCommand(updatedBird, birdId);
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNull(result);
        }
    }
}
