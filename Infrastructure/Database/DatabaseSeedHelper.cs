using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
            // Add more methods for other entities as needed

        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
            new Dog { Id = Guid.NewGuid(), Name = "Björn", Breed = "Golden", Weight = 5 },
            new Dog { Id = Guid.NewGuid(), Name = "Rio", Breed = "Weenerdog", Weight = 5 },
            new Dog { Id = Guid.NewGuid(), Name = "Alfred", Breed = "Bulldog", Weight = 5 },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests", Breed = "Dobberman", Weight = 6 },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345679"), Name = "TestDeleteDog", Breed = "Canecorso", Weight = 5 }
            );

            modelBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "Nugget", LikesToPlay = true, Breed = "Fluffy", Weight = 6 },
            new Cat { Id = Guid.NewGuid(), Name = "SmallMac", LikesToPlay = true, Breed = "NakedCat", Weight = 6 },
            new Cat { Id = Guid.NewGuid(), Name = "Avocado", LikesToPlay = false, Breed = "Lion", Weight = 6 },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345610"), Name = "TestCatForUnitTests", LikesToPlay = true, Breed = "Leopard", Weight = 6 },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345611"), Name = "TestDeleteCat", LikesToPlay = true, Breed = "Panther", Weight = 6 }

            );

            modelBuilder.Entity<Bird>().HasData(
            new Bird { Id = Guid.NewGuid(), Name = "Adam", CanFly = true, BirdColor = "Green" },
            new Bird { Id = Guid.NewGuid(), Name = "Perry", CanFly = true, BirdColor = "Red" },
            new Bird { Id = Guid.NewGuid(), Name = "Tweet", CanFly = true, BirdColor = "Blue" },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345612"), Name = "TestBirdForUnitTests", CanFly = true, BirdColor = "Purple" },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345613"), Name = "TestDeleteBird", CanFly = true, BirdColor = "White" }
            );

            modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Username = "rob", PasswordHash = "Rob123" },
            new User { Id = Guid.NewGuid(), Username = "stefan", PasswordHash = "Stefan123" },
            new User { Id = Guid.NewGuid(), Username = "Navjet", PasswordHash = "navjet123" },
            new User { Id = Guid.NewGuid(), Username = "Nemm", PasswordHash = "FindNemo123" },
            new User { Id = new Guid("12345678-1234-5678-1234-567812345614"), Username = "TestDeleteUser" }
            );

        }
    }
}