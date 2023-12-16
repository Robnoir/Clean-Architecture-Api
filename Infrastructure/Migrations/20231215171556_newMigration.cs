using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("399d8510-59b6-4b5c-8627-2162a569f49b"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("6adc8cd3-4b75-468c-84ca-ec6b64347f94"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("a002926b-92a0-4c77-85dd-b0ea8f46e205"));

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("06ead4b1-b189-44d1-a8d7-1f52ffa1bf66"), true, "Nugget" },
                    { new Guid("69aed48a-dd49-4864-9847-3e0df60727f8"), false, "Avocado" },
                    { new Guid("820ef067-08d4-4026-b18e-f3d1fc0c2019"), true, "SmallMac" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("41299766-4691-4a94-ada9-64d77a1d706d"), "Patrik" },
                    { new Guid("50049dd8-f68c-44bd-b594-ef6747e62e14"), "Björn" },
                    { new Guid("bcdff5eb-cb60-4bda-9fcc-0d386c89cd92"), "Alfred" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("06ead4b1-b189-44d1-a8d7-1f52ffa1bf66"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("69aed48a-dd49-4864-9847-3e0df60727f8"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("820ef067-08d4-4026-b18e-f3d1fc0c2019"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("41299766-4691-4a94-ada9-64d77a1d706d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("50049dd8-f68c-44bd-b594-ef6747e62e14"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("bcdff5eb-cb60-4bda-9fcc-0d386c89cd92"));

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("399d8510-59b6-4b5c-8627-2162a569f49b"), true, "Nugget" },
                    { new Guid("6adc8cd3-4b75-468c-84ca-ec6b64347f94"), true, "SmallMac" },
                    { new Guid("a002926b-92a0-4c77-85dd-b0ea8f46e205"), false, "Avocado" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2aad6d9b-9ede-4440-8909-0e81b5292d75"), "Alfred" },
                    { new Guid("54ca4906-3872-4899-a9c0-16af9f8002f9"), "Björn" },
                    { new Guid("62825eeb-7429-43f3-b673-2309fe3b4f84"), "Patrik" }
                });
        }
    }
}
