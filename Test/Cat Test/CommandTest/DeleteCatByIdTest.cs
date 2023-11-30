
using API.Controllers.CatsController;
using Application.Commands.Cats.DeleteCat;
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

namespace Test.Cat_Test.CommandTest
{
    [TestFixture]
    internal class DeleteCatByIdTest
    {
        private DeleteCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task DeleteCatById_ShouldRemoveCatIfExistingCatIsDeleted()
        {
            // Arrange
            var existingCatId = new Guid("12345678-1234-5678-1234-567812345610"); 
            var deleteCommand = new DeleteCatByIdCommand(existingCatId);

            // Act
            var result = await _handler.Handle(deleteCommand, new CancellationToken());

            // Assert
            var catExistsAfterDeletion = _mockDatabase.Cats.Any(c => c.Id == existingCatId);
            Assert.IsFalse(catExistsAfterDeletion, "Cat should be deleted from the database");
        }
    }

}
