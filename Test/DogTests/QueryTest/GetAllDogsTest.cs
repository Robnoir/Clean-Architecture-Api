using Application.Queries.Dogs;
using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTest
    {
        private Mock<IDogRepository> _dogRepositoryMock;
        private GetAllDogsQueryHandler _handler;
        private Mock<ILogger<GetAllDogsQueryHandler>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _dogRepositoryMock = new Mock<IDogRepository>();
            _loggerMock = new Mock<ILogger<GetAllDogsQueryHandler>>();
            _handler = new GetAllDogsQueryHandler(_dogRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllDogs_WhenDogsExist_ReturnsAllDogs()
        {
            // Arrange
            var fakeDogs = new List<Dog> { new Dog(), new Dog() };
            _dogRepositoryMock.Setup(repo => repo.GetAllDogsAsync())
                              .ReturnsAsync(fakeDogs);

            // Act
            var query = new GetAllDogsQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            _dogRepositoryMock.Verify(repo => repo.GetAllDogsAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllDogs_WhenRepositoryReturnsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            _dogRepositoryMock.Setup(repo => repo.GetAllDogsAsync())
                              .ReturnsAsync((List<Dog>)null);

            // Act
            var query = new GetAllDogsQuery();

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(query, CancellationToken.None));
            _dogRepositoryMock.Verify(repo => repo.GetAllDogsAsync(), Times.Once);
        }
    }
}
