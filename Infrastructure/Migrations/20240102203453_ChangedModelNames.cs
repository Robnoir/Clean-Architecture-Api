using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModelNames : Migration
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
                    BirdColor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LikesToPlay = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CatBreed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CatWeight = table.Column<int>(type: "int", nullable: true),
                    DogBreed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DogWeight = table.Column<int>(type: "int", nullable: true)
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
                columns: new[] { "Id", "CatBreed", "CatWeight", "Discriminator", "LikesToPlay", "Name" },
                values: new object[] { new Guid("16c624d8-de21-4d11-9184-dd51200cc0ac"), "NakedCat", 2, "Cat", true, "SmallMac" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "DogBreed", "DogWeight", "Name" },
                values: new object[] { new Guid("234dcd1b-2c02-4558-92ac-13d2101deb20"), "Dog", "Golden", 5, "Björn" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("3e0e0635-5a89-47b1-b490-1f52750d3928"), "Green", true, "Bird", "Adam" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "CatBreed", "CatWeight", "Discriminator", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("883ae556-b539-4521-8b2e-ce2231bb688e"), "Fluffy", 2, "Cat", true, "Nugget" },
                    { new Guid("8a638eaf-83c5-439a-9331-ea9833b47d2d"), "Lion", 200, "Cat", false, "Avocado" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("9ad0afa1-c0de-47a3-912a-09a65f3943d2"), "Red", true, "Bird", "Perry" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "DogBreed", "DogWeight", "Name" },
                values: new object[] { new Guid("c8dab3d3-420b-4172-ae42-0c51b7ec88b8"), "Dog", "Bulldog", 5, "Alfred" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("ce8d2c98-8ea7-4ebd-907e-662da3ea65a2"), "Blue", true, "Bird", "Tweet" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Discriminator", "DogBreed", "DogWeight", "Name" },
                values: new object[] { new Guid("f6efd467-9d6f-43b2-89d2-05007b771676"), "Dog", "Weenerdog", 5, "Rio" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("101e0987-23bd-4475-983d-72d9e3cf5230"), "FindNemo123", "Nemo" },
                    { new Guid("2001b559-bbff-4624-af0b-f28121e6ae79"), "navjet123", "Navjet" },
                    { new Guid("28a71c01-94b7-412c-bf34-d84b9ceedb55"), "Rob123", "rob" },
                    { new Guid("b139c64a-5aa5-43f0-b7f3-c75f8a322085"), "Stefan123", "stefan" }
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
