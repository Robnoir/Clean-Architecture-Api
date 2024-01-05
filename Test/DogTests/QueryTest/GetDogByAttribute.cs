using Application.Queries.Dogs.GetDogByAttribute;
using Domain.Models;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetDogsByAttributeTest
    {
        private Mock<IDogRepository> _dogRepositoryMock;
        private GetDogByAttributeQueryHandler _handler;
        private Mock<ILogger<GetDogByAttributeQueryHandler>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _dogRepositoryMock = new Mock<IDogRepository>();
            _loggerMock = new Mock<ILogger<GetDogByAttributeQueryHandler>>();
            _handler = new GetDogByAttributeQueryHandler(_dogRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_WithMatchingCriteria_ReturnsDogs()
        {
            // Arrange
            var breed = "Labrador";
            var weight = 30;
            var dogs = new List<Dog> { new Dog { Id = Guid.NewGuid(), DogBreed = breed, DogWeight = weight } };
            _dogRepositoryMock.Setup(repo => repo.GetDogByBreedAndWeight(breed, weight)).ReturnsAsync(dogs);

            var query = new GetDogByAttributeQuery(breed, weight);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotEmpty(result);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().DogBreed, Is.EqualTo(breed));
            Assert.That(result.First().DogWeight, Is.EqualTo(weight));
        }

        [Test]
        public async Task Handle_NoMatchingCriteria_ReturnsEmptyList()
        {
            // Arrange
            var breed = "Poodle";
            var weight = 10;
            _dogRepositoryMock.Setup(repo => repo.GetDogByBreedAndWeight(breed, weight)).ReturnsAsync(new List<Dog>());

            var query = new GetDogByAttributeQuery(breed, weight);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsEmpty(result);
        }
    }
}
