//using Application.Queries.Birds.GetAll;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Test.BirdTests.QueryTest
//{
//    [TestFixture]
//    public class GetAllBirdsTest
//    {
//        private GetAllBirdsQueryHandler _handler;
//        private MockDatabase _mockDatabase;

//        [SetUp]
//        public void SetUp()
//        {
//            _mockDatabase = new MockDatabase();
//            _handler = new GetAllBirdsQueryHandler(_mockDatabase);
//        }

//        [Test]
//        public async Task GetAllBirds_ShouldReturnAllBirdsInList()
//        {
//            // Arrange
//            int expectedNumberOfBirds = _mockDatabase.Birds.Count; // Assuming you want to check against the actual number of birds in MockDatabase

//            // Act
//            var result = await _handler.Handle(new GetAllBirdsQuery(), CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.That(result.Count, Is.EqualTo(expectedNumberOfBirds));
//        }
//    }

//}
