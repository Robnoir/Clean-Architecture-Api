using Application.Queries.Birds.GetByAttribute;
using Domain.Models;
using Infrastructure.Database.Repositories.BirdRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByColorTests
    {
        private Mock<IBirdRepository> _birdRepositoryMock;
        private GetBirdByAttributeQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _birdRepositoryMock = new Mock<IBirdRepository>();
            _handler = new GetBirdByAttributeQueryHandler(_birdRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_BirdsFound_ReturnsBirds()
        {
            // Arrange
            var color = "Red";
            var birds = new List<Bird> { new Bird { Name = "Cardinal", BirdColor = "Red" } };
            _birdRepositoryMock.Setup(repo => repo.GetBirdByColorAsync(color)).ReturnsAsync(birds);

            var query = new GetBirdByAttributeQuery(color);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.That(result[0].Name, Is.EqualTo("Cardinal"));
            _birdRepositoryMock.Verify(repo => repo.GetBirdByColorAsync(color), Times.Once);
        }

        [Test]
        public async Task Handle_NoBirdsFound_ReturnsEmptyList()
        {
            // Arrange
            var color = "Blue";
            _birdRepositoryMock.Setup(repo => repo.GetBirdByColorAsync(color)).ReturnsAsync(new List<Bird>());

            var query = new GetBirdByAttributeQuery(color);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
            _birdRepositoryMock.Verify(repo => repo.GetBirdByColorAsync(color), Times.Once);
        }
    }
}
