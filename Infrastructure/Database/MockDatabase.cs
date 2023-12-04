using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }


        public List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345679"), Name = "TestDeleteDog" }
        };

        public List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Twix", LikesToPlay = true},
            new Cat { Id = Guid.NewGuid(), Name = "Snickers", LikesToPlay = true},
            new Cat { Id = Guid.NewGuid(), Name = "KitCat", LikesToPlay = true },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345610"), Name = "TestCatForUnitTests",LikesToPlay =true},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345611"), Name = "TestDeleteCat" , LikesToPlay = true}
        };

        public List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Adam", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Perry", CanFly = true},
            new Bird { Id = Guid.NewGuid(), Name = "Tweet", CanFly = true},
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345612"), Name = "TestBirdForUnitTests", CanFly = true },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345613"), Name = "TestDeleteBird", CanFly = true}
        };


    }
}
