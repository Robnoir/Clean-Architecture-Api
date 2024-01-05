using Application.Queries.Dogs.GetById;
using Domain.Models;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetDogByIdTests
    {
        private GetDogByIdQueryHandler _handler;
        private Mock<IDogRepository> _dogRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _dogRepositoryMock = new Mock<IDogRepository>();
            _handler = new GetDogByIdQueryHandler(_dogRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectDog()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");
            var dog = new Dog { Id = dogId, Name = "Rio" };
            _dogRepositoryMock.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync(dog);

            var query = new GetDogByIdQuery(dogId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(dogId));
            Assert.That(result.Name, Is.EqualTo("Rio"));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidDogId = Guid.NewGuid();
            _dogRepositoryMock.Setup(repo => repo.GetByIdAsync(invalidDogId)).ReturnsAsync((Dog)null);

            var query = new GetDogByIdQuery(invalidDogId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
