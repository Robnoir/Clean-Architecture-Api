using Application.Commands.UserAnimal.AddUseranimal;
using Application.Dtos;
using Domain.Models;
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
    public class AddUserAnimalTest
    {
        private Mock<IUserAnimalRepository> _mockUserAnimalRepository;
        private Mock<ILogger<AddUserAnimalCommandHandler>> _mockLogger;
        private AddUserAnimalCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockUserAnimalRepository = new Mock<IUserAnimalRepository>();
            _mockLogger = new Mock<ILogger<AddUserAnimalCommandHandler>>();
            _handler = new AddUserAnimalCommandHandler(_mockUserAnimalRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldAddUserAnimal_WhenValidDataIsProvided()
        {
            var userId = Guid.NewGuid();
            var animalId = Guid.NewGuid();
            var command = new AddUserAnimalCommand { UserId = userId, AnimalId = animalId };
            var userAnimal = new UserAnimal { UserId = userId, AnimalId = animalId };
            _mockUserAnimalRepository.Setup(repo => repo.AddUserAnimalAsync(userId, animalId)).ReturnsAsync(userAnimal);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.AnimalId, Is.EqualTo(animalId));
        }

        [Test]
        public void Handle_ShouldThrowException_WhenUserOrAnimalNotFound()
        {
            var userId = Guid.NewGuid();
            var animalId = Guid.NewGuid();
            var command = new AddUserAnimalCommand { UserId = userId, AnimalId = animalId };
            _mockUserAnimalRepository
                .Setup(repo => repo.AddUserAnimalAsync(userId, animalId))
                .ThrowsAsync(new ArgumentException("User or Animal not found"));

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Is.EqualTo("User or Animal not found"));
        }
    }
}
