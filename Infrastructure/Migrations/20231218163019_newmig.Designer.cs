﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    [Migration("20231218163019_newmig")]
    partial class newmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Bird", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("CanFly")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Birds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("57d67666-6882-444b-ac9f-b2de5706e433"),
                            CanFly = true,
                            Name = "Adam"
                        },
                        new
                        {
                            Id = new Guid("78b4a971-3f0e-402a-b9b0-376ce478b3df"),
                            CanFly = true,
                            Name = "Perry"
                        },
                        new
                        {
                            Id = new Guid("8b02c4e6-7639-4d8c-9a07-606e72bbf070"),
                            CanFly = true,
                            Name = "Tweet"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345612"),
                            CanFly = true,
                            Name = "TestBirdForUnitTests"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345613"),
                            CanFly = true,
                            Name = "TestDeleteBird"
                        });
                });

            modelBuilder.Entity("Domain.Models.Cat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea4033aa-e56f-47a7-9bb1-efd66dbc40bc"),
                            LikesToPlay = true,
                            Name = "Nugget"
                        },
                        new
                        {
                            Id = new Guid("4592df12-473d-4704-81c1-c70637ea5c87"),
                            LikesToPlay = true,
                            Name = "SmallMac"
                        },
                        new
                        {
                            Id = new Guid("4ba1e40c-e59d-4683-ba54-6e457bbb2ef2"),
                            LikesToPlay = false,
                            Name = "Avocado"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345610"),
                            LikesToPlay = true,
                            Name = "TestCatForUnitTests"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345611"),
                            LikesToPlay = true,
                            Name = "TestDeleteCat"
                        });
                });

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7fccc7d-9b3d-4a7b-a04a-98558d9af415"),
                            Name = "Björn"
                        },
                        new
                        {
                            Id = new Guid("a5539e00-5ad9-4060-bf57-c19e546ba294"),
                            Name = "Patrik"
                        },
                        new
                        {
                            Id = new Guid("6d6eab15-3d33-471a-b94e-d8f89b56eefb"),
                            Name = "Alfred"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345678"),
                            Name = "TestDogForUnitTests"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345679"),
                            Name = "TestDeleteDog"
                        });
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

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
                            Id = new Guid("7883031d-19dc-421f-82b5-f2f2ac039947"),
                            Email = "rob@gmail.com",
                            PasswordHash = "Rob123",
                            Username = "rob"
                        },
                        new
                        {
                            Id = new Guid("b9543325-1719-4212-907a-86afee4f7ac7"),
                            Email = "stefan@gmail.com",
                            PasswordHash = "Stefan123",
                            Username = "stefan"
                        },
                        new
                        {
                            Id = new Guid("2c28b2d9-95fa-44b3-97d9-11d03ef99258"),
                            Email = "navjet@gmail.com",
                            PasswordHash = "navjet123",
                            Username = "Navjet"
                        },
                        new
                        {
                            Id = new Guid("a321f427-3357-4ced-b616-f658c613babb"),
                            Email = "nemo@find.com",
                            PasswordHash = "FindNemo123",
                            Username = "Nemm"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345614"),
                            Email = "DeleteUser@gmail.com",
                            PasswordHash = "TestDelete",
                            Username = "TestDeleteUser"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
