using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerrificTrioCakes.Data.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62f7109f-b929-42cd-92c2-4ccb08803f7d", "80e1f706-68bc-4526-937d-e6e624ed339d", "Admin", "ADMIN" },
                    { "c36ecd80-aec9-4677-b33f-e1e6b7ddc9f4", "d475c953-0014-4e34-aaee-ef442b4385c5", "User", "USER" },
                    { "cbdc7b8f-a42e-4adb-bd0f-329b2dbcab28", "82dfb0a4-9273-4554-9f98-3cb271f792d0", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5131373d-87da-47b0-ba8a-ac5a0f205116", 0, "a8533129-783f-401b-9df9-21ed21228d60", "user@mail.com", true, false, null, "USER@MAIL.COM", "USER@MAIL.COM", "AQAAAAEAACcQAAAAECd8oBBxnYgfj/gv6ViIA7kC7gHMdIU23uC9yAXvyBmVPtbEdz8uySAtyS2HEdhC6A==", null, false, "76cc9451-4286-414f-a5cb-e84f111ab8db", false, "user@mail.com" },
                    { "6419f98d-a17b-40ca-9287-e7ff5f544922", 0, "0efa3bff-e7f4-4af0-b616-106bd3b245cf", "staff@mail.com", true, false, null, "STAFF@MAIL.COM", "STAFF@MAIL.COM", "AQAAAAEAACcQAAAAEGY9iLXIQdMYLSSJQhAB//vr3tI/qZ1BbljSjrI+/sTlKzJy3icD38dVDWhTNhUXWQ==", null, false, "522855e5-e65c-49db-b4e4-ea892cbe0f5d", false, "staff@mail.com" },
                    { "9659aeae-5e19-4fe8-93b0-5d4750c0c3de", 0, "ff1993c8-9a93-4fd5-bb04-5841a580ece5", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEOkKCgorp7Ep7yD2gIaogrH1m1KSqmAcIOwQSfYJKiqrjUn5ebYppUfYM/+5oSzqpw==", null, false, "c1d27da2-a0db-414d-a36d-51f788464019", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c36ecd80-aec9-4677-b33f-e1e6b7ddc9f4", "5131373d-87da-47b0-ba8a-ac5a0f205116" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbdc7b8f-a42e-4adb-bd0f-329b2dbcab28", "6419f98d-a17b-40ca-9287-e7ff5f544922" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "62f7109f-b929-42cd-92c2-4ccb08803f7d", "9659aeae-5e19-4fe8-93b0-5d4750c0c3de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c36ecd80-aec9-4677-b33f-e1e6b7ddc9f4", "5131373d-87da-47b0-ba8a-ac5a0f205116" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbdc7b8f-a42e-4adb-bd0f-329b2dbcab28", "6419f98d-a17b-40ca-9287-e7ff5f544922" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62f7109f-b929-42cd-92c2-4ccb08803f7d", "9659aeae-5e19-4fe8-93b0-5d4750c0c3de" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62f7109f-b929-42cd-92c2-4ccb08803f7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c36ecd80-aec9-4677-b33f-e1e6b7ddc9f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbdc7b8f-a42e-4adb-bd0f-329b2dbcab28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5131373d-87da-47b0-ba8a-ac5a0f205116");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6419f98d-a17b-40ca-9287-e7ff5f544922");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9659aeae-5e19-4fe8-93b0-5d4750c0c3de");
        }
    }
}
