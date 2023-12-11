using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CanFly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LikesToPlay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345610"), true, "TestCatForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345611"), true, "TestDeleteCat" },
                    { new Guid("399d8510-59b6-4b5c-8627-2162a569f49b"), true, "Nugget" },
                    { new Guid("6adc8cd3-4b75-468c-84ca-ec6b64347f94"), true, "SmallMac" },
                    { new Guid("a002926b-92a0-4c77-85dd-b0ea8f46e205"), false, "Avocado" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "TestDogForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345679"), "TestDeleteDog" },
                    { new Guid("2aad6d9b-9ede-4440-8909-0e81b5292d75"), "Alfred" },
                    { new Guid("54ca4906-3872-4899-a9c0-16af9f8002f9"), "Björn" },
                    { new Guid("62825eeb-7429-43f3-b673-2309fe3b4f84"), "Patrik" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345678"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345679"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("2aad6d9b-9ede-4440-8909-0e81b5292d75"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("54ca4906-3872-4899-a9c0-16af9f8002f9"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("62825eeb-7429-43f3-b673-2309fe3b4f84"));
        }
    }
}
