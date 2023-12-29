﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    partial class RealDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Animal.AnimalModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AnimalModel");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AnimalModel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dafc8d9c-b739-410a-97c9-4d1ddaf6089b"),
                            PasswordHash = "Rob123",
                            Username = "rob"
                        },
                        new
                        {
                            Id = new Guid("65c72833-0cf0-4d93-a764-7f1f0c15fd0e"),
                            PasswordHash = "Stefan123",
                            Username = "stefan"
                        },
                        new
                        {
                            Id = new Guid("785af76c-0739-4dc4-8df1-ab4f2feb237a"),
                            PasswordHash = "navjet123",
                            Username = "Navjet"
                        },
                        new
                        {
                            Id = new Guid("496c8e8b-7e64-4ab5-8cc9-11b9338dc2ff"),
                            PasswordHash = "FindNemo123",
                            Username = "Nemm"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345614"),
                            PasswordHash = "",
                            Username = "TestDeleteUser"
                        });
                });

            modelBuilder.Entity("Domain.Models.UserAnimal", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "AnimalId");

                    b.HasIndex("AnimalId");

                    b.ToTable("UserAnimals");
                });

            modelBuilder.Entity("Domain.Models.Bird", b =>
                {
                    b.HasBaseType("Domain.Models.Animal.AnimalModel");

                    b.Property<string>("BirdColor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("CanFly")
                        .HasColumnType("tinyint(1)");

                    b.HasDiscriminator().HasValue("Bird");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5d9cec2-c6ee-4eb4-9973-86a2d8e7ec9e"),
                            Name = "Adam",
                            BirdColor = "Green",
                            CanFly = true
                        },
                        new
                        {
                            Id = new Guid("75968a7a-4de6-425d-8d68-dafb33ba17db"),
                            Name = "Perry",
                            BirdColor = "Red",
                            CanFly = true
                        },
                        new
                        {
                            Id = new Guid("27eabc5f-09e1-4af7-b5b0-88de7d624785"),
                            Name = "Tweet",
                            BirdColor = "Blue",
                            CanFly = true
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345612"),
                            Name = "TestBirdForUnitTests",
                            BirdColor = "Purple",
                            CanFly = true
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345613"),
                            Name = "TestDeleteBird",
                            BirdColor = "White",
                            CanFly = true
                        });
                });

            modelBuilder.Entity("Domain.Models.Cat", b =>
                {
                    b.HasBaseType("Domain.Models.Animal.AnimalModel");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Cat");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc3b0a02-83f4-4dd0-8ea6-999159defd24"),
                            Name = "Nugget",
                            Breed = "Fluffy",
                            LikesToPlay = true,
                            Weight = 2
                        },
                        new
                        {
                            Id = new Guid("8b1e9b5e-43e5-4414-96fe-56505348b7c6"),
                            Name = "SmallMac",
                            Breed = "NakedCat",
                            LikesToPlay = true,
                            Weight = 2
                        },
                        new
                        {
                            Id = new Guid("ea23cf19-1f8b-46d4-8070-8c1127ccc065"),
                            Name = "Avocado",
                            Breed = "Lion",
                            LikesToPlay = false,
                            Weight = 200
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345610"),
                            Name = "TestCatForUnitTests",
                            Breed = "Leopard",
                            LikesToPlay = true,
                            Weight = 50
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345611"),
                            Name = "TestDeleteCat",
                            Breed = "Panther",
                            LikesToPlay = true,
                            Weight = 100
                        });
                });

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.HasBaseType("Domain.Models.Animal.AnimalModel");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.ToTable(t =>
                        {
                            t.Property("Breed")
                                .HasColumnName("Dog_Breed");

                            t.Property("Weight")
                                .HasColumnName("Dog_Weight");
                        });

                    b.HasDiscriminator().HasValue("Dog");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b4b89d25-53fb-4c6c-b1d4-774738bc4f4f"),
                            Name = "Björn",
                            Breed = "Golden",
                            Weight = 5
                        },
                        new
                        {
                            Id = new Guid("64926293-cb51-4494-a409-466189b5fa46"),
                            Name = "Rio",
                            Breed = "Weenerdog",
                            Weight = 5
                        },
                        new
                        {
                            Id = new Guid("694a22bc-f941-428d-abcc-73a440a5a523"),
                            Name = "Alfred",
                            Breed = "Bulldog",
                            Weight = 5
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345678"),
                            Name = "TestDogForUnitTests",
                            Breed = "Dobberman",
                            Weight = 6
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345679"),
                            Name = "TestDeleteDog",
                            Breed = "Canecorso",
                            Weight = 5
                        });
                });

            modelBuilder.Entity("Domain.Models.UserAnimal", b =>
                {
                    b.HasOne("Domain.Models.Animal.AnimalModel", "Animal")
                        .WithMany("UserAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "user")
                        .WithMany("UserAnimals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Domain.Models.Animal.AnimalModel", b =>
                {
                    b.Navigation("UserAnimals");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("UserAnimals");
                });
#pragma warning restore 612, 618
        }
    }
}
