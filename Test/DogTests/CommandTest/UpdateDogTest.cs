using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    internal class UpdateDogTest
    {

        private UpdateDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {

            _mockDatabase = new MockDatabase();
            _handler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_UpdatedDogInDB()
        {
            // Arrange
            var InitDog = new Dog { Id = Guid.NewGuid(), Name = "" };
            _mockDatabase.Dogs.Add(InitDog);

            //skapar en instans av updatedog
            var command = new UpdateDogByIdCommand(
                updatedDog: new DogDto { Name = "UpdatedDogName" },
                id: InitDog.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Dog>(result);

            //kolla om hunden har det uppdaterade namnet 
            Assert.That(result.Name, Is.EqualTo("UpdatedDogName"));

            // kolla om hunden har uppdaterats i mocken också
            var updatedDogInDatabase = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == command.Id);
            Assert.That(updatedDogInDatabase, Is.Not.Null);
            Assert.That(updatedDogInDatabase.Name, Is.EqualTo("UpdatedDogName"));
        }

    }
}
