//using Application.Commands.Cats.UpdateCat;
//using Application.Dtos;
//using Domain.Models;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Test.BirdTests.CommandTest
//{
//    [TestFixture]
//    internal class UpdateDogTest
//    {
//        //Initializes the mockdatabase and handler before every test

//        private UpdateCatByIdCommandHandler _handler;
//        private MockDatabase _mockDatabase;

//        [SetUp]
//        public void Setup()
//        {

//            _mockDatabase = new MockDatabase();
//            _handler = new UpdateCatByIdCommandHandler(_mockDatabase);
//        }

//        [Test]
//        public async Task Handle_UpdatedDogInDB()
//        {
//            // Arrange
//            var InitCat = new Cat { Id = Guid.NewGuid(), Name = "" };
//            _mockDatabase.Cats.Add(InitCat);

//            //skapar en instans av updatedog
//            var command = new UpdateCatByIdCommand(
//                updatedCat: new CatDto { Name = "UpdatedCatName" },
//                id: InitCat.Id
//            );

//            // Act
//            var result = await _handler.Handle(command, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsInstanceOf<Cat>(result);

//            //kolla om hunden har det uppdaterade namnet 
//            Assert.That(result.Name, Is.EqualTo("UpdatedCatName"));

//            // kolla om hunden har uppdaterats i mocken också
//            var updatedCatInDatabase = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == command.Id);
//            Assert.That(updatedCatInDatabase, Is.Not.Null);
//            Assert.That(updatedCatInDatabase.Name, Is.EqualTo("UpdatedCatName"));
//        }

//    }
//}
