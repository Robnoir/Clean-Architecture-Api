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
    internal class DeleteDogByIdTest
    {
        private MockDatabase _mockDatabase;
        private DogsController _dogscontroller;
        private Mock<IMediator> _mediatormock;

        [SetUp]
        public void setup()
        {
            _mediatormock = new Mock<IMediator>();

            _mediatormock.Setup(m => m.Send(It.IsAny<DeleteDogByIdCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult((Dog)null));

            _mockDatabase = new MockDatabase();
            _dogscontroller = new DogsController(_mediatormock.Object);


        }

        [Test]
        public async Task DeleteDogById_ShouldReturnNoContentIfDogExists()
        {
            // Arrange
            var existingDogId = new Guid("12345678-1234-5678-1234-567812345679"); // ID of "TestDeleteDog"

            // Act
            var result = await _dogscontroller.DeleteDogById(existingDogId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
            Assert.IsNull(_mockDatabase.Dogs.FirstOrDefault(d => d.Id == existingDogId));
        }


        [Test]
        public async Task DeleteDog_ShouldReturnNotFoundWhenDogIsDeleted()
        {
            //Arrange
            var nonExistingDog = new Guid();
            _mockDatabase.Dogs.Clear();
          
            //Act
            var result = await _dogscontroller.DeleteDogById(nonExistingDog);

            //Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }


    }
}
