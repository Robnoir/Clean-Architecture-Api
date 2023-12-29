using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Breed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    BirdColor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CanFly = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    LikesToPlay = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
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
                        name: "FK_UserAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
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
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345610"), null, "Leopard", "Cat", true, "TestCatForUnitTests", 50 },
                    { new Guid("12345678-1234-5678-1234-567812345611"), null, "Panther", "Cat", true, "TestDeleteCat", 100 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "CanFly", "Discriminator", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345612"), "Purple", null, true, "Bird", "TestBirdForUnitTests", null },
                    { new Guid("12345678-1234-5678-1234-567812345613"), "White", null, true, "Bird", "TestDeleteBird", null }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), null, "Dobberman", "Dog", "TestDogForUnitTests", 6 },
                    { new Guid("12345678-1234-5678-1234-567812345679"), null, "Canecorso", "Dog", "TestDeleteDog", 5 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "CanFly", "Discriminator", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("1a9e6d77-00b1-4f8e-8bbf-f057361f7ff9"), "Green", null, true, "Bird", "Adam", null },
                    { new Guid("2321294e-caaa-4e61-981f-28546577d451"), "Blue", null, true, "Bird", "Tweet", null }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "Name", "Weight" },
                values: new object[] { new Guid("31853c9c-f21b-43a2-a5a0-1d8d7138d49b"), null, "Bulldog", "Dog", "Alfred", 5 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("4a6f640d-7af4-4f50-a915-683450951ea8"), null, "Lion", "Cat", false, "Avocado", 200 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "Name", "Weight" },
                values: new object[] { new Guid("87104dc3-84f9-4506-88ae-b85e4cbbc13a"), null, "Golden", "Dog", "Björn", 5 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "CanFly", "Discriminator", "Name", "Weight" },
                values: new object[] { new Guid("88e595f7-5c30-4490-acfd-3f8b124f7b4f"), "Red", null, true, "Bird", "Perry", null });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("adeb57ba-e53a-47f5-8399-94df4d8bc29d"), null, "Fluffy", "Cat", true, "Nugget", 2 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "Name", "Weight" },
                values: new object[] { new Guid("d16edc97-5611-4ee8-8623-a1529c626e92"), null, "Weenerdog", "Dog", "Rio", 5 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirdColor", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("d6289259-f9bd-46d2-a708-44d39927935b"), null, "NakedCat", "Cat", true, "SmallMac", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345614"), "", "TestDeleteUser" },
                    { new Guid("32778b1c-a51e-4451-9f82-15bd6d344a2b"), "Rob123", "rob" },
                    { new Guid("a00bfe4e-0e56-437c-ae7a-26eb1ca5a9a1"), "Stefan123", "stefan" },
                    { new Guid("d17adc59-29a8-4647-b7c9-ef45db3d7ded"), "FindNemo123", "Nemm" },
                    { new Guid("f5052d6e-b7eb-4dff-a661-0b3ad1735a36"), "navjet123", "Navjet" }
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
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
