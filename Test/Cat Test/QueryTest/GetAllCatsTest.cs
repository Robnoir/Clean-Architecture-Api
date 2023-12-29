//using Application.Queries.Cats.GetAll;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Test.Cat_Test.QueryTest
//{
//    [TestFixture]
//    internal class GetAllCatsTest
//    {
//        private GetAllCatsQueryHandler _handler;
//        private MockDatabase _mockDatabase;
//        [SetUp]
//        public void SetUp()
//        {
//            _mockDatabase = new MockDatabase();
//            _handler = new(_mockDatabase);
//        }
//        [Test]
//        public async Task GetAllCats_ShouldReturnAllCatsInList()
//        {
//            //Arrange
//            int expectedNumberOfCats = 5;

//            //Act
//            var result = await _handler.Handle(new GetAllCatsQuery(), CancellationToken.None);

//            //Assert
//            Assert.NotNull(result);
//            Assert.That(result.Count, Is.EqualTo(expectedNumberOfCats));

//        }
//    }
//}
