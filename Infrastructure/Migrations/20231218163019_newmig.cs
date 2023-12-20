using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345612"), true, "TestBirdForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345613"), true, "TestDeleteBird" },
                    { new Guid("57d67666-6882-444b-ac9f-b2de5706e433"), true, "Adam" },
                    { new Guid("78b4a971-3f0e-402a-b9b0-376ce478b3df"), true, "Perry" },
                    { new Guid("8b02c4e6-7639-4d8c-9a07-606e72bbf070"), true, "Tweet" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("4592df12-473d-4704-81c1-c70637ea5c87"), true, "SmallMac" },
                    { new Guid("4ba1e40c-e59d-4683-ba54-6e457bbb2ef2"), false, "Avocado" },
                    { new Guid("ea4033aa-e56f-47a7-9bb1-efd66dbc40bc"), true, "Nugget" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6d6eab15-3d33-471a-b94e-d8f89b56eefb"), "Alfred" },
                    { new Guid("a5539e00-5ad9-4060-bf57-c19e546ba294"), "Patrik" },
                    { new Guid("f7fccc7d-9b3d-4a7b-a04a-98558d9af415"), "Björn" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345614"), "DeleteUser@gmail.com", "TestDelete", "TestDeleteUser" },
                    { new Guid("2c28b2d9-95fa-44b3-97d9-11d03ef99258"), "navjet@gmail.com", "navjet123", "Navjet" },
                    { new Guid("7883031d-19dc-421f-82b5-f2f2ac039947"), "rob@gmail.com", "Rob123", "rob" },
                    { new Guid("a321f427-3357-4ced-b616-f658c613babb"), "nemo@find.com", "FindNemo123", "Nemm" },
                    { new Guid("b9543325-1719-4212-907a-86afee4f7ac7"), "stefan@gmail.com", "Stefan123", "stefan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345612"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345613"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("57d67666-6882-444b-ac9f-b2de5706e433"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("78b4a971-3f0e-402a-b9b0-376ce478b3df"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("8b02c4e6-7639-4d8c-9a07-606e72bbf070"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("4592df12-473d-4704-81c1-c70637ea5c87"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("4ba1e40c-e59d-4683-ba54-6e457bbb2ef2"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("ea4033aa-e56f-47a7-9bb1-efd66dbc40bc"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("6d6eab15-3d33-471a-b94e-d8f89b56eefb"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("a5539e00-5ad9-4060-bf57-c19e546ba294"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("f7fccc7d-9b3d-4a7b-a04a-98558d9af415"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345614"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2c28b2d9-95fa-44b3-97d9-11d03ef99258"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7883031d-19dc-421f-82b5-f2f2ac039947"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a321f427-3357-4ced-b616-f658c613babb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9543325-1719-4212-907a-86afee4f7ac7"));

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
    }
}
