using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newnewmig2 : Migration
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
                columns: new[] { "Id", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("10e5b07b-7e5e-468e-a4a2-39c048bc06cd"), true, "Bird", "Perry" });

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
                    { new Guid("12345678-1234-5678-1234-567812345679"), "Dog", "TestDeleteDog" },
                    { new Guid("2d12e32a-3d35-4f0f-865f-b81a74cbd3ae"), "Dog", "Björn" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("4536b0a1-166f-4c52-8379-7dfa02f055db"), "Cat", true, "SmallMac" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("899526b6-06f1-4f97-856e-b791e0b287a8"), true, "Bird", "Tweet" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("93312dac-9b76-484f-aed1-444ce8dbe290"), "Dog", "Patrik" },
                    { new Guid("97b9bf54-4acf-48e1-8251-26bc58482912"), "Dog", "Alfred" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("be2c29dd-dbdb-4336-92fb-eb8659d4dc8c"), "Cat", false, "Avocado" },
                    { new Guid("d458a5d3-0be8-4042-a5e2-90266f983f6d"), "Cat", true, "Nugget" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("f05635e8-4ba1-4055-bcf6-7de70b09bcb8"), true, "Bird", "Adam" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345614"), "", "TestDeleteUser" },
                    { new Guid("12aff2aa-55c7-48d0-abff-8f03b5150fb7"), "navjet123", "Navjet" },
                    { new Guid("7d70af93-b41a-4c16-9049-0e7fcaa3098e"), "Stefan123", "stefan" },
                    { new Guid("89491297-b364-486b-bc4f-e9c7274d0047"), "FindNemo123", "Nemm" },
                    { new Guid("ce8d930d-0848-4f48-8f18-ee9031c1b8e9"), "Rob123", "rob" }
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
