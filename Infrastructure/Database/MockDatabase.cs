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
            new Cat { Id = Guid.NewGuid(), Name = "Twix"},
            new Cat { Id = Guid.NewGuid(), Name = "Snickers"},
            new Cat { Id = Guid.NewGuid(), Name = "KitCat"},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345610"), Name = "TestCatForUnitTests"},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345611"), Name = "TestDeleteCat" }
        };


    }
}
