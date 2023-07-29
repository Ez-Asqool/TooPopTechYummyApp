using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedMasterAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "a65e2d46-2033-4d15-81fc-6ad50d3e904b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a65e2d46-2033-4d15-81fc-6ad50d3e904b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "ImageName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf", 0, "90ab50d0-bb33-4def-bcd6-c73b3dd02896", null, "admin@admin.com", false, "Admin", null, "Master Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAENSLPBLYlVYIklELiyku56tdfWaGn/I7jeIylj8eba4FvCjnI/tin5bHEJEdOTs19g==", null, false, "f9abfce7-54ed-4ed5-964a-17627fa7c8ce", false, "Admin", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "ImageName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "a65e2d46-2033-4d15-81fc-6ad50d3e904b", 0, "ff07eb2e-54f2-4d8f-8b03-94497bce991a", null, "admin@admin.com", true, "Admin", null, "Master Admin", "Admin", false, null, "ADMIN@ADMIN.COM", null, "AQAAAAIAAYagAAAAEAZ4S+HfuzlaEA+gUInTiSIh/aPUoeFIJ2A3Jt76Tqb949JdWWABoXYGV8tcW7VNjw==", "1234567890", true, "3bbef084-b9c0-4ac5-b882-992a3f210f8b", false, "admin@admin.com", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "777be5d1-ad6a-4632-a0ee-23e28493a5ed", "a65e2d46-2033-4d15-81fc-6ad50d3e904b" });
        }
    }
}
