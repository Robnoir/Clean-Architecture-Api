using Application;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database.Repositories.UserRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.UserTests.CommandTest
{
    [TestFixture]
    public class AddUserTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<ILogger<AddUserCommandHandler>> _mockLogger;
        private AddUserCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockLogger = new Mock<ILogger<AddUserCommandHandler>>();
            _handler = new AddUserCommandHandler(_mockUserRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldAddUser_WhenValidDataIsProvided()
        {
            // Arrange
            var newUser = new UserDto { Username = "Robert1", Password = "Svart123!" };
            var command = new AddUserCommand(newUser);
            var expectedUser = new User { Id = Guid.NewGuid(), Username = newUser.Username };
            _mockUserRepository.Setup(repo => repo.AddUserAsync(It.IsAny<User>())).ReturnsAsync(expectedUser);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockUserRepository.Verify(repo => repo.AddUserAsync(It.Is<User>(u => u.Username == newUser.Username)), Times.Once());
            Assert.IsNotNull(result, "The result should not be null.");
            Assert.That(result.Username, Is.EqualTo(newUser.Username), "The usernames should match.");
        }

        [Test]
        public void Handle_ShouldThrowException_WhenInvalidDataIsProvided()
        {
            // Arrange
            var newUser = new UserDto { Username = "", Password = "password123" }; // Invalid username
            var command = new AddUserCommand(newUser);

            _mockUserRepository.Setup(repo => repo.AddUserAsync(It.IsAny<User>())).ThrowsAsync(new InvalidOperationException("Invalid user data"));

            // Act & Assert
            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Invalid user data"));
        }
    }
}
