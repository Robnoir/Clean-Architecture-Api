using API.Controllers.DogsController;
using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test.DogTests.CommandTest
{
    [TestFixture]
    internal class DeleteDogByIdTest
    {
        private DeleteDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task DeleteDogById_ShouldRemoveDogIfExistingDogIsDeleted()
        {
            // Arrange
            var existingDogId = new Guid("12345678-1234-5678-1234-567812345679"); // Adjusted to an ID that would correspond to a dog
            var deleteCommand = new DeleteDogByIdCommand(existingDogId);

            // Act
            var result = await _handler.Handle(deleteCommand, new CancellationToken());

            // Assert
            var dogExistsAfterDeletion = _mockDatabase.Dogs.Any(d => d.Id == existingDogId);
            Assert.IsFalse(dogExistsAfterDeletion, "Dog should be deleted from the database");
        }
    }

}
