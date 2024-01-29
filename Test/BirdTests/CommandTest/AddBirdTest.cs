using Application.Commands.Birds.AddBird;
using Infrastructure.Database.Repositories.BirdRepo;
using Moq;
using Application.Dtos;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdTest
    {
        private Mock<IBirdRepository> _mockBirdRepository;
        private Mock<ILogger<AddBirdCommandHandler>> _mockLogger;
        private AddBirdCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialize mock repository before each test
            _mockBirdRepository = new Mock<IBirdRepository>();
            // Initialize a mock logger
            _mockLogger = new Mock<ILogger<AddBirdCommandHandler>>();
            // Create the handler with the mock repository and mock logger
            _handler = new AddBirdCommandHandler(_mockBirdRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task AddBird_ShouldCallAddAsync_WhenValidDataIsProvided()
        {
            // Arrange
            var birdDto = new BirdDto { Name = "Pete" };
            var command = new AddBirdCommand(birdDto);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockBirdRepository.Verify(repo => repo.AddAsync(It.Is<Bird>(b => b.Name == "Pete")), Times.Once());
        }

        [Test]
        public void AddBird_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var birdDto = new BirdDto { Name = "Pete" };
            var command = new AddBirdCommand(birdDto);
            _mockBirdRepository.Setup(repo => repo.AddAsync(It.IsAny<Bird>())).ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () =>
                await _handler.Handle(command, CancellationToken.None)
            );
            Assert.That(ex.Message, Is.EqualTo("Database error"));
        }
    }
}
