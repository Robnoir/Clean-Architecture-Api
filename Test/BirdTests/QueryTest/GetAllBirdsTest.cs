using NUnit.Framework;
using Moq;
using Application.Queries.Birds.GetAll;
using Infrastructure.Database.Repositories.BirdRepo;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsTests
    {
        private Mock<IBirdRepository> _birdRepositoryMock;
        private GetAllBirdsQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _birdRepositoryMock = new Mock<IBirdRepository>();
            _handler = new GetAllBirdsQueryHandler(_birdRepositoryMock.Object);
        }


        [Test]
        public async Task GetAllBirds_WhenBirdsExist_ReturnsAllBirds()
        {
            // Arrange
            var fakeBirds = new List<Bird> { new Bird(), new Bird() }; // Ensure you initialize the Bird properties if necessary
            _birdRepositoryMock.Setup(repo => repo.GetAllBirdsAsync()).ReturnsAsync(fakeBirds);

            // Act
            var query = new GetAllBirdsQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            _birdRepositoryMock.Verify(repo => repo.GetAllBirdsAsync(), Times.Once);
        }

        [Test]
        public void GetAllBirds_WhenRepositoryThrowsException_ThrowsException()
        {
            // Arrange
            _birdRepositoryMock.Setup(repo => repo.GetAllBirdsAsync()).ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            var query = new GetAllBirdsQuery();
            Assert.ThrowsAsync<Exception>(() => _handler.Handle(query, CancellationToken.None));

        }
    }
}
