using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStartersMenuCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "013a784e-3c7c-4ef2-ad71-670987f91d0c", "AQAAAAIAAYagAAAAELE6MzNebRD6EcKMAsodgyaCm+2DxVvnL1RwE7dNBUHilgONqF/yj7ya4x47WUvj6A==", "d2cb6f30-2d79-4e10-9e4a-c2a5c9d47227" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "Blocked", "Name" },
                values: new object[] { 4, 0, "Starters" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebed951d-f277-4fac-ab25-50a4ecc64951", "AQAAAAIAAYagAAAAEJCqFUGsV7ZitfBS/ihQB2kJc35m8YF6GqBdHmyLr9aJ/6ihHEnp1zaErSWVPtA44A==", "7bdd1660-42a1-48d9-904e-27904611a802" });
        }
    }
}
