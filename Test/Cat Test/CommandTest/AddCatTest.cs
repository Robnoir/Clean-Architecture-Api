using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTest
    {
        private Mock<ICatRepository> _mockCatRepository;
        private Mock<ILogger<AddCatCommandHandler>> _mockLogger;
        private IRequestHandler<AddCatCommand, Cat> _handler;

        [SetUp]
        public void SetUp()
        {
            _mockCatRepository = new Mock<ICatRepository>();
            _mockLogger = new Mock<ILogger<AddCatCommandHandler>>();
            _handler = new AddCatCommandHandler(_mockCatRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task Handle_ShouldAddCat_WhenValidDataIsProvided()
        {
            var catDto = new CatDto
            {
                Name = "Nugget",
                LikesToPlay = true,
                Breed = "Fluffy",
                Weight = 2
            };
            var command = new AddCatCommand(catDto);
            var expectedCat = new Cat
            {
                Id = Guid.NewGuid(),
                Name = catDto.Name,
                LikesToPlay = catDto.LikesToPlay,
                CatBreed = catDto.Breed,
                CatWeight = catDto.Weight
            };
            _mockCatRepository.Setup(repo => repo.AddAsync(It.IsAny<Cat>())).ReturnsAsync(expectedCat);

            var result = await _handler.Handle(command, CancellationToken.None);

            _mockCatRepository.Verify(repo => repo.AddAsync(It.Is<Cat>(c => c.Name == catDto.Name)), Times.Once());
            Assert.That(result.Name, Is.EqualTo(catDto.Name));
            Assert.That(result.CatWeight, Is.EqualTo(catDto.Weight));
        }

        [Test]
        public void Handle_ShouldThrowException_WhenInvalidDataIsProvided()
        {
            var catDto = new CatDto
            {
                Name = "", // Invalid data: empty name
                LikesToPlay = true,
                Breed = "Fluffy",
                Weight = 2
            };
            var command = new AddCatCommand(catDto);

            _mockCatRepository.Setup(repo => repo.AddAsync(It.IsAny<Cat>())).ThrowsAsync(new ArgumentException("Name cannot be empty"));

            var ex = Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Is.EqualTo("Name cannot be empty"));
        }
    }
}
