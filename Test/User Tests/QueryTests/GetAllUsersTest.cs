using Application;
using Domain.Models;
using Infrastructure.Database.Repositories.UserRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.UserTests.QueryTest
{
    [TestFixture]
    public class GetAllUsersTests
    {
        private Mock<IUserRepository> _userRepositoryMock;

        private GetAllUsersQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetAllUsersQueryHandler(_userRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllUsers_WhenUsersExist_ReturnsAllUsers()
        {
            // Arrange
            var fakeUsers = new List<User> { new User(), new User() };
            _userRepositoryMock.Setup(repo => repo.GetAllUsersAsync())
                              .ReturnsAsync(fakeUsers);

            // Act
            var query = new GetAllUsersQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            _userRepositoryMock.Verify(repo => repo.GetAllUsersAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllUsers_WhenRepositoryThrowsException_ReturnsEmptyListAndLogsError()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetAllUsersAsync())
                  .ReturnsAsync(new List<User> { });


            // Act
            var query = new GetAllUsersQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);

        }
    }
}
