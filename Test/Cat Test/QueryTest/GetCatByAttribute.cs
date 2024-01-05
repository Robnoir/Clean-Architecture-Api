using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Cats.GetByAttribute;
using Domain.Models;
using Infrastructure.Database.Repositories.CatRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Test.Cat_Test.QueryTest
{

    [TestFixture]
    public class GetCatsByAttributeTest
    {
        private Mock<ICatRepository> _catRepositoryMock;
        private GetCatByAttributeQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _catRepositoryMock = new Mock<ICatRepository>();
            _handler = new GetCatByAttributeQueryHandler(_catRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_WithMatchingCriteria_ReturnsCats()
        {
            // Arrange
            var breed = "Siamese";
            var weight = 5;
            var cats = new List<Cat> { new Cat { Id = Guid.NewGuid(), CatBreed = breed, CatWeight = weight } };
            _catRepositoryMock.Setup(repo => repo.GetCatByBreedAndWeight(breed, weight)).ReturnsAsync(cats);

            var query = new GetCatByAttributeQuery(breed, weight);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotEmpty(result);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().CatBreed, Is.EqualTo(breed));
            Assert.That(result.First().CatWeight, Is.EqualTo(weight));
        }

        [Test]
        public async Task Handle_NoMatchingCriteria_ReturnsEmptyList()
        {
            // Arrange
            var breed = "Bengal";
            var weight = 10;
            _catRepositoryMock.Setup(repo => repo.GetCatByBreedAndWeight(breed, weight)).ReturnsAsync(new List<Cat>());

            var query = new GetCatByAttributeQuery(breed, weight);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsEmpty(result);
        }
    }

}
