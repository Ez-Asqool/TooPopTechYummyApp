using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    public partial class SeedAdminUserInApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "ImageName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "a65e2d46-2033-4d15-81fc-6ad50d3e904b", 0, "9d64a9b0-dfb2-4d82-9668-60778fe79fbd", null, "admin@admin.com", false, "Admin", null, "Master Admin", "Admin", false, null, "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEHCIMtkJQfDWDjOVxuxGfR+JpX6/UWIvfsy3tJXclgKuMYxokc1RxslLDtKXbZOO0Q==", "1234567890", false, "5d9b9e22-be3e-4fff-8ac3-36698e832fd0", false, "Admin", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a65e2d46-2033-4d15-81fc-6ad50d3e904b");
        }
    }
}
