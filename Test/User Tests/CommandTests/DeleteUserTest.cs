using Application;
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
    public class DeleteUserTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<ILogger<DeleteUserByIdCommandHandle>> _mockLogger;
        private DeleteUserByIdCommandHandle _handler;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockLogger = new Mock<ILogger<DeleteUserByIdCommandHandle>>();
            _handler = new DeleteUserByIdCommandHandle(_mockUserRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task DeleteUserById_ShouldRemoveUser_IfExistingUserIsDeleted()
        {
            // Arrange
            var existingUserId = Guid.NewGuid();
            var user = new User { Id = existingUserId };
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(existingUserId)).ReturnsAsync(user);
            _mockUserRepository.Setup(repo => repo.DeleteUserAsync(existingUserId)).Returns(Task.CompletedTask);

            var command = new DeleteUserByIdCommand(existingUserId);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            _mockUserRepository.Verify(repo => repo.DeleteUserAsync(existingUserId), Times.Once);
            Assert.That(result.Id, Is.EqualTo(existingUserId));
        }

        [Test]
        public void DeleteUserById_ShouldThrowException_IfUserNotFound()
        {
            // Arrange
            var nonExistingUserId = Guid.NewGuid();
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(nonExistingUserId)).ReturnsAsync((User)null);

            var command = new DeleteUserByIdCommand(nonExistingUserId);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, new CancellationToken()));
        }
    }
}
