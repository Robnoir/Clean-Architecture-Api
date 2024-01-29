using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure;
using Infrastructure.Database;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    internal class UpdateDogTest
    {
        private Mock<IDogRepository> _mockDogRepository;
        private Mock<ILogger<UpdateDogByIdCommandHandler>> _mockLogger;
        private UpdateDogByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockDogRepository = new Mock<IDogRepository>();
            _mockLogger = new Mock<ILogger<UpdateDogByIdCommandHandler>>();
            _handler = new UpdateDogByIdCommandHandler(_mockDogRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldUpdateDog_WhenDogExists()
        {
            var dogId = Guid.NewGuid();
            var existingDog = new Dog { Id = dogId, Name = "Old Name" };
            var updatedDogDto = new DogDto { Name = "New Name" };
            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync(existingDog);
            _mockDogRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Dog>())).Returns(Task.CompletedTask);

            var command = new UpdateDogByIdCommand(updatedDogDto, dogId);
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("New Name"));
        }

        [Test]
        public async Task Handle_ShouldReturnNull_WhenDogDoesNotExist()
        {
            var dogId = Guid.NewGuid();
            var updatedDogDto = new DogDto { Name = "New Name" };
            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync((Dog)null);

            var command = new UpdateDogByIdCommand(updatedDogDto, dogId);
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNull(result);
        }
    }
}
