using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedProblem : Migration
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
                columns: new[] { "Id", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345610"), "Leopard", "Cat", true, "TestCatForUnitTests", 50 },
                    { new Guid("12345678-1234-5678-1234-567812345611"), "Panther", "Cat", true, "TestDeleteCat", 100 }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345612"), "Purple", true, "Bird", "TestBirdForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345613"), "White", true, "Bird", "TestDeleteBird" }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "Dobberman", "Dog", "TestDogForUnitTests", 6 },
                    { new Guid("12345678-1234-5678-1234-567812345679"), "Canecorso", "Dog", "TestDeleteDog", 5 }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("27eabc5f-09e1-4af7-b5b0-88de7d624785"), "Blue", true, "Bird", "Tweet" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("64926293-cb51-4494-a409-466189b5fa46"), "Weenerdog", "Dog", "Rio", 5 },
                    { new Guid("694a22bc-f941-428d-abcc-73a440a5a523"), "Bulldog", "Dog", "Alfred", 5 }
                });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("75968a7a-4de6-425d-8d68-dafb33ba17db"), "Red", true, "Bird", "Perry" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("8b1e9b5e-43e5-4414-96fe-56505348b7c6"), "NakedCat", "Cat", true, "SmallMac", 2 });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("b4b89d25-53fb-4c6c-b1d4-774738bc4f4f"), "Golden", "Dog", "Björn", 5 });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("dc3b0a02-83f4-4dd0-8ea6-999159defd24"), "Fluffy", "Cat", true, "Nugget", 2 });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "BirdColor", "CanFly", "Discriminator", "Name" },
                values: new object[] { new Guid("e5d9cec2-c6ee-4eb4-9973-86a2d8e7ec9e"), "Green", true, "Bird", "Adam" });

            migrationBuilder.InsertData(
                table: "AnimalModel",
                columns: new[] { "Id", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("ea23cf19-1f8b-46d4-8070-8c1127ccc065"), "Lion", "Cat", false, "Avocado", 200 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345614"), "", "TestDeleteUser" },
                    { new Guid("496c8e8b-7e64-4ab5-8cc9-11b9338dc2ff"), "FindNemo123", "Nemm" },
                    { new Guid("65c72833-0cf0-4d93-a764-7f1f0c15fd0e"), "Stefan123", "stefan" },
                    { new Guid("785af76c-0739-4dc4-8df1-ab4f2feb237a"), "navjet123", "Navjet" },
                    { new Guid("dafc8d9c-b739-410a-97c9-4d1ddaf6089b"), "Rob123", "rob" }
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
