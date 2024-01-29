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

namespace Test.User_Tests.CommandTests
{
    [TestFixture]
    internal class UpdateUserTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<ILogger<UpdateUserByIdCommandHandler>> _mockLogger;
        private UpdateUserByIdCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockLogger = new Mock<ILogger<UpdateUserByIdCommandHandler>>();
            _handler = new UpdateUserByIdCommandHandler(_mockUserRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldUpdateUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var existingUser = new User { Id = userId, Username = "OldUsername", PasswordHash = "OldHash" };
            var updatedUserDto = new UserDto { Username = "NewUsername", Password = "NewPassword" };
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(existingUser);
            _mockUserRepository.Setup(repo => repo.UpdateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var command = new UpdateUserByIdCommand(updatedUserDto, userId, "NewPassword");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Username, Is.EqualTo("NewUsername"));
            // Additional assertions for password update can be added if needed
        }

        [Test]
        public void Handle_ShouldThrowInvalidOperationException_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var updatedUserDto = new UserDto { Username = "NewUsername", Password = "NewPassword" };
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync((User)null);

            var command = new UpdateUserByIdCommand(updatedUserDto, userId, "NewPassword");

            // Act & Assert
            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo($"User with ID {userId} was not found."));
        }
    }

}
