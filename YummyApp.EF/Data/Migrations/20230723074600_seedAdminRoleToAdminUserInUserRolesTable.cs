using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    public partial class seedAdminRoleToAdminUserInUserRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "a65e2d46-2033-4d15-81fc-6ad50d3e904b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a65e2d46-2033-4d15-81fc-6ad50d3e904b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ee10087-83d5-4cc5-b7aa-8b1719f3ad77", "AQAAAAEAACcQAAAAEEHpltyyG98886w7wEwDEalcsWqh48mAf0XcM1v0STjrF0vk5QpbaSiB+ljFYgOHqA==", "28a5fbbf-e302-41b2-8f10-a3f897b2b4ad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "a65e2d46-2033-4d15-81fc-6ad50d3e904b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a65e2d46-2033-4d15-81fc-6ad50d3e904b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d64a9b0-dfb2-4d82-9668-60778fe79fbd", "AQAAAAEAACcQAAAAEHCIMtkJQfDWDjOVxuxGfR+JpX6/UWIvfsy3tJXclgKuMYxokc1RxslLDtKXbZOO0Q==", "5d9b9e22-be3e-4fff-8ac3-36698e832fd0" });
        }
    }
}
