using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Bird> Birds { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Bird>().HasData(
            new Bird { Id = Guid.NewGuid(), Name = "Adam", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Perry", CanFly = false },
            new Bird { Id = Guid.NewGuid(), Name = "Gardfield", CanFly = true }
            );
            // Seed data
            modelBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "twix", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "snickes", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "kitCat", LikesToPlay = true }
            );
            // Seed data
            modelBuilder.Entity<Dog>().HasData(
            new Dog { Id = Guid.NewGuid(), Name = "Björn" },
            new Dog { Id = Guid.NewGuid(), Name = "Patrik" },
            new Dog { Id = Guid.NewGuid(), Name = "Alfred" }
            );

            //Seed Data 
            modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Username = "john_doe", Password = "Password1" },
            new User { Id = Guid.NewGuid(), Username = "Rob", Password = "Rob123" }
                );


            base.OnModelCreating(modelBuilder);
        }



    }
}
