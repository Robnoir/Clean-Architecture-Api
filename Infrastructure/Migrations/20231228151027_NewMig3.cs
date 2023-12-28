using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnimalModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CanFly = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    LikesToPlay = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AnimalId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => new { x.UserId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_UserAnimals_AnimalModel_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "AnimalModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "Name" },
                values: new object[] { new Guid("07899b5a-1cfc-4c4c-a164-d3e9050dfc38"), "Dog", "Alfred" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345610"), "Cat", true, "TestCatForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345611"), "Cat", true, "TestDeleteCat" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "CanFly", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345612"), true, "Bird", "TestBirdForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345613"), true, "Bird", "TestDeleteBird" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "Dog", "TestDogForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345679"), "Dog", "TestDeleteDog" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("39f07666-06d1-4759-9e01-abf784320de1"), "Cat", true, "Nugget" },
                    { new Guid("415f6345-46c6-43c3-b9d5-2251540da414"), "Cat", false, "Avocado" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "Name" },
                values: new object[] { new Guid("57423d44-1cab-4764-8ee4-fe034f72eeeb"), "Dog", "Björn" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("5bcccf26-011b-4b15-bfbd-9874c1c0338f"), "Cat", true, "SmallMac" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "CanFly", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("68920ce9-aa48-4d0b-96c4-4b31ed92597a"), true, "Bird", "Adam" },
                    { new Guid("c2b3381c-0632-4048-a8fe-a35e8a20ed75"), true, "Bird", "Tweet" },
                    { new Guid("cec8bbd2-777f-4cc2-bde1-2ed57a5942e3"), true, "Bird", "Perry" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "Name" },
                values: new object[] { new Guid("faf1d15e-3571-472e-8871-e9c0b567ea18"), "Dog", "Patrik" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345614"), "", "TestDeleteUser" },
                    { new Guid("4abbe530-2a32-4009-996e-e43ae5ea3ff7"), "Rob123", "rob" },
                    { new Guid("ac28f386-6449-4303-917b-231ff81e8e46"), "FindNemo123", "Nemm" },
                    { new Guid("dc3e215d-db93-4c37-b864-8469104975d9"), "Stefan123", "stefan" },
                    { new Guid("e7ee1380-3fe0-4303-84b3-ac526324825b"), "navjet123", "Navjet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "AnimalModel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
