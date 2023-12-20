//using Application.Commands.Cats.AddCat;
//using Application.Dtos;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Test.Cat_Test.CommandTest
//{
//    internal class AddCatTest
//    {
//        private MockDatabase _mockDatabase;
//        private AddCatCommandHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            // Initialisera mockdatabasen och hanteraren innan varje test
//            _mockDatabase = new MockDatabase();
//            _handler = new AddCatCommandHandler(_mockDatabase);
//        }

//        [Test]
//        public async Task Handle_ChecksAddedDog_ReturnTrue()
//        {
//            // Arrange
//            var command = new AddCatCommand(new CatDto { Name = "MioMao" });

//            // Act
//            var result = await _handler.Handle(command, CancellationToken.None);

//            // Assert
//            var newCatToDB = _mockDatabase.Cats.FirstOrDefault(cat => cat.Name == "MioMao");

//            Assert.IsNotNull(newCatToDB);
//            Assert.That(newCatToDB.Name, Is.EqualTo("MioMao"));
//        }
//    }
//}
