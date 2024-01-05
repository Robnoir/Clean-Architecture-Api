using Application.Queries.Birds.GetById;
using Domain.Models;
using Infrastructure.Database.Repositories.BirdRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdsByIdTests
    {
        private Mock<IBirdRepository> _birdRepositoryMock;
        private GetBirdByIdQueryHandler _handler;


        [SetUp]
        public void SetUp()
        {
            _birdRepositoryMock = new Mock<IBirdRepository>();
            _handler = new GetBirdByIdQueryHandler(_birdRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectBird()
        {
            // Arrange
            var birdId = Guid.NewGuid();
            var bird = new Bird { Id = birdId, Name = "Chirpy" };
            _birdRepositoryMock.Setup(repo => repo.GetByIdAsync(birdId)).ReturnsAsync(bird);

            var query = new GetBirdByIdQuery(birdId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(birdId));
            Assert.That(result.Name, Is.EqualTo("Chirpy"));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidBirdId = Guid.NewGuid();
            _birdRepositoryMock.Setup(repo => repo.GetByIdAsync(invalidBirdId)).ReturnsAsync((Bird)null);

            var query = new GetBirdByIdQuery(invalidBirdId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
