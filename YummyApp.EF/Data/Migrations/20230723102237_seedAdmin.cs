using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a65e2d46-2033-4d15-81fc-6ad50d3e904b",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "UserName" },
                values: new object[] { "ff07eb2e-54f2-4d8f-8b03-94497bce991a", true, "AQAAAAIAAYagAAAAEAZ4S+HfuzlaEA+gUInTiSIh/aPUoeFIJ2A3Jt76Tqb949JdWWABoXYGV8tcW7VNjw==", true, "3bbef084-b9c0-4ac5-b882-992a3f210f8b", "admin@admin.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a65e2d46-2033-4d15-81fc-6ad50d3e904b",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "UserName" },
                values: new object[] { "2ee10087-83d5-4cc5-b7aa-8b1719f3ad77", false, "AQAAAAEAACcQAAAAEEHpltyyG98886w7wEwDEalcsWqh48mAf0XcM1v0STjrF0vk5QpbaSiB+ljFYgOHqA==", false, "28a5fbbf-e302-41b2-8f10-a3f897b2b4ad", "Admin" });
        }
    }
}
