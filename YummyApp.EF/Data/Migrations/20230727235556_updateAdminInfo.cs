using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateAdminInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "UserName" },
                values: new object[] { "e212d486-2908-4554-9460-f342f7b84d5e", true, "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEFs4WzF0KmEbXcYCuUn/OYPACiNBXfHnjq+LF11hMKB9n8drOEA/iQVujK843BLO0A==", "1234567890", true, "9267529c-9d60-4f06-ab56-bb4975d2e413", "admin@admin.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d895bbb8-dfa9-4700-b2f7-7e7c333b21bf",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "UserName" },
                values: new object[] { "82fa7ca9-dcdd-4ed9-a05f-2d818f5cd853", false, null, "AQAAAAIAAYagAAAAEENLK1LLkpRSinG9oN8K6Kv2MtqAxWOi5XZFZvV24MTUQvUb7nl6JK8l9GB1g0Wpow==", null, false, "5d7df6cc-5d67-4862-9757-e36a05cdbec9", "Admin" });
        }
    }
}
