using System;
using Domain.Models;
using Domain.Models.Animal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {


        public RealDatabase() { }
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }


        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAnimal> UserAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Robert123;database=RealDB",
                        new MySqlServerVersion(new Version(8, 2, 0)));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dog>().HasData(
            new Dog { Id = Guid.NewGuid(), Name = "Björn", Breed = "Golden", Weight = 5 },
            new Dog { Id = Guid.NewGuid(), Name = "Rio", Breed = "Weenerdog", Weight = 5 },
            new Dog { Id = Guid.NewGuid(), Name = "Alfred", Breed = "Bulldog", Weight = 5 }
            );

            modelBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "Nugget", LikesToPlay = true, Breed = "Fluffy", Weight = 2 },
            new Cat { Id = Guid.NewGuid(), Name = "SmallMac", LikesToPlay = true, Breed = "NakedCat", Weight = 2 },
            new Cat { Id = Guid.NewGuid(), Name = "Avocado", LikesToPlay = false, Breed = "Lion", Weight = 200 }
            );

            modelBuilder.Entity<Bird>().HasData(
            new Bird { Id = Guid.NewGuid(), Name = "Adam", CanFly = true, BirdColor = "Green" },
            new Bird { Id = Guid.NewGuid(), Name = "Perry", CanFly = true, BirdColor = "Red" },
            new Bird { Id = Guid.NewGuid(), Name = "Tweet", CanFly = true, BirdColor = "Blue" }
            );

            modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Username = "rob", PasswordHash = "Rob123" },
            new User { Id = Guid.NewGuid(), Username = "stefan", PasswordHash = "Stefan123" },
            new User { Id = Guid.NewGuid(), Username = "Navjet", PasswordHash = "navjet123" },
            new User { Id = Guid.NewGuid(), Username = "Nemo", PasswordHash = "FindNemo123" }
            );




            base.OnModelCreating(modelBuilder);

            //Configuring the many-to-many relationship
            modelBuilder.Entity<UserAnimal>()
                .HasKey(ua => new { ua.UserId, ua.AnimalId });

            modelBuilder.Entity<UserAnimal>()
                .HasOne(ua => ua.user)
                .WithMany(ua => ua.UserAnimals)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAnimal>()
                .HasOne(ua => ua.Animal)
                .WithMany(a => a.UserAnimals)
                .HasForeignKey(ua => ua.AnimalId);

        }





    }


}