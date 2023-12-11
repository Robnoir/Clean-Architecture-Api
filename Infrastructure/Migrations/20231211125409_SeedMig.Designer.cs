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
    [Migration("20231211125409_SeedMig")]
    partial class SeedMig
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
                            Id = new Guid("399d8510-59b6-4b5c-8627-2162a569f49b"),
                            LikesToPlay = true,
                            Name = "Nugget"
                        },
                        new
                        {
                            Id = new Guid("6adc8cd3-4b75-468c-84ca-ec6b64347f94"),
                            LikesToPlay = true,
                            Name = "SmallMac"
                        },
                        new
                        {
                            Id = new Guid("a002926b-92a0-4c77-85dd-b0ea8f46e205"),
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
                            Id = new Guid("54ca4906-3872-4899-a9c0-16af9f8002f9"),
                            Name = "Björn"
                        },
                        new
                        {
                            Id = new Guid("62825eeb-7429-43f3-b673-2309fe3b4f84"),
                            Name = "Patrik"
                        },
                        new
                        {
                            Id = new Guid("2aad6d9b-9ede-4440-8909-0e81b5292d75"),
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
#pragma warning restore 612, 618
        }
    }
}
