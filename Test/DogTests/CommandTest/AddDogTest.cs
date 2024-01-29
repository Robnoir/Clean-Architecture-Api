using Application.Commands.Dogs;
using Application.Dtos;
using Domain.Models;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    internal class AddDogTest
    {
        private Mock<IDogRepository> _mockDogRepository;
        private Mock<ILogger<AddDogCommandHandler>> _mockLogger;
        private IRequestHandler<AddDogCommand, Dog> _handler;

        [SetUp]
        public void SetUp()
        {
            _mockDogRepository = new Mock<IDogRepository>();
            _mockLogger = new Mock<ILogger<AddDogCommandHandler>>();
            _handler = new AddDogCommandHandler(_mockDogRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldAddDog_WhenValidDataIsProvided()
        {
            var dogDto = new DogDto
            {
                Name = "Rio",
                Breed = "Weenerdog",
                Weight = 30
            };
            var command = new AddDogCommand(dogDto);
            var expectedDog = new Dog
            {
                Id = Guid.NewGuid(),
                Name = dogDto.Name,
                DogBreed = dogDto.Breed,
                DogWeight = dogDto.Weight
            };
            _mockDogRepository.Setup(repo => repo.AddAsync(It.IsAny<Dog>())).ReturnsAsync(expectedDog);

            var result = await _handler.Handle(command, CancellationToken.None);

            _mockDogRepository.Verify(repo => repo.AddAsync(It.Is<Dog>(d => d.Name == dogDto.Name)), Times.Once());
            Assert.That(result.Name, Is.EqualTo(dogDto.Name));
            Assert.That(result.DogBreed, Is.EqualTo(dogDto.Breed));
            Assert.That(result.DogWeight, Is.EqualTo(dogDto.Weight));
        }

        [Test]
        public void Handle_ShouldThrowException_WhenInvalidDataIsProvided()
        {
            var dogDto = new DogDto
            {
                Name = "", // Invalid data: empty name
                Breed = "Weenerdog",
                Weight = 30
            };
            var command = new AddDogCommand(dogDto);

            _mockDogRepository.Setup(repo => repo.AddAsync(It.IsAny<Dog>())).ThrowsAsync(new InvalidOperationException("Invalid dog data"));

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Invalid dog data"));
        }
    }
}
