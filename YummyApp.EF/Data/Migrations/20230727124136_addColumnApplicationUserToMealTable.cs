using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnApplicationUserToMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82fa7ca9-dcdd-4ed9-a05f-2d818f5cd853", null, null, "AQAAAAIAAYagAAAAEENLK1LLkpRSinG9oN8K6Kv2MtqAxWOi5XZFZvV24MTUQvUb7nl6JK8l9GB1g0Wpow==", "5d7df6cc-5d67-4862-9757-e36a05cdbec9" });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_ApplicationUserId",
                table: "Meals",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_ApplicationUserId",
                table: "Meals",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_ApplicationUserId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_ApplicationUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Meals");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "013a784e-3c7c-4ef2-ad71-670987f91d0c", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAELE6MzNebRD6EcKMAsodgyaCm+2DxVvnL1RwE7dNBUHilgONqF/yj7ya4x47WUvj6A==", "d2cb6f30-2d79-4e10-9e4a-c2a5c9d47227" });
        }
    }
}
