using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    public partial class addTheThreeRolesToRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d7aa759-69fc-45f5-8b48-b7c7c3552501", "7d7aa759-69fc-45f5-8b48-b7c7c3552501", "Chef", "CHEF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2e024b4-8f6e-40a8-bbf2-2faa1418ab79", "f2e024b4-8f6e-40a8-bbf2-2faa1418ab79", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "777be5d1-ad6a-4632-a0ee-23e28493a5ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d7aa759-69fc-45f5-8b48-b7c7c3552501");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2e024b4-8f6e-40a8-bbf2-2faa1418ab79");
        }
    }
}
