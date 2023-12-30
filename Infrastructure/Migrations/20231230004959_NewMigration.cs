using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
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
                    Breed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    DogBreed = table.Column<string>(name: "Dog_Breed", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DogWeight = table.Column<int>(name: "Dog_Weight", type: "int", nullable: true)
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
                columns: new[] { "Id", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("5228bf97-9e26-46e0-9828-8b515c65b1d5"), "Weenerdog", "Dog", "Rio", 5 },
                    { new Guid("5997273c-6580-47be-af36-df2262eaab73"), "Golden", "Dog", "Björn", 5 }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("5fd4a1a3-bfb2-4ac1-b9bc-95311f4df961"), "Green", true, "Bird", "Adam" },
                    { new Guid("74b7aab7-9853-4da8-bb21-3c314727376b"), "Red", true, "Bird", "Perry" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("8546cff4-8d71-4048-9e4a-b1b121774d28"), "NakedCat", "Cat", true, "SmallMac", 2 },
                    { new Guid("89ac1bb0-ec1d-4f3b-86dc-64adc5dff7e2"), "Lion", "Cat", false, "Avocado", 200 },
                    { new Guid("a59f071e-9125-446b-b978-6946a04091eb"), "Fluffy", "Cat", true, "Nugget", 2 }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("b93d0bba-2146-4ceb-aa6f-371e9c9bc591"), "Bulldog", "Dog", "Alfred", 5 });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("cd55cd4a-baeb-4594-92b1-d537cfbb130e"), "Blue", true, "Bird", "Tweet" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("3c6735eb-327d-41f0-b799-1468dde7fce7"), "navjet123", "Navjet" },
                    { new Guid("6ddcedc2-202d-4650-b91d-6198b0cf6d4b"), "Stefan123", "stefan" },
                    { new Guid("708623a3-b7e2-4ffb-8586-2d7a55ac36ac"), "Rob123", "rob" },
                    { new Guid("a332802c-8c46-4b53-80eb-3502d263033d"), "FindNemo123", "Nemo" }
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
