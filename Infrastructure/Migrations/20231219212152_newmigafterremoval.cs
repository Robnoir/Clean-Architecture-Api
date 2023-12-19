using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newmigafterremoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("99ae69ef-12ba-48a3-a98b-4627819d047d"), true, "Tweet" },
                    { new Guid("ccbd0ea5-5d64-4a0b-b21d-439e62e997e0"), true, "Perry" },
                    { new Guid("ec759a5f-5ad9-4a80-86db-846eedcb7ec2"), true, "Adam" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("0963b3aa-2caa-4c0f-bd14-9797f2fbee68"), false, "Avocado" },
                    { new Guid("ceb31031-edbd-4792-b1ae-b597ad5c49b3"), true, "Nugget" },
                    { new Guid("db7b20ab-57da-4cea-8be0-9859f7e038f3"), true, "SmallMac" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("65e9cbbe-99f7-4571-921b-f12163a218ee"), "Patrik" },
                    { new Guid("cabceb19-b94e-45a3-9100-933b9ce68ce7"), "Alfred" },
                    { new Guid("e0a0f114-3c7a-48af-9e10-4f1a8c238119"), "Björn" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345614"),
                column: "PasswordHash",
                value: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("036acc54-c50d-4f51-a9d8-e3f99fc75b12"), "FindNemo123", "Nemm" },
                    { new Guid("39ca1432-2b6f-41aa-a5c0-d3c12b300a42"), "Stefan123", "stefan" },
                    { new Guid("ae00b67a-599a-4937-9030-cf14e26f3a92"), "Rob123", "rob" },
                    { new Guid("e30ba2b5-4dbf-4e2f-9014-84ce1e538472"), "navjet123", "Navjet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("99ae69ef-12ba-48a3-a98b-4627819d047d"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("ccbd0ea5-5d64-4a0b-b21d-439e62e997e0"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "Id",
                keyValue: new Guid("ec759a5f-5ad9-4a80-86db-846eedcb7ec2"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("0963b3aa-2caa-4c0f-bd14-9797f2fbee68"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("ceb31031-edbd-4792-b1ae-b597ad5c49b3"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: new Guid("db7b20ab-57da-4cea-8be0-9859f7e038f3"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("65e9cbbe-99f7-4571-921b-f12163a218ee"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("cabceb19-b94e-45a3-9100-933b9ce68ce7"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("e0a0f114-3c7a-48af-9e10-4f1a8c238119"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("036acc54-c50d-4f51-a9d8-e3f99fc75b12"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39ca1432-2b6f-41aa-a5c0-d3c12b300a42"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae00b67a-599a-4937-9030-cf14e26f3a92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e30ba2b5-4dbf-4e2f-9014-84ce1e538472"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Name" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-5678-1234-567812345614"),
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "DeleteUser@gmail.com", "TestDelete" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("2c28b2d9-95fa-44b3-97d9-11d03ef99258"), "navjet@gmail.com", "navjet123", "Navjet" },
                    { new Guid("7883031d-19dc-421f-82b5-f2f2ac039947"), "rob@gmail.com", "Rob123", "rob" },
                    { new Guid("a321f427-3357-4ced-b616-f658c613babb"), "nemo@find.com", "FindNemo123", "Nemm" },
                    { new Guid("b9543325-1719-4212-907a-86afee4f7ac7"), "stefan@gmail.com", "Stefan123", "stefan" }
                });
        }
    }
}
