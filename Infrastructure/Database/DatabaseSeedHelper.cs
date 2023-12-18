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
            new Dog { Id = Guid.NewGuid(), Name = "Björn" },
            new Dog { Id = Guid.NewGuid(), Name = "Patrik" },
            new Dog { Id = Guid.NewGuid(), Name = "Alfred" },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests" },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345679"), Name = "TestDeleteDog" }
            );

            modelBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "Nugget", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "SmallMac", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Avocado", LikesToPlay = false },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345610"), Name = "TestCatForUnitTests", LikesToPlay = true },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345611"), Name = "TestDeleteCat", LikesToPlay = true }

            );

            modelBuilder.Entity<Bird>().HasData(
            new Bird { Id = Guid.NewGuid(), Name = "Adam", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Perry", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Tweet", CanFly = true },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345612"), Name = "TestBirdForUnitTests", CanFly = true },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345613"), Name = "TestDeleteBird", CanFly = true }
            );

            modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Username = "rob", Email = "rob@gmail.com", PasswordHash = "Rob123" },
            new User { Id = Guid.NewGuid(), Username = "stefan", Email = "stefan@gmail.com", PasswordHash = "Stefan123" },
            new User { Id = Guid.NewGuid(), Username = "Navjet", Email = "navjet@gmail.com", PasswordHash = "navjet123" },
            new User { Id = Guid.NewGuid(), Username = "Nemm", Email = "nemo@find.com", PasswordHash = "FindNemo123" },
            new User { Id = new Guid("12345678-1234-5678-1234-567812345614"), Username = "TestDeleteUser", Email = "DeleteUser@gmail.com", PasswordHash = "TestDelete" }
            );


        }



    }
}