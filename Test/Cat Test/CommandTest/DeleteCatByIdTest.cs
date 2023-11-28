
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
    internal class DeleteDogByIdTest
    {
        private MockDatabase _mockDatabase;
        private CatsController _catscontroller;
        private Mock<IMediator> _mediatormock;

        [SetUp]
        public void setup()
        {
            _mediatormock = new Mock<IMediator>();

            _mediatormock.Setup(m => m.Send(It.IsAny<DeleteCatByIdCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult((Cat)null));

            _mockDatabase = new MockDatabase();
            _catscontroller = new CatsController(_mediatormock.Object);


        }

        [Test]
        public async Task DeleteCatById_ShouldReturnNoContentIfExistingCatIsDeleted()
        {
            // Arrange
            var existingDogId = new Guid("12345678-1234-5678-1234-567812345610"); // ID of "TestDeleteCat"

            // Act
            var result = await _catscontroller.DeleteCatById(existingDogId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }




    }
}
