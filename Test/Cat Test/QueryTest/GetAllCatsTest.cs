using Application.Queries.Cats.GetAll;
using Domain.Models;
using Infrastructure.Database.Repositories.CatRepo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetAllCatsTest
    {
        private Mock<ICatRepository> _catRepositoryMock;
        private GetAllCatsQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _catRepositoryMock = new Mock<ICatRepository>();
            _handler = new GetAllCatsQueryHandler(_catRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllCats_WhenCatsExist_ReturnsAllCats()
        {
            // Arrange
            var fakeCats = new List<Cat> { new Cat(), new Cat() };
            _catRepositoryMock.Setup(repo => repo.GetAllCatsAsync())
                              .ReturnsAsync(fakeCats);

            // Act
            var query = new GetAllCatsQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            _catRepositoryMock.Verify(repo => repo.GetAllCatsAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllCats_WhenRepositoryReturnsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            _catRepositoryMock.Setup(repo => repo.GetAllCatsAsync())
                              .ReturnsAsync((List<Cat>)null);

            // Act
            var query = new GetAllCatsQuery();

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(query, CancellationToken.None));
            _catRepositoryMock.Verify(repo => repo.GetAllCatsAsync(), Times.Once);
        }
    }
}
