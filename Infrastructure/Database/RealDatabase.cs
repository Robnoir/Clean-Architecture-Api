using System;
using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Database.DatabaseHelpers;
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

            modelBuilder.Entity<AnimalModel>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Dog>("Dog")
                .HasValue<Cat>("Cat")
                .HasValue<Bird>("Bird");


            DatabaseSeedHelper.SeedData(modelBuilder);
        }





    }


}