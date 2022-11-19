using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerrificTrioCakes.Migrations
{
    public partial class SeedRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "012a248b-ddd4-42c8-a11c-e8145ff01067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "049366ce-1092-4e1f-8d69-bc744717a91b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "514dcbae-6182-4941-b1c5-fd6c5bf1db62");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "012a248b-ddd4-42c8-a11c-e8145ff01067", "1a22a2cc-85ff-4136-8cb1-2ccf02e012df", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "049366ce-1092-4e1f-8d69-bc744717a91b", "290b10c4-9b01-43bc-a4ba-2ced1217c1bf", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "514dcbae-6182-4941-b1c5-fd6c5bf1db62", "2a4c7b12-4da2-4e1a-961a-4ec4fe24bcc3", "User", "USER" });
        }
    }
}
